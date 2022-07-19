using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCrudNET.Examples
{
    public class ModifyTableFromDatabase
    {
        public void Test()
        {
            EasyCrud easyCrud = new EasyCrud();
            easyCrud.SetSqlConnection("ConnectionString");
                
            int rowsAffectedInsert = easyCrud
                .Insert()
                .Into("your_table")
                .Values("@scalarVariable1", "@scalarVariable2")
                .BindValues(new
                {
                    scalarVariable1 = "a",
                    scalarVariable2 = "b"
                })
                .SaveChanges();

            int rowsAffectedUpdate = easyCrud
                .Update("your_table")
                .Set("field1", "@scalarVariable1")
                .Set("field2", "@scalarVariable2")
                .Where("field3", "@scalarVariable3")
                .BindValues(new
                {
                    scalarVariable1 = "a",
                    scalarVariable2 = "b",
                    scalarVariable3 = "c"
                })
                .SaveChanges();

            int rowsAffectedDelete = easyCrud
                .Delete()
                .From("your_table")
                .Where("field", "@scalarVariable1")
                .BindValues(new
                {
                    scalarVariable1 = "Scalar value"
                })
                .SaveChanges();
        }
    }
}
