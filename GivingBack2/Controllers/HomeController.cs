using GivingBack2.Models;
using GivingBack2.Models.EntityManager;
using GivingBack2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GivingBack2.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult ChooseCategory(HomeIndexViewModel homeIndexViewModel)
		{
			ViewBag.SelectedCategoryId = homeIndexViewModel.SelectedCategoryId;
			//SelectedCategoryId-1 because in db, IDs start from 1
			ViewBag.SelectedCategoryName = HomeIndexViewModel.CategoryList[(int)homeIndexViewModel.SelectedCategoryId-1].CategoryName;

			var chooseCategoryViewModel = new ChooseCategoryViewModel();
			chooseCategoryViewModel.SelectedCategoryId = homeIndexViewModel.SelectedCategoryId;
			chooseCategoryViewModel.SelectedCategoryName = HomeIndexViewModel.CategoryList[(int)homeIndexViewModel.SelectedCategoryId-1].CategoryName;

			return View(chooseCategoryViewModel);
		}

		public ActionResult SpecifyParameters(ChooseCategoryViewModel chooseCategoryViewModel)
		{
			var c1 = HomeIndexViewModel.CategoryList.First((c) => c.CategoryId == chooseCategoryViewModel.SelectedCategoryId);
			ViewBag.SelectedCategory = c1.CategoryId;
			ViewBag.SelectedCategoryName = c1.CategoryName;
			ViewBag.ResourceType = chooseCategoryViewModel.SelectedResource;

			SpecifyParametersViewModel specifyParametersViewModel = new SpecifyParametersViewModel();
			specifyParametersViewModel.SelectedCategoryName = c1.CategoryName;
			specifyParametersViewModel.SelectedcategoryId = c1.CategoryId;
			specifyParametersViewModel.SelectedResource = chooseCategoryViewModel.SelectedResource;
			return View(specifyParametersViewModel);
		}

		[HttpPost]
		public ActionResult RequirementsPage(SpecifyParametersViewModel specifyParameterViewModel)
		{
			ViewBag.ResourceType = specifyParameterViewModel.SelectedResource;
			ViewBag.SelectedCategoryName = specifyParameterViewModel.SelectedCategoryName;

			RequirementManager RM = new RequirementManager();
			List<MappedRequirementViewModel> mappedRequirementViewModel = new List<MappedRequirementViewModel>();

			if (specifyParameterViewModel.SelectedResource == ResourceTypes.Money)
			{
				mappedRequirementViewModel = RM.MoneyRequirementMapping(specifyParameterViewModel);
			}
			else if (specifyParameterViewModel.SelectedResource == ResourceTypes.Product)
			{
				mappedRequirementViewModel = RM.ProductRequirementMapping(specifyParameterViewModel);
			}
			else if (specifyParameterViewModel.SelectedResource == ResourceTypes.Time)
			{
				mappedRequirementViewModel = RM.TimeRequirementMapping(specifyParameterViewModel);
			}
			if (mappedRequirementViewModel.FirstOrDefault().resultsFound == false)
			{
				return RedirectToAction("Results", "Home", new { resultsFound = mappedRequirementViewModel.FirstOrDefault().resultsFound });
			}
			return View(mappedRequirementViewModel);
		}

		public ActionResult Results(MappedRequirementViewModel results)
		{
			//if (results.SelectedResource == ResourceTypes.Money)
			//{

			//}
			//else if(results.SelectedResource==ResourceTypes.Product)
			//{

			//} else if(results.SelectedResource == ResourceTypes.Time)
			//{

			//}
			return View(results);
		}

		[AllowAnonymous]
		public ActionResult About()
		{
			//ViewBag.Message = "Your application description page.";
			return View();
		}

		[AllowAnonymous]
		public ActionResult Contact()
		{
			//ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}