using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;

namespace PersonnelApp
{
    public class Emploee
    {
        public int Id { get; set; }

        //[Required]
        public string Name { get; set; }

        public string FamilyName { get; set; }

        public string ThirdName { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string PhoneHome { get; set; }

        public string PhoneMobile { get; set; }

        public string Address { get; set; }

        public Department Department { get; set; }
    }
}
