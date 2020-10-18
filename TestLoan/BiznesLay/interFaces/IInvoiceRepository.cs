using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestLoan.Entity;

namespace TestLoan.BiznesLay.interFaces
{
    public interface IInvoiceRepository:ICRUD<Invoice>
    {
        bool DeleteLoanInvoice(int loanId);
    }
}
