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
			ViewBag.SelectedCategoryName = HomeIndexViewModel.CategoryList[homeIndexViewModel.SelectedCategoryId].CategoryName;

			var chooseCategoryViewModel = new ChooseCategoryViewModel();
			chooseCategoryViewModel.SelectedCategoryId = homeIndexViewModel.SelectedCategoryId;
			chooseCategoryViewModel.SelectedCategoryName = HomeIndexViewModel.CategoryList[homeIndexViewModel.SelectedCategoryId].CategoryName;

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
			RequirementManager RM = new RequirementManager();
			MappedRequirementViewModel mappedRequirementViewModel = new MappedRequirementViewModel();

			if(specifyParameterViewModel.SelectedResource == ResourceTypes.Money)
			{
				mappedRequirementViewModel = RM.MoneyRequirementMapping(specifyParameterViewModel);
			}
			else if(specifyParameterViewModel.SelectedResource == ResourceTypes.Product)
			{
				mappedRequirementViewModel = RM.ProductRequirementMapping(specifyParameterViewModel);
			}
			else if (specifyParameterViewModel.SelectedResource == ResourceTypes.Time)
			{
				mappedRequirementViewModel = RM.TimeRequirementMapping(specifyParameterViewModel);
			}
			return View(mappedRequirementViewModel);

		public ActionResult Results(SpecifyParametersViewModel specifyParametersViewModel)
		{
			var c1 = HomeIndexViewModel.CategoryList.First((c) => c.CategoryId == specifyParametersViewModel.SelectedcategoryId);
			ViewBag.SelectedCategory = c1.CategoryId;
			ViewBag.SelectedCategoryName = c1.CategoryName;
			ViewBag.ResourceType = specifyParametersViewModel.SelectedResource;
			
			return View();
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