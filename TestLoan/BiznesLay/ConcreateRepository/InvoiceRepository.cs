using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestLoan.BiznesLay.interFaces;
using TestLoan.Entity;

namespace TestLoan.BiznesLay.ConcreateRepository
{
    public class InvoiceRepository:CRUD<Invoice>, IInvoiceRepository
    {
        public bool DeleteLoanInvoice(int loanId)
        {
           return NonQuery($"Delete Invoice where LoanId={loanId}");
        }
    }
}
