using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLoan.Entity
{
    public class Invoice: IEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public int InvoiceNr { get; set; }
        public int OrderNr { get; set; }

        public int LoanId { get; set; }
    }
}
