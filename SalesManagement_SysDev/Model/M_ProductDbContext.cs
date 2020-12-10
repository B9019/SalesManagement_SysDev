using SalesManagement_SysDev.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace SalesManagement_SysDev.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class M_ProductDbContext : DbContext
    {
        // コンテキストは、アプリケーションの構成ファイル (App.config または Web.config) から 'M_ProductDbContext' 
        // 接続文字列を使用するように構成されています。既定では、この接続文字列は LocalDb インスタンス上
        // の 'SalesManagement_SysDev.Model.M_ProductDbContext' データベースを対象としています。 
        // 
        // 別のデータベースとデータベース プロバイダーまたはそのいずれかを対象とする場合は、
        // アプリケーション構成ファイルで 'M_ProductDbContext' 接続文字列を変更してください。
        public M_ProductDbContext()
            : base("name=M_ProductDbContext1")
        {
        }

        // モデルに含めるエンティティ型ごとに DbSet を追加します。Code First モデルの構成および使用の
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=390109 を参照してください。

        //public DbSet<M_Product> M_Products { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}