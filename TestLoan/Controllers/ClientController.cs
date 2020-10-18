using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestLoan.BiznesLay.interFaces;

namespace TestLoan.Controllers
{
    public class ClientController : Controller
    {
        public IClientRepository Repostory { get; }

        public ClientController(IClientRepository repostory)
        {
            Repostory = repostory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllClient()
        {
            var model=Repostory.GetAll();
            return View(model);
        }

        public IActionResult Update(int Id)
        {
            var model = Repostory.GetById(Id);
            return View("AllClient",model);
        }
    }
}