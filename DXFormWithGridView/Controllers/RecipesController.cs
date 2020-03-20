using DevExpress.Web.Mvc;
using DXFormWithGridView.Models;
using System;
using System.Linq;
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

        #region Recipes

        [ValidateInput(false)]
        public ActionResult RecipesGridView()
        {
            return PartialView("_RecipesGridView", Data.Recipes);
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

            return RecipesGridView();
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

            return RecipesGridView();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RecipesGridViewPartialDelete(int Id)
        {
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

            return RecipesGridView();
        }

        #endregion
        
        #region RecipeIngredients

        public ActionResult RecipeIngredientsGridView(int recipeId = -1)
        {
            ViewData["recipeId"] = recipeId;

            var model = Data.Recipes
                .Where(r => r.Id == recipeId)
                .SelectMany(r => r.RecipeIngredients)
                .ToList();

            return PartialView("_RecipeIngredientsGridView", model);
        }

        public ActionResult RecipeIngredientsBatchUpdate(MVCxGridViewBatchUpdateValues<RecipeIngredient, object> updateValues, int recipeId = -1)
        {
            if (ModelState.IsValid)
            {
                //DataContext.UpdateOrderItems(updateValues.Update, orderId);
                //DataContext.InsertOrderItems(updateValues.Insert, orderId);
                //DataContext.RemoveOrderItems(updateValues.DeleteKeys, orderId);
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }

            return RecipeIngredientsGridView(recipeId);
        }

        #endregion
    }
}