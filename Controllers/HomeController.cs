using RecipeWebApp.Models;
using RecipeWebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace RecipeWebApp.Controllers
{
    public class HomeController : Controller
    {
        RecipeDBEntities db = new RecipeDBEntities();

        // Welcome Screen
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Recipes()
        {

            //select all recipe records
            var recipeRecords = from r in db.Recipe
                                select r;

            // NOT SURE WHY THIS WORKS IN DEPLOYMENT
            List<Recipe> rR = recipeRecords.ToList();
           
            foreach (var recipe in rR)
            {
                recipe.iCount = recipe.Ingredient.Count;
                recipe.mCount = recipe.Method.Count;
            }
            // STOPS ERORR 
            return View(recipeRecords);
        }
        
        // Load record into the details modal
        public ActionResult _details(int id)
        {
            Recipe record = db.Recipe.Find(id);
            return PartialView(record);
        }
        // Load record into the remove modal
        public ActionResult _remove(int id)
        {
            Recipe record = db.Recipe.Find(id);
            return PartialView(record);
        }

        // Delete from database
        [HttpPost, ActionName("_remove")]
        public ActionResult RemoveRecord(int id)
        {
                // Remove Recipe
                Recipe record = db.Recipe.Find(id);
                db.Recipe.Remove(record);
                db.SaveChanges();
            return RedirectToAction("Recipes");
        }

        // Create a new Recipe send to View to fill out
        public ActionResult Add()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Add(Recipe nRecipe)
        {
            if(ModelState.IsValid)
            {
                db.Recipe.Add(nRecipe);
                db.SaveChanges();

                return JavaScript("location.reload(true)");
                //return RedirectToAction("Edit", new { id = nRecipe.RecipeId });
            }
            return PartialView("Add", nRecipe);
        }

        public PartialViewResult _addIngredient(int? RecipeId)
        {
            ViewBag.RecipeId = RecipeId;
            return PartialView();
        }

        [HttpPost]
        public ActionResult _addIngredient(Ingredient nIngredient)
        {
            if (ModelState.IsValid)
            {
                db.Ingredient.Add(nIngredient);
                db.SaveChanges();
                return JavaScript("location.reload(true)");
                //return RedirectToAction("Edit", new { id = nIngredient.RecipeId });
            }
            ViewBag.RecipeId = nIngredient.RecipeId;
            return PartialView("_addIngredient", nIngredient);
        }

        public ActionResult RemoveIngredientRecord(int id)
        {
            // Remove Recipe
            Ingredient irecord = db.Ingredient.Find(id);
            Recipe record = db.Recipe.Find(irecord.RecipeId);
            db.Ingredient.Remove(irecord);
            db.SaveChanges();
            return RedirectToAction("Edit", new { id = record.RecipeId });
        }

        public ActionResult RemoveMethodRecord(int id)
        {
            // Remove Recipe
            Method mrecord = db.Method.Find(id);
            Recipe record = db.Recipe.Find(mrecord.RecipeId);
            db.Method.Remove(mrecord);
            db.SaveChanges();
            return RedirectToAction("Edit", new { id = record.RecipeId });
        }

        public PartialViewResult _addMethod(int? RecipeId)
        {
            ViewBag.RecipeId = RecipeId;
            return PartialView();
        }

        [HttpPost]
        public ActionResult _addMethod(Method nMethod)
        {
            if (ModelState.IsValid)
            {
                db.Method.Add(nMethod);
                db.SaveChanges();
                return JavaScript("location.reload(true)");
                //return RedirectToAction("Edit", new { id = nMethod.RecipeId });
            }
            ViewBag.RecipeId = nMethod.RecipeId;
            return PartialView("_addMethod", nMethod);
    }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe record = db.Recipe.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        public ActionResult EditUpdate(Recipe record)
        {
            return View("Edit", record);
        }

        [HttpPost, ActionName("Edit")] // Edit record in database
        public ActionResult _editMethod(Recipe uRecipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uRecipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = uRecipe.RecipeId });
                //return JavaScript("location.reload(true);");
            }
            return RedirectToAction("EditUpdate", uRecipe);
        }

    }
}