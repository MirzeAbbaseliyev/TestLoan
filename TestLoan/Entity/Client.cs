using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLoan.Entity
{
    public class Client: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string TelePhoneNr { get; set; }

        
    }
}
