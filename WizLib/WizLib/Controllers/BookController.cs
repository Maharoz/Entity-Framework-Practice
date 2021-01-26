using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizLib_DataAccess.Data;
using WizLib_Model.Models;
using WizLib_Model.ViewModels;

namespace WizLib.Controllers
{
    public class BookController : Controller
    {

        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            List<Book> objList = _db.Books.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            BookVM obj = new BookVM();
            obj.PublisherList = _db.Publishers.Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = i.Name,
                Value = i.Publisher_Id.ToString()
            }); 
            if (id == null)
            {
                return View(obj);
            }

            obj.Book = _db.Books.FirstOrDefault(u => u.Book_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Book obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Book_Id == 0)
                {
                    _db.Books.Add(obj);
                }
                else
                {
                    _db.Books.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }


        public IActionResult Delete(int id)
        {
        
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple2()
        {

          
            return RedirectToAction(nameof(Index));
        }


        public IActionResult CreateMultiple5()
        {
           
            return RedirectToAction(nameof(Index));
        }


        public IActionResult RemoveMultiple2()
        {

           
            return RedirectToAction(nameof(Index));
        }


        public IActionResult RemoveMultiple5()
        {
           
            return RedirectToAction(nameof(Index));
        }


    }
}
