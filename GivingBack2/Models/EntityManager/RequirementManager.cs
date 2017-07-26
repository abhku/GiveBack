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

			// Business Logic here


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
								select new { a.OrgId, a.OrgName, b.ResourceId, b.ReceiverId, b.Description, c.ReqId, c.AmountTotal, c.AmountRemaining });

			foreach (var item in resultsFromDB)
			{
				mviewModel.Add(new MoneyReqViewModel
				{
					OrganizationName = item.OrgName,
					ProgramDescription = item.Description,
					AmountTotal = Int64.Parse(item.AmountTotal.ToString()),
					AmountRemaining = Int64.Parse(item.AmountRemaining.ToString())
				});
			}

			foreach (var item in mviewModel)
			{
				mappedRequirementViewModel.Add(new MappedRequirementViewModel
				{
					OrganizationName = item.OrganizationName,
					ProgramDescription = item.ProgramDescription,
					AmountNeedForOrg = item.AmountTotal
				});
			}

			return mappedRequirementViewModel;
		}
	}
}