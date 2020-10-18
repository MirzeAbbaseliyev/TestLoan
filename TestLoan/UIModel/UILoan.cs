using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestLoan.Entity;

namespace TestLoan.UIModel
{
    public class UILoan
    {
        public List<SelectListItem> Clients { get; set; }
        public Loan Loan { get; set; }
        public List<Invoice> Invoices { get; set; }
        public UILoan()
        {
            Clients = new List<SelectListItem>();
            Invoices = new List<Invoice>();
        }
    }
}
