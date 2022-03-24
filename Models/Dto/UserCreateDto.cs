using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCase.Models.Dto
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
    }
}
