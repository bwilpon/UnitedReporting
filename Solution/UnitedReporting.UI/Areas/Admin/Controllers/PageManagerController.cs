using System.Collections.Generic;
using System.Web.Mvc;
using UnitedReporting.DataAccess;
using UnitedReporting.Model;
using System.Linq;

namespace UnitedReporting.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class PageManagerController : Controller
    {
        //
        // GET: /Admin/Page/

        public ActionResult Index()
        {
            IGenericDataRepository<PageContent> repository = new GenericDataRepository<PageContent>();
            IList<PageContent> pages = repository.GetAll(p => p.Category).OrderBy(p => p.CategoryId).ToList();
            return View(pages);
        }

        //
        // GET: /Admin/Page/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Page/Create

        public ActionResult Create(int id = default(int))
        {
            PageContent page = null;

            if (id != default(int))
            {
                // Get Page from Database
                IGenericDataRepository<PageContent> repository = new GenericDataRepository<PageContent>();
                page = repository.GetSingle(p => p.Id == id);
                
                PopulateCategoriesDropDownList(page.CategoryId);
            }
            
            return View(page);
        }

        //
        // POST: /Admin/Page/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(PageContent model)
        {
            try
            {
                IGenericDataRepository<PageContent> pageRepository = new GenericDataRepository<PageContent>();
                if (model.Id == default(int))
                {
                    pageRepository.Add(model);
                }
                else
                {
                    pageRepository.Update(model);
                }
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Page/Edit/5

        //public ActionResult Edit(int id = default(int))
        //{
        //    PageContent page = null;

        //    if (id != default(int))
        //    {
        //        // Get Page from Database
        //        IGenericDataRepository<PageContent> repository = new GenericDataRepository<PageContent>();
        //        page = repository.GetSingle(p => p.Id == id);
        //    }

        //    return View(page);
        //}

        ////
        //// POST: /Admin/Page/Edit/5

        //[HttpPost]
        //public ActionResult Edit(PageContent model)
        //{
        //    try
        //    {
        //        IGenericDataRepository<PageContent> repository = new GenericDataRepository<PageContent>();
        //        repository.Add(model);
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}


        [HttpPost]
        public ActionResult Delete(int id)
        {
            IGenericDataRepository<PageContent> repository = new GenericDataRepository<PageContent>();
            repository.Remove(repository.GetSingle(p => p.Id == id));
            return null;
        }

        private void PopulateCategoriesDropDownList(object selectedCategory = null)
        {
            IGenericDataRepository<Category> categoryRepository = new GenericDataRepository<Category>();
            var categories = categoryRepository.GetAll();

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", selectedCategory);
            
        }
    }
}
