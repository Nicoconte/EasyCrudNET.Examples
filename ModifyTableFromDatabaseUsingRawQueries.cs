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
                .BindValues(new
                {
                    scalarVariable1 = "a",
                    scalarVariable2 = "b"
                })
                .SaveChangesRawQuery("insert into your_table values(@scalarVariable1, @scalarVariable2)");

            int rowsAffectedUpdate = easyCrud
                .BindValues(new
                {
                    scalarVariable1 = "a",
                    scalarVariable2 = "b",
                    scalarVariable3 = "c"
                })
                .SaveChangesRawQuery("update your_table set field=@scalarVariable1, field=@scalarVariable2 where condition=@scalarVariable3");

            int rowsAffectedDelete = easyCrud
                .BindValues(new
                {
                    scalarVariable1 = "Scalar value"
                })
                .SaveChangesRawQuery("delete from your_table where field=@scalarVariable1");
        }
    }
}
