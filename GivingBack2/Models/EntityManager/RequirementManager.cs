using GivingBack2.Models.DB;
using GivingBack2.ViewModels;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivingBack2.Models.EntityManager
{
	public class RequirementManager
	{
		public List<MappedRequirementViewModel> TimeRequirementMapping(SpecifyParametersViewModel specifyParametersViewModel)
		{
			List<MappedRequirementViewModel> mappedRequirementViewModel = new List<MappedRequirementViewModel>();

			// Business Logic here
			GiveBackDBEntities db = new GiveBackDBEntities();
			var tviewModel = new List<TimeReqViewModel>();

			var startTime = DateTime.Parse(specifyParametersViewModel.StartTime.SelectedTime.ToString());
			var resultsFromDB = (from a in db.OrgDetails
								 join b in db.Requirements on a.OrgId equals b.OrgId
								 join c in db.TimeResources on b.ReqId equals c.ReqId
								 where c.StartDate <= specifyParametersViewModel.StartDate
								 && c.EndDate >= specifyParametersViewModel.EndDate
								 && c.StartTime <= startTime
								 && b.ResourceId == (long)specifyParametersViewModel.SelectedResource
								 && b.ReceiverId == specifyParametersViewModel.SelectedcategoryId
								 select new { a.OrgId, a.OrgName, a.Address, a.Contact, b.ResourceId, b.ReceiverId, b.Description, c.StartDate, c.EndDate, c.StartTime, c.ManHoursPerDay });

			foreach (var item in resultsFromDB)
			{
				tviewModel.Add(new TimeReqViewModel
				{
					SelectedCategory = specifyParametersViewModel.SelectedcategoryId,
					SelectedResource = (long)specifyParametersViewModel.SelectedResource,
					OrganizationName = item.OrgName,
					ProgramDescription = item.Description,
					OrgAddress = item.Address,
					OrgContact = item.Contact,
					StartDate = (DateTime)(item.StartDate),
					EndDate = (DateTime)(item.EndDate),
					StartTime = (DateTime)(item.StartTime),
					ManHoursPerDay = item.ManHoursPerDay
				});
			}

			if (tviewModel.Count != 0)
			{
				foreach (var item in tviewModel)
				{
					mappedRequirementViewModel.Add(new MappedRequirementViewModel
					{
						SelectedcategoryId = item.SelectedCategory,
						SelectedResource = (ResourceTypes)item.SelectedResource,
						OrganizationName = item.OrganizationName,
						ProgramDescription = item.ProgramDescription,
						OrganizationAddress = item.OrgAddress,
						OrganizationContact = item.OrgContact,
						StartDate = item.StartDate,
						EndDate = item.EndDate,
						StartTime = item.StartTime,
						HoursPerDate = item.ManHoursPerDay
					});
				}
			}
			else
			{
				mappedRequirementViewModel.Add(new MappedRequirementViewModel
				{
					SelectedcategoryId = specifyParametersViewModel.SelectedcategoryId,
					SelectedResource = specifyParametersViewModel.SelectedResource,
					OrganizationName = "Sorry !! No matches found. Please try again.",
					ProgramDescription = "",
					OrganizationAddress = "",
					OrganizationContact = "",
					StartDate = DateTime.MinValue,
					EndDate = DateTime.MinValue,
					StartTime = DateTime.MinValue,
					HoursPerDate = 0
				});
			}

				return mappedRequirementViewModel;
			
		}

		public List<MappedRequirementViewModel> ProductRequirementMapping(SpecifyParametersViewModel specifyParametersViewModel)
		{
			List<MappedRequirementViewModel> mappedRequirementViewModel = new List<MappedRequirementViewModel>();

			// Business Logic here
			GiveBackDBEntities db = new GiveBackDBEntities();
			var pviewModel = new List<ProductReqViewModel>();

			var resultsFromDB = (from a in db.OrgDetails
								 join b in db.Requirements on a.OrgId equals b.OrgId
								 join c in db.ProductResources on b.ReqId equals c.ReqId
								 where c.Quantity >= specifyParametersViewModel.ProductQuantity
								 && c.Name == specifyParametersViewModel.SelectedProductName
								 && b.ResourceId == (long)specifyParametersViewModel.SelectedResource
								 && b.ReceiverId == specifyParametersViewModel.SelectedcategoryId
								 select new { a.OrgId, a.OrgName, a.Address, a.Contact, b.ResourceId, b.ReceiverId, b.Description, c.ReqId, c.Unit, c.Quantity, c.Name });

			foreach (var item in resultsFromDB)
			{
				pviewModel.Add(new ProductReqViewModel
				{
					SelectedCategory = specifyParametersViewModel.SelectedcategoryId,
					SelectedResource = (long)specifyParametersViewModel.SelectedResource,
					OrganizationName = item.OrgName,
					OrgAddress = item.Address,
					OrgContact = item.Contact,
					ProgramDescription = item.Description,
					ProductName = item.Name,
					Unit = item.Unit,
					Quantity = Int64.Parse(item.Quantity.ToString())
				});
			}

			if (pviewModel.Count != 0)
			{
				foreach (var item in pviewModel)
				{
					mappedRequirementViewModel.Add(new MappedRequirementViewModel
					{
						SelectedcategoryId = item.SelectedCategory,
						SelectedResource = (ResourceTypes)item.SelectedResource,
						OrganizationName = item.OrganizationName,
						OrganizationAddress = item.OrgAddress,
						OrganizationContact = item.OrgContact,
						ProgramDescription = item.ProgramDescription,
						ProductName = item.ProductName,
						ProductUnit = item.Unit,
						AvailableQuantity = item.Quantity
					});
				}
			}
			else
			{
				mappedRequirementViewModel.Add(new MappedRequirementViewModel
				{
					SelectedcategoryId = specifyParametersViewModel.SelectedcategoryId,
					SelectedResource = specifyParametersViewModel.SelectedResource,
					OrganizationName = "Sorry !! No matches found. Please try again.",
					OrganizationAddress = "",
					OrganizationContact = "",
					ProgramDescription = "",
					ProductName = "",
					ProductUnit = "",
					AvailableQuantity = 0
				});
			}

			return mappedRequirementViewModel;
		}

		public List<MappedRequirementViewModel> MoneyRequirementMapping(SpecifyParametersViewModel specifyParametersViewModel)
		{
			List<MappedRequirementViewModel> mappedRequirementViewModel = new List<MappedRequirementViewModel>();

			// Business Logic here
			GiveBackDBEntities db = new GiveBackDBEntities();
			var mviewModel = new List<MoneyReqViewModel>();

			var resultsFromDB = (from a in db.OrgDetails
								join b in db.Requirements on a.OrgId equals b.OrgId
								join c in db.MoneyResources on b.ReqId equals c.ReqId
								where c.AmountTotal >= specifyParametersViewModel.DonationAmount
								&& b.ResourceId == (long)specifyParametersViewModel.SelectedResource
								&& b.ReceiverId == specifyParametersViewModel.SelectedcategoryId
								select new { a.OrgId, a.OrgName, a.Address, a.Contact, b.ResourceId, b.ReceiverId, b.Description, c.ReqId, c.AmountTotal, c.AmountRemaining });

			foreach (var item in resultsFromDB)
			{
				mviewModel.Add(new MoneyReqViewModel
				{
					SelectedCategory = specifyParametersViewModel.SelectedcategoryId,
					SelectedResource = (long)specifyParametersViewModel.SelectedResource,
					OrganizationName = item.OrgName,
					OrganizationAddress = item.Address,
					OrganizationContact = item.Contact,
					ProgramDescription = item.Description,
					AmountTotal = Int64.Parse(item.AmountTotal.ToString()),
					AmountRemaining = Int64.Parse(item.AmountRemaining.ToString())
				});
			}

			if (mviewModel.Count != 0)
			{
				foreach (var item in mviewModel)
				{
					mappedRequirementViewModel.Add(new MappedRequirementViewModel
					{
						SelectedcategoryId = item.SelectedCategory,
						SelectedResource = (ResourceTypes)item.SelectedResource,
						OrganizationName = item.OrganizationName,
						OrganizationAddress = item.OrganizationAddress,
						OrganizationContact = item.OrganizationContact,
						ProgramDescription = item.ProgramDescription,
						AmountNeedForOrg = item.AmountTotal
					});
				}
			}
			else
			{
				mappedRequirementViewModel.Add(new MappedRequirementViewModel
				{
					SelectedcategoryId = specifyParametersViewModel.SelectedcategoryId,
					SelectedResource = specifyParametersViewModel.SelectedResource,
					OrganizationName = "Sorry !! No matches found. Please try again.",
					OrganizationAddress = "",
					OrganizationContact = "",
					ProgramDescription = "",
					AmountNeedForOrg = 0
				});
			}

			return mappedRequirementViewModel;
		}

		internal List<string> GetProductListFromDB(long selectedCategoryId)
		{
			GiveBackDBEntities db = new GiveBackDBEntities();

			List<string> productList = new List<string>();
			var resultsFromDB = (from a in db.ProductResources
								 join b in db.Requirements on a.ReqId equals b.ReqId
								 where b.ReceiverId == selectedCategoryId
								 select a.Name).Distinct().ToList();
								
			foreach (var item in resultsFromDB)
			{
				productList.Add(item.ToString());
			}

			return productList;
		}
	}
}