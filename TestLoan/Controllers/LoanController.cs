using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestLoan.BiznesLay.interFaces;
using TestLoan.Entity;
using TestLoan.UIModel;

namespace TestLoan.Controllers
{
    public class LoanController : Controller
    {
        public LoanController(ILoanRepository repository, IInvoiceRepository ınvoiceRepository)
        {
            Repository = repository;
            InvoiceRepository = ınvoiceRepository;
        }

        public ILoanRepository Repository { get; }
        public IInvoiceRepository InvoiceRepository { get; }

        public IActionResult AllLoan()
        {
            var model = Repository.getAllLoansWithClinetName();
            return View(model);
        }
        

        public IActionResult Add()
        {
            var model = new UILoan();
            var c = Repository.getAllClients();
            if (c.Count > 0)
                foreach (var item in c)
                {
                    model.Clients.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem(item.Name, item.Id.ToString()));
                }
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(UILoan model)
        {
            var LoanId = Repository.Insert(model.Loan);

            if (LoanId > 0)
            {
                var l = Calculate(model.Loan.Amount, model.Loan.InterestRate,
                    model.Loan.LoanPeriod, model.Loan.PayloadDate, LoanId);
                foreach (var item in l)
                {
                    InvoiceRepository.Insert(item);
                }
            }

            return RedirectToAction("AllLoan");
        }


        public IActionResult Update(int id)
        {
            var loan = Repository.GetById(id);
            var model = new UILoan();
            model.Loan = loan.FirstOrDefault();
            var c = Repository.getAllClients();
            var invoive = Repository.Reader<Invoice>($"Select * from Invoice i where i.LoanId={id} ");
            model.Invoices.AddRange(invoive);
            if (c.Count > 0)
                foreach (var item in c)
                {
                    model.Clients.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem(item.Name, item.Id.ToString()));
                }
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UILoan model)
        {
            var b=Repository.Update(model.Loan, model.Loan.Id);
            if (b)
            {
                InvoiceRepository.DeleteLoanInvoice(model.Loan.Id);
                var l = Calculate(model.Loan.Amount, model.Loan.InterestRate,
                   model.Loan.LoanPeriod, model.Loan.PayloadDate, model.Loan.Id);
                foreach (var item in l)
                {
                    InvoiceRepository.Insert(item);
                }
            }
            return RedirectToAction("AllLoan");
        }

        public IActionResult Cancle(int id)
        {
            return RedirectToAction("AllLoan");
        }



        List<Invoice> Calculate(decimal amount, decimal rate, int period, DateTime date,int loanId)
        {
            List<Invoice> l = new List<Invoice>();
            decimal d = 0;decimal t = 0;
            for (int i = 1; i <= period; i++)
            {
                d = (period - i + 1)*amount/ period;               
                t = amount / period + (rate * d) / 100;
                date = date.AddMonths(1);
                l.Add(new Invoice() {
                    Amount = t,DueDate=date,OrderNr=i,LoanId=loanId
                });
            }
            return l;
        }
    }
}