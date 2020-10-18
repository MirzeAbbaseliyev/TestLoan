using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestLoan.Entity
{
    public class Loan: IEntity
    {
        public int Id { get; set; }
        [Required]
        [Range(100, 5000)]
        public decimal Amount { get; set; }
        [Required]
        [Range(0, 90)]
        public decimal InterestRate { get; set; }
        public int LoanPeriod { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PayloadDate { get; set; }
        [Required]
        public int ClientId { get; set; }
    }
}
