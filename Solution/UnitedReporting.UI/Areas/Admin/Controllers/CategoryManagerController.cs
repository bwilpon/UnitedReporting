using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UnitedReporting.DataAccess;
using UnitedReporting.Model;

namespace UnitedReporting.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoryManagerController : Controller
    {
        private readonly IGenericDataRepository<Category> _repository;

        public CategoryManagerController()
        {
            _repository = new GenericDataRepository<Category>();
        }

        //
        // GET: /Admin/CategoryManager/

        public ActionResult Index()
        {
            IEnumerable<Category> categories = _repository.GetAll().OrderBy(c => c.Sequence);
            
            return View(categories);
        }

        //
        // GET: /Admin/CategoryManager/Create

        public ActionResult Create(int id = default(int))
        {
            Category category = null;

            if (id != default(int))
            {
                // Get Page from Database
                category = _repository.GetSingle(c => c.Id == id);
            }

            return View(category);
        }

        //
        // POST: /Admin/CategoryManager/Create

        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                if (category.Id == default(int))
                {
                    _repository.Add(category);
                }
                else
                {
                    _repository.Update(category);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/CategoryManager/Delete/5

        public ActionResult Delete(int id)
        {
            _repository.Remove(_repository.GetSingle(c => c.Id == id));
            return null;
        }

        public void UpdateOrder(int id, int fromPosition, int toPosition, string direction)
        {
            if (direction == "back")
            {
                var movedCompanies = _repository.GetAll()
                            .Where(c => (toPosition <= c.Sequence && c.Sequence <= fromPosition))
                            .ToList();

                foreach (var company in movedCompanies)
                {
                    company.Sequence++;
                }
            }
            else
            {
                var movedCompanies = _repository.GetAll()
                            .Where(c => (fromPosition <= c.Sequence && c.Sequence <= toPosition))
                            .ToList();
                foreach (var company in movedCompanies)
                {
                    company.Sequence--;
                }
            }

            _repository.GetAll().First(c => c.Id == id).Sequence = toPosition;
        }

    }
}
