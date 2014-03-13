using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitedReporting.Model;

namespace UnitedReporting.UI.Areas.Admin.Controllers
{
    public class ErrorsController : Controller
    {
        //
        // GET: /Admin/Errors/

        public ActionResult Index()
        {
            var errorContext = new ElmahEntities();
            errorContext.Set<ELMAH_Error>();

            List<ELMAH_Error> errors;
            using (var context = new UnitedReporting.Model.ElmahEntities())
            {
                IQueryable<ELMAH_Error> dbQuery = context.Set<ELMAH_Error>();
                errors = dbQuery
                    .AsNoTracking()
                    .OrderByDescending(e => e.TimeUtc)
                    .Take(50)
                    .ToList();
            }

            return View(errors);
        }

        //
        // GET: /Admin/Errors/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Errors/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Errors/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Errors/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Errors/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Errors/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Errors/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
