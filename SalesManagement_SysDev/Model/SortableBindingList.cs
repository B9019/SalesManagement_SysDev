using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Reflection;
using System.Xml.Linq;

namespace SalesManagement.Model
{
    // ソート可能なデータグリッドビュー表示用リストクラス
    // 以下、マイクロソフトリファレンスリソースより
    internal class SortableBindingList<T> : BindingList<T>
    {
        // 指定したリストクラスを継承したコンストラクタ
        internal SortableBindingList(IList<T> list) : base(list)
        {
        }

        private bool isSorted = false;
        private PropertyDescriptor sortProperty = null;
        private ListSortDirection sortDirection = ListSortDirection.Ascending;

        // ApplySortCoreで適用されたソート情報をクリア
        protected override void RemoveSortCore()
        {
            isSorted = false;
            sortProperty = null;
        }

        // リストの並べ替え方向を取得
        protected override ListSortDirection SortDirectionCore
        {
            get { return sortDirection; }
        }

        // リストの並べ替えに使用するソート情報（ソート項目）を取得
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return sortProperty; }
        }

        // リストがソートされたかを返す
        protected override bool IsSortedCore
        {
            get { return isSorted; }
        }

        // リストがソートをサポートすることを示す
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        // 指定されたソート情報（ソート項目）及び並べ替え方向を用いてソートを実行
        // in       prop    　: ソート情報（ソート項目）
        //          direction : ソート方向
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {

            //Only apply sort if the column is sortable, decision was made not to throw in this case.
            //Don't prevent nullable types from working.
            Type propertyType = prop.PropertyType;

            // 比較可能な場合ソートを実行
            if (PropertyComparer.IsAllowable(propertyType))
            {
                // ソート処理を実行
                ((List<T>)this.Items).Sort(new PropertyComparer(prop, direction));

                // 実行情報をセット
                sortDirection = direction;
                sortProperty = prop;
                isSorted = true;

                // ListChanged イベントの発生
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
        }

        // 比較クラス（ソート処理）
        internal class PropertyComparer : Comparer<T>
        {
            private PropertyDescriptor prop;
            private IComparer comparer;
            private readonly ListSortDirection direction;
            private readonly bool useToString;

            // ソート条件設定
            internal PropertyComparer(PropertyDescriptor prop, ListSortDirection direction)
            {
                // 型チェック
                if (prop.ComponentType != typeof(T))
                {
                    throw new MissingMemberException(typeof(T).Name, prop.Name);
                }

                // 比較情報を取得
                this.prop = prop;
                this.direction = direction;

                // オブジェクト比較
                if (OkWithIComparable(prop.PropertyType))
                {
                    Type comparerType = typeof(Comparer<>).MakeGenericType(prop.PropertyType);
                    PropertyInfo defaultComparer = comparerType.GetProperty("Default");
                    comparer = (IComparer)defaultComparer.GetValue(null, null);
                    useToString = false;
                }

                // 文字列比較
                else if (OkWithToString(prop.PropertyType))
                {
                    comparer = StringComparer.CurrentCultureIgnoreCase;
                    useToString = true;
                }
            }

            // 比較処理（オーバーライド）
            // in   T x, T y :
            // out  x, y を昇順・降順に従って比較し、同じか大きいか小さいかを返す
            // < 0 →　x < y
            // = 0 →　x = y
            // > 0 →　x > y
            public override int Compare(T x, T y)
            {
                object xValue = prop.GetValue(x);
                object yValue = prop.GetValue(y);

                if (useToString)
                {
                    xValue = xValue?.ToString();
                    yValue = yValue?.ToString();
                }

                // 昇順
                if (direction == ListSortDirection.Ascending)
                {
                    return comparer.Compare(xValue, yValue);
                }
                // 降順
                else
                {
                    return comparer.Compare(yValue, xValue);
                }
            }

            // 文字列比較チェック
            protected static bool OkWithToString(Type t)
            {
                // this is the list of types that behave specially for the purpose of 
                // sorting. if we have a property of this type, and it does not implement
                // IComparable, then this class will sort the properties according to the
                // ToString() method. 

                // In the case of an XNode, the ToString() returns the
                // XML, which is what we care about.
                return (t.Equals(typeof(XNode)) || t.IsSubclassOf(typeof(XNode)));

            }

            // オブジェクト比較チェック
            protected static bool OkWithIComparable(Type t)
            {
                return (t.GetInterface("IComparable") != null)
                    || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
            }

            // 比較可能かどうかのチェック
            public static bool IsAllowable(Type t)
            {
                return OkWithToString(t) || OkWithIComparable(t);
            }
        }
    }
}