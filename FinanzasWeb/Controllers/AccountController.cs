using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanzasWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasWeb.Controllers
{
    public class AccountController : Controller
    {
        private FinancistoContext _context;
        public AccountController(FinancistoContext context)
        {
            _context = context;
        }
        public ViewResult Index()//funciona con get y post
        {
           
           ViewBag.Accounts =_context.Accounts.ToList();
            return View("Index");
        }
        [HttpGet]
        public ActionResult Create()//funciona con get y post
        {
         
            return View("Create", new Account());
        }
        [HttpPost]
        public ActionResult Create(Account account)//funciona con get y post
        {
            //if(account.Name==null || account.Name == "")
            //{
            //    ModelState.AddModelError("Name1", " El campo nombre es requerido");
            //}
            if (ModelState.IsValid)
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View("Create",account);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Types = new List<string> { "Efectivo", "Debito" , "Credito" };
            ViewBag.Account =_context.Accounts.Where(o => o.id==id).FirstOrDefault();
            return View ("Edit");
        }
        [HttpPost]
        public ActionResult Edit( Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Accounts.Update(account);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit");
        }
        [HttpGet]
        public ActionResult delate(int id)
        {
           var account = _context.Accounts.Where(o => o.id == id).FirstOrDefault();
            _context.Accounts.Remove(account);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        /*public RedirectToActionResult save(Account account)//string Name, string Type, string Currency, decimal Amount)
        {
            //var account = new Account {  Type = Type, Name = Name, Currency = Currency, Amount = Amount };
            _context.Accounts.Add(account);
           // _context.SaveChanges();
            //return account.Type + " " + account.Name + " " + account.Currency + " " + account.Amount;
            return RedirectToAction("Index");
        }
         */
    }

    
}
    
