using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCrudNET.Examples
{
    public class TransactionsExecution
    {
        public void Test()
        {
            EasyCrud easyCrud = new EasyCrud();
            easyCrud.SetSqlConnection("ConnectionString");

            var success = easyCrud
                .BeginTransaction((queries) =>
                {
                    queries.Add(("insert into your_table values (@scalarVariable1, @scalarVariable2, @scalarVariable3)", new
                    {
                        scalarVariable1 = "a",
                        scalarVariable2 = "b",
                        scalarVariable3 = "c"
                    }));

                    queries.Add(("insert into your_table values (@scalarVariable11, @scalarVariable22, @scalarVariable33)", new
                    {
                        scalarVariable11 = "a",
                        scalarVariable22 = "b",
                        scalarVariable33 = "c"
                    }));

                    queries.Add(("insert into your_tables values ('1', GETDATE(), GETDATE(), GETDATE())", null));
                })
                .Commit();

        }
    }
}
