using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestLoan.BiznesLay.interFaces;
using TestLoan.Entity;

namespace TestLoan.BiznesLay.ConcreateRepository
{
    public class ClientRepository:CRUD<Client>,IClientRepository
    {
    }
}
