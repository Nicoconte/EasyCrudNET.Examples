using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EasyCrudNET;

namespace EasyCrudNET.Examples.SqlBuilder
{
    public class FetchDataFromDatabase
    {
        public void Example()
        {
            EasyCrud easyCrud = new EasyCrud();

            easyCrud.SetSqlConnection("ConnectionString");

            easyCrud
                .Select("fields", "you", "want") //Fields should match with the property name or map the property in order to map the entity
                .From("Your table")
                .Where("fieldname", "@scarlarVariable")
                .BindValues(new
                {
                    scalarVariable = "Scalar value"
                })
                .DebugQuery() //Show the query
                .ExecuteQuery()
                .GetResult();

            easyCrud
                .Select("fields", "you", "want")
                .From("Your table")
                .Where("fieldname", "@scarlarVariable")
                .BindValues(new
                {
                    scalarVariable = "Scalar value"
                })
                .ExecuteQuery()
                .MapResultTo<UserEntity>();

            easyCrud
                .Select("fields", "you", "want")
                .From("Your table")
                .Where("fieldname", "@scarlarVariable")
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
