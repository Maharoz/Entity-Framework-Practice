using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizLib_DataAccess.Data;
using WizLib_Model.Models;

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

            List<Author> objList = _db.Authors.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            Author obj = new Author();
            if (id == null)
            {
                return View(obj);
            }

            obj = _db.Authors.FirstOrDefault(u => u.Author_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Author obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Author_Id == 0)
                {
                    _db.Authors.Add(obj);
                }
                else
                {
                    _db.Authors.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }


        public IActionResult Delete(int id)
        {
            var objFromDb = _db.Authors.FirstOrDefault(u => u.Author_Id == id);
            _db.Authors.Remove(objFromDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple2()
        {
            List<Author> catList = new List<Author>();
            for (int i = 1; i <= 2; i++)
            {
                catList.Add(new Author { FirstName = Guid.NewGuid().ToString() });
           
            }
            _db.Authors.AddRange(catList);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult CreateMultiple5()
        {
            List<Author> catList = new List<Author>();
            for (int i = 1; i <= 5; i++)
            {
                catList.Add(new Author { FirstName = Guid.NewGuid().ToString() });
           
            }
            _db.Authors.AddRange(catList);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult RemoveMultiple2()
        {
            IEnumerable<Author> catList = _db.Authors.OrderByDescending(u => u.Author_Id).Take(2).ToList();

            _db.Authors.RemoveRange(catList);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult RemoveMultiple5()
        {
            List<Author> catList = _db.Authors.OrderByDescending(u => u.Author_Id).Take(5).ToList();


            _db.Authors.RemoveRange(catList);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
