using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevBridge.Templates.WebProject.Web.Helpers;
using DevBridge.Templates.WebProject.Web.Logic.Commands.Article.GetArticles;
using DevBridge.Templates.WebProject.Web.Logic.Models.Article;

namespace DevBridge.Templates.WebProject.Web.Controllers
{
    public partial class ArticleController : Tools.Mvc.ExtendedControllerBase
    {
        //
        // GET: /Article/

        public virtual ActionResult Index()
        {
            var model = GetCommand<GetArticlesCommand>().ExecuteCommand(GetFilter());
            return View(model);
        }

        private GetArticlesFilterViewModel GetFilter()
        {
            var result = new GetArticlesFilterViewModel();
            return result;
        }

        //
        // GET: /Article/Details/5

        public virtual ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Article/Create

        public virtual ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Article/Create

        [HttpPost]
        public virtual ActionResult Create(FormCollection collection)
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
        // GET: /Article/Edit/5

        public virtual ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Article/Edit/5

        [HttpPost]
        public virtual ActionResult Edit(int id, FormCollection collection)
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
        // GET: /Article/Delete/5

        public virtual ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Article/Delete/5

        [HttpPost]
        public virtual ActionResult Delete(int id, FormCollection collection)
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
