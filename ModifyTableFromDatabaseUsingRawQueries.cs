using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCrudNET.Examples
{
    public class ModifyTableFromDatabaseUsingRawQueries
    {
        public void Test()
        {
            EasyCrud easyCrud = new EasyCrud();
            easyCrud.SetSqlConnection("ConnectionString");

            int rowsAffectedInsert = easyCrud
                .FromSql("insert into your_table values(@scalarVariable1, @scalarVariable2)")
                .BindValues(new
                {
                    scalarVariable1 = "a",
                    scalarVariable2 = "b"
                })
                .SaveChanges();

            int rowsAffectedUpdate = easyCrud
                .FromSql("update your_table set field=@scalarVariable1, field=@scalarVariable2 where condition=@scalarVariable3")
                .BindValues(new
                {
                    scalarVariable1 = "a",
                    scalarVariable2 = "b",
                    scalarVariable3 = "c"
                })
                .SaveChanges();

            int rowsAffectedDelete = easyCrud
                .FromSql("delete from your_table where field=@scalarVariable1")
                .BindValues(new
                {
                    scalarVariable1 = "Scalar value"
                })
                .SaveChanges();
        }
    }
}
