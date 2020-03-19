using DevExpress.Web.Mvc;
using DXFormWithGridView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXFormWithGridView.Controllers
{
    public class IngredientsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult IngredientsGridViewPartial()
        {
            return PartialView("_IngredientsGridViewPartial", Data.Ingredients);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult IngredientsGridViewPartialAddNew(Ingredient item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Data.Ingredients.Add(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }

            return PartialView("_IngredientsGridViewPartial", Data.Ingredients);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult IngredientsGridViewPartialUpdate(Ingredient item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = Data.Ingredients.FirstOrDefault(i => i.Id == item.Id);
                    if (modelItem != null)
                    {
                        var index = Data.Ingredients.IndexOf(modelItem);
                        Data.Ingredients[index] = item; 
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }

            return PartialView("_IngredientsGridViewPartial", Data.Ingredients);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult IngredientsGridViewPartialDelete(int Id)
        {
            if (Id >= 0)
            {
                try
                {
                    var item = Data.Ingredients.FirstOrDefault(i => i.Id == Id);
                    if (item != null)
                    {
                        Data.Ingredients.Remove(item);
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            return PartialView("_IngredientsGridViewPartial", Data.Ingredients);
        }
    }
}