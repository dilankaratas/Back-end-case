using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCase.Models.Entities
{
    public class UserContact
    {
        [Key]
        public int Id { get; set; }
        public int UUID { get; set; }
        public int ContactID { get; set; }
    }
}
