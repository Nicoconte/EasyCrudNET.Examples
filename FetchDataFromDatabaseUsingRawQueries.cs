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
                .FromSql("select * from your_table where field=@scalarVariable")
                .BindValues(new
                {
                    scalarVariable = "Scalar value"
                })
                .ExecuteQuery()
                .GetResult();

            easyCrud
                .FromSql("select * from your_table where field=@scalarVariable")
                .BindValues(new
                {
                    scalarVariable = "Scalar value"
                })
                .ExecuteQuery()
                .MapResultTo<UserEntity>();

            easyCrud
                .FromSql("select * from your_table where field=@scalarVariable")
                .BindValues(new
                {
                    scalarVariable = "Scalar value"
                })
                .ExecuteQuery()
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
