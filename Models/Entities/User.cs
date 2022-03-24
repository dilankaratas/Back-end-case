using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace BackEndCase.Models.Entities
{
    public class User
    {
        [Key]
        public int UUID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        //public Contact[]? Contacts { get; set; }
    }
}