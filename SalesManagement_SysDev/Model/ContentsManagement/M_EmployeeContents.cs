using SalesManagement_SysDev.Model.ContentsManagement.Common;
using SalesManagement_SysDev;
using SalesManagement_SysDev.Model;
using SalesManagement_SysDev.Model.Entity;
using SalesManagement_SysDev.Model.Entity.Disp;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesManagement_SysDev.Model.ContentsManagement;


namespace SalesManagement_SysDev.Model.ContentsManagement
{
    class M_EmployeeContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private readonly CommonFunction _cm = new CommonFunction();

        // データベース処理モジュール（メッセージ）
        private MessageCommon _msc = new MessageCommon();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        // ***** メソッド定義

        // データ取得
        // in  : EmID
        // out : EmIDデータ
        public M_Product GetProduct(int PrID)
        {
            try
            {
                using (var db = new SalesManagement_DevContext()) return db.M_Products.Single(m => m.PrID == PrID);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundProduct);
            }
        }

        // データ追加
        // in   : M_Employeeデータ
        public string PostM_Employee(M_Employee regEmployee)
        {
            using (var db1 = new SalesManagement_DevContext())
            {
                db1.M_Employees.Add(regEmployee);
                db1.Entry(regEmployee).State = EntityState.Added;
                db1.SaveChanges();
            }

            //// ログ出力
            //var operationLog = new OperationLog()
            //{
            //    EventRaisingTime = DateTime.Now,
            //    Operator = _logonUser,
            //    Table = "Product",
            //    Command = "Post",
            //    Data = M_ProductLogData(regProduct),
            //    Comments = string.Empty
            //};
            //StaticCommon.PostOperationLog(operationLog);

            return string.Empty;
        }

        // 表示データ取得（始点・終点指定）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点

        public IEnumerable<M_DispEmployee> GetDispEmployees()
        {
            using (var db = new SalesManagement_DevContext())
            {
                List<M_DispEmployee> dispEmployees = new List<M_DispEmployee>();
                foreach (M_Employee employee in db.M_Employees)
                {
                    string maker;
                    try
                    {
                        maker = (employee.EmID != -1) ? db.M_Employees.Single(m => m.EmID == employee.EmID).EmName : string.Empty;

                        // 無効表示
                        if (db.M_Employees.Single(m => m.EmID == employee.EmID).EmFlag != 0) maker = "[" + maker + "]";
                    }
                    catch
                    {
                        maker = string.Empty;
                    }

                    //string category;
                    //try
                    //{
                    //    category = (item.CategoryCD != -1) ? db.M_Categorys.Single(m => m.CategoryCD == item.CategoryCD).CategoryName : string.Empty;

                    //    // 無効表示
                    //    if (db.M_Categorys.Single(m => m.CategoryCD == item.CategoryCD).DelFLG == true) category = "[" + category + "]";
                    //}
                    //catch
                    //{
                    //    category = string.Empty;
                    //}

                    dispEmployees.Add(new M_DispEmployee()
                    {
                        EmID = employee.EmID,
                        EmName = employee.EmName,
                        SoID = employee.SoID,
                        PoID = employee.PoID,
                        EmHiredate = employee.EmHiredate,
                        EmPhone = employee.EmPhone,
                        EmHidden = employee.EmHidden,
                        //Timestamp = item.Timestamp,
                        //LogData = item.LogData,
                    });
                }
                // ソータブルリスト作成
                SortableBindingList<M_DispEmployee> sortableDispEmployee = new SortableBindingList<M_DispEmployee>(dispEmployees);

                //// ログ出力
                //var operationLog = new OperationLog()
                //{
                //    EventRaisingTime = DateTime.Now,
                //    Operator = _logonUser,
                //    Table = "Product",
                //    Command = "GetAll",
                //    Data = string.Empty,
                //    Comments = string.Empty
                //};
                //StaticCommon.PostOperationLog(operationLog);

                return sortableDispEmployee;
            }
        }
        // データ更新
        // in   : M_Employeeデータ
        // out  : エラーメッセージ 
        public string PutEmployee(M_Employee regEmployee)
        {
            using (var db = new SalesManagement_DevContext())
            {
                M_Employee employee;
                try
                {
                    employee = db.M_Employees.Single(x => x.EmID == regEmployee.EmID);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundItem, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                    return _msc.GetMessage(110);
                }
                employee.EmID = employee.EmID;
                employee.EmName = employee.EmName;
                employee.SoID = employee.SoID;
                employee.PoID = employee.PoID;
                employee.EmHiredate = employee.EmHiredate;
                employee.EmPhone = employee.EmPhone;
                employee.EmHidden = employee.EmHidden;

                db.Entry(employee).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    // throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                    return _msc.GetMessage(100);
                }

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Employee",
                    Command = "Put",
                    //Data = EmployeeLogData(regEmployee),
                    Comments = string.Empty
                };
                //StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }
        // データ削除
        // in       Employee : 削除する商品ID
        public void DeleteEmployee(int M_EmID)
        {
            M_Employee employee;
            using (var db = new SalesManagement_DevContext())
            {
                try
                {
                    employee = db.M_Employees.Single(x => x.EmID == M_EmID);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundEmployee, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                }
                db.M_Employees.Remove(employee);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                }

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Employee",
                    Command = "Delete",
                    Data = employee.EmID.ToString(),
                    Comments = string.Empty
                };
                //StaticCommon.PostOperationLog(operationLog);
            }
        }



    }
}
