using MovieCustomerMvcAppWithAuthentication.Models;
using MovieCustomerMvcAppWithAuthentication.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieCustomerMvcAppWithAuthentication.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();

            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var singleCustomer = _context.Customers.Include(c=>c.MembershipType). SingleOrDefault(c => c.Id == id);
            if (singleCustomer == null)
                return HttpNotFound();
            return View(singleCustomer);
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Customer customer)//Model Binding
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}