using QALibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QALibrary.Controllers
{
    public class BooksController : Controller
    {
        private IBooksRepository repository;

        public BooksController(IBooksRepository repository)
        {
            this.repository = repository;
        }
        public BooksController()
            :this(new SQLBooksRepository())
        { }


        public ActionResult Index()
        {
            return View(repository.GetAllBooks());
        }
    }
}