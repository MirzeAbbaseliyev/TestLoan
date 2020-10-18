using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestLoan.UIModel;

namespace TestLoan.BiznesLay.interFaces
{
    public interface ILoanRepository:ICRUD<Entity.Loan>
    {
        List<UILoanJoinClientName> getAllLoansWithClinetName();
        List<Entity.Client> getAllClients();
    }
}
