using EasyCrudNET.Mappers.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EasyCrudNET.Examples
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        [Field("CreatedAt")] //Map the property 'CreationDate' with field 'CreatedAt'
        public DateTime CreationDate { get; set; }
    }
}
