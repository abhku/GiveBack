using GivingBack2.Models.DB;
using GivingBack2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivingBack2.Models.EntityManager
{
	public class RequirementManager
	{
		public MappedRequirementViewModel TimeRequirementMapping(SpecifyParametersViewModel specifyParametersViewModel)
		{
			MappedRequirementViewModel mappedRequirementViewModel = new MappedRequirementViewModel();

			// Business Logic here


			return mappedRequirementViewModel;
		}

		public MappedRequirementViewModel ProductRequirementMapping(SpecifyParametersViewModel specifyParametersViewModel)
		{
			MappedRequirementViewModel mappedRequirementViewModel = new MappedRequirementViewModel();

			// Business Logic here


			return mappedRequirementViewModel;
		}

		public MappedRequirementViewModel MoneyRequirementMapping(SpecifyParametersViewModel specifyParametersViewModel)
		{
			MappedRequirementViewModel mappedRequirementViewModel = new MappedRequirementViewModel();

			// Business Logic here
			GiveBackDBEntities db = new GiveBackDBEntities();


			return mappedRequirementViewModel;
		}
	}
}