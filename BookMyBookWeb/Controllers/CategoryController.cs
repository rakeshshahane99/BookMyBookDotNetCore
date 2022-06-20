using BookMyBookWeb.Data;
using BookMyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db)
        {
            _db=db;
        }
        public IActionResult Index()
        {
            IEnumerable <Category> objcategoryList= _db.Categories;
            return View(objcategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display order can not be same as Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj); 
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            return View(categoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display order can not be same as Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj); ;
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var CategoriesFromDB = _db.Categories.Find(id);

            return View(CategoriesFromDB);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}
