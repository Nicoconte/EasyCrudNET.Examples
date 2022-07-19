using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EasyCrudNET;

namespace EasyCrudNET.Examples
{
    public class FetchDataFromDatabaseUsingRawQueries
    {
        public void Test()
        {
            EasyCrud easyCrud = new EasyCrud();

            easyCrud.SetSqlConnection("ConnectionString");

            easyCrud
                .BindValues(new
                {
                    scalarVariable = "Scalar value"
                })
                .ExecuteRawQuery("select * from your_table where field=@scalarVariable")
                .GetResult();

            easyCrud
                .BindValues(new
                {
                    scalarVariable = "Scalar value"
                })
                .ExecuteRawQuery("select * from your_table where field=@scalarVariable")
                .MapResultTo<UserEntity>();

            easyCrud
                .BindValues(new
                {
                    scalarVariable = "Scalar value"
                })
                .ExecuteRawQuery("select * from your_table where field=@scalarVariable")
                .MapResultTo<UserEntity>(c =>
                {
                    return new UserEntity()
                    {
                        Id = int.Parse(c[0].FieldValue.ToString()),
                        Name = c[1].FieldValue.ToString(),
                        Password = c[2].FieldValue.ToString(),
                        CreationDate = DateTime.Parse(c[3].FieldValue.ToString()),
                    };
                });

        }
    }
}
