using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using Microsoft.Ajax.Utilities;

namespace UnitedReporting.UI.Areas.Admin.Controllers
{
    public class ImageViewModel
    {
        public string Url { get; set; }
    }

    public enum ImageType { PageImage, ContentImage }

    public class ImageManagerController : Controller
    {
        private const string PageImagePath = "~/Content/page-images/";
        private const string ContentImagePath = "~/Content/content-images/";
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Images()
        {
            var appData = Server.MapPath("~/Content/page-images");

            var images = Directory.GetFiles(appData).Select(x => new ImageViewModel
            {
                Url = Url.Content("~/Content/page-images/" + Path.GetFileName(x))
            });
            return PartialView(images);
        }

        public ActionResult ImageModal()
        {
            var appData = Server.MapPath("~/Content/page-images");

            var images = Directory.GetFiles(appData).Select(x => new ImageViewModel
            {
                Url = Url.Content("~/Content/page-images/" + Path.GetFileName(x))
            });
            return View(images);
        }

        public ActionResult UploadPageImage()
        {
            return View();
        }

        //
        // POST: /Admin/ImageManager/Create

        [HttpPost]
        public ActionResult UploadPageImage(HttpPostedFileBase Filedata)
        {
            UploadFile(Filedata, ImageType.PageImage);
            return RedirectToAction("UploadPageImage"); 
        }

        private void UploadFile(HttpPostedFileBase fileData, ImageType imageType)
        {
            var appData = string.Empty;
            switch (imageType)
            {
                case ImageType.PageImage:
                    appData = Server.MapPath(PageImagePath);
                    break;
                case ImageType.ContentImage:
                    appData = Server.MapPath(ContentImagePath);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("imageType");
            }

            // Verify that the user selected a file
            if (fileData != null && fileData.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(fileData.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(appData, fileName);
                fileData.SaveAs(path);
            }
        }

        [HttpPost]
        public void DeleteImage(string imagePath)
        {
            System.IO.File.Delete(Server.MapPath(imagePath));
        }
    }
}
