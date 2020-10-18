using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestLoan.BiznesLay.interFaces;
using TestLoan.Entity;
using TestLoan.UIModel;

namespace TestLoan.BiznesLay.ConcreateRepository
{
    public class LoanRepository:CRUD<Loan>,ILoanRepository
    {
        public List<UILoanJoinClientName> getAllLoansWithClinetName()
        {
            return Reader<UILoanJoinClientName>("Select l.* , c.Name as ClientName, c.SurName as ClientSurName  from Loan l left Join Client c on l.ClientId=c.Id ");
        }

        public List<Client> getAllClients()
        {
            return Reader<Client>("Select * from Client");
        }
    }
}
