using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Models;
using WebAppMVC.ViewModels;
using System.Data.Entity;

namespace WebAppMVC.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var viewMod = new CustomerFormViewModel
            {
                Customer = new Customer { },
                MembershipTypes = GetMembershipTypes()
            };
            return View("CustomerForm", viewMod);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewMod = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = GetMembershipTypes()
                };
                return View("CustomerForm", viewMod);
            }
            //if the form has no id means that we're creating a new customer, else we update existing customer
            if(customer.id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerDB = GetSingleCustomer(customer.id);
                customerDB.name = customer.name;
                customerDB.BirthDate = customer.BirthDate;
                customerDB.MembershipTypeId = customer.MembershipTypeId;
                customerDB.IsSubscribed = customer.IsSubscribed;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = GetSingleCustomer(id);
            if (customer == null)
                HttpNotFound();
            var viewMod = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = GetMembershipTypes()
            };
            return View("CustomerForm", viewMod);
        }
        // GET: Customers
        public ActionResult Index()
        {
            return View(GetCustomers());
        }


        public Customer GetSingleCustomer(int id)
        {
            return GetCustomers().Single(x => x.id == id);
        }
        
        public List<MembershipType> GetMembershipTypes()
        {
            return _context.MembershipTypes.ToList();
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.Include(c => c.MembershipType).ToList();
        }
    }
}