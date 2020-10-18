using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestLoan.Entity;

namespace TestLoan.UIModel
{
    public class UILoanJoinClientName
    {
        public int Id { get; set; }
        
        public decimal Amount { get; set; }
        
        public decimal InterestRate { get; set; }
        public int LoanPeriod { get; set; }
       
        public DateTime PayloadDate { get; set; }
        
        public int ClientId { get; set; }

        public string ClientName { get; set; }
        public string ClientSurName { get; set; }
    }
}
