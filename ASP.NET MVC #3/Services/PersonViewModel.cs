using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_MVC__3.Services
{
    public class PersonViewModel
    {
        [DisplayName("Full Name")]
        public string? FullName { get; set; }

        [DisplayName("Date Of Birth")]
        public string? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }

        [DisplayName("Birth Place")]
        public string? BirthPlace { get; set; }
        public int Age { get; set; }
    }
}