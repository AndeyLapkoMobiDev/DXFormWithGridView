using DevExpress.Web.Mvc;
using DXFormWithGridView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXFormWithGridView.Controllers
{
    public class RecipesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MasterDetailRecipeIngredients(int recipeId)
        {
            ViewData["recipeId"] = recipeId;

            var model = Data.Recipes
                .Where(r => r.Id == recipeId)
                .SelectMany(r => r.RecipeIngredients)
                .ToList();

            return PartialView("_MasterDetailRecipeIngredients", model);
        }

        [ValidateInput(false)]
        public ActionResult RecipesGridViewPartial()
        {
            return PartialView("_RecipesGridViewPartial", Data.Recipes);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RecipesGridViewPartialAddNew(Recipe item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Data.Recipes.Add(item);
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

            ViewData["EditableProduct"] = item;

            return PartialView("_RecipesGridViewPartial", Data.Recipes);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RecipesGridViewPartialUpdate(Recipe item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = Data.Recipes.FirstOrDefault(i => i.Id == item.Id);
                    if (modelItem != null)
                    {
                        var index = Data.Recipes.IndexOf(modelItem);
                        Data.Recipes[index] = item;
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

            ViewData["EditableProduct"] = item;

            return PartialView("_RecipesGridViewPartial", Data.Recipes);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RecipesGridViewPartialDelete(int Id)
        {
            var model = new object[0];
            if (Id >= 0)
            {
                try
                {
                    var item = Data.Recipes.FirstOrDefault(i => i.Id == Id);
                    if (item != null)
                    {
                        Data.Recipes.Remove(item);
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_RecipesGridViewPartial", Data.Recipes);
        }
    }
}