using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCase.Models.Dto
{
    public class ContactCreateDto
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}
