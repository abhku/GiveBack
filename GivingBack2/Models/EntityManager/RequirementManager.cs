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


			return mappedRequirementViewModel;
		}

		public List<MappedRequirementViewModel> ProductRequirementMapping(SpecifyParametersViewModel specifyParametersViewModel)
		{
			List<MappedRequirementViewModel> mappedRequirementViewModel = new List<MappedRequirementViewModel>();

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
					SelectedCategory = item.ReceiverId,
					SelectedResource = item.ResourceId,
					OrganizationName = item.OrgName,
					OrgAddress = item.Address,
					OrgContact = item.Contact,
					ProgramDescription = item.Description,
					ProductName = item.Name,
					Unit = item.Unit,
					Quantity = Int64.Parse(item.Quantity.ToString())
				});
			}

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
					SelectedCategory = item.ReceiverId,
					SelectedResource = item.ResourceId,
					OrganizationName = item.OrgName,
					OrganizationAddress = item.Address,
					OrganizationContact = item.Contact,
					ProgramDescription = item.Description,
					AmountTotal = Int64.Parse(item.AmountTotal.ToString()),
					AmountRemaining = Int64.Parse(item.AmountRemaining.ToString())
				});
			}

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