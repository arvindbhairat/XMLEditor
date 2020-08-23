using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using XMLEditor.Models;

namespace XMLEditor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase xmlFile)
        {
            try
            {
                if (xmlFile.ContentLength > 0)
                {
                    string filePath = Path.Combine(Server.MapPath("~/uploads"), Path.GetFileName(xmlFile.FileName));
                    xmlFile.SaveAs(filePath);
                    return RedirectToAction(string.Empty, "Editor", new { fileName = Path.GetFileNameWithoutExtension(filePath) });
                }
                else
                {
                    throw new ApplicationException("File size is 0!");
                }
            }
            catch (Exception error)
            {
                ViewBag.UploadError = "File upload failed, " + error.Message;
                return View("Index");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}