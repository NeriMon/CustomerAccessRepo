using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pointwest.CustomerAccess.Web.Models
{
    public class CustomerViewModel
    {
        public int ID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}