using GivingBack2.Models;
using GivingBack2.Models.EntityManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GivingBack2.ViewModels
{
	public class HomeIndexViewModel
	{	
		public static List<Category> CategoryList;
		public long SelectedCategoryId { get; set; }

		static HomeIndexViewModel()
		{
			CategoryList = GetCategories();
		}

		public HomeIndexViewModel()
		{
		}

		private static List<Category> GetCategories()
		{
			List<Category> categoryList = new List<Category>();
			categoryList.Add(new Category() { CategoryName = "Women", CategoryDisplayName = "Want to Empower Women ?", CategoryId = 1 });

			categoryList.Add(new Category() { CategoryName = "SeniorCitizen", CategoryDisplayName = "Want to help Senior Citizen ?", CategoryId = 2 });

			categoryList.Add(new Category() { CategoryName = "Child", CategoryDisplayName = "Want to Educate children ?", CategoryId = 3 });

			categoryList.Add(new Category() { CategoryName = "Disabled", CategoryDisplayName = "Want to help the differently abled ?", CategoryId = 4 });
			return categoryList;
		}
	}

	public class ChooseCategoryViewModel
	{
		public ResourceTypes SelectedResource { get; set; }

		public long SelectedCategoryId { get; set; }
		public string SelectedCategoryName { get; set; }


		[Display(Name = "Want to donate some money?")]
		public bool MoneyResourceType
		{
			get
			{
				return SelectedResource == ResourceTypes.Money;
			}
		}

		[Display(Name = "Want to donate some time?")]
		public bool TimeResourceType
		{
			get
			{
				return SelectedResource == ResourceTypes.Time;
			}
		}

		[Display(Name = "Want to donate some clothes or books?")]
		public bool ProductResourceType
		{
			get
			{
				return SelectedResource == ResourceTypes.Product;
			}
		}
	}

	public class SpecifyParametersViewModel
	{
		public ResourceTypes SelectedResource { get; set; }
		public string SelectedCategoryName { get; set; }
		public long SelectedcategoryId { get; set; }
		
		// Money
		[Display(Name = "How much you want to donate?")]
		[DataType(DataType.Currency)]
		public long DonationAmount { get; set; }
		
		// Products
		[Display(Name = "What do you want to donate? Please select from the list Below")]
		public string ProductNameLabel { get; set; }
		
		public static List<string> ProductNameList { get; set; }
		public string SelectedProductName { get; set; }

		[Display(Name = "What is the unit of the product(eg. ItemCount, Kg ) ?")]
		public string ProductUnit { get; set; }

		[Display(Name = "How much do you want to donate (specify in the quantity above) ?")]
		public long UserMentionedQuantity { get; set; }

		// Time
		[Display(Name = "When do you want to start?")]
		[DataType(DataType.Date)]
		public DateTime StartDate { get; set; }

		[Display(Name = "When do you want to end?")]
		[DataType(DataType.Date)]
		public DateTime EndDate { get; set; }

		[Display(Name = "When do you want to start(Time)?")]
		[DataType(DataType.Time)]
		public Time StartTime { get; set; }
		
		[Display(Name = "How many hours can you donate after starting?")]
		public int HoursPerDate { get; set; }

		public SpecifyParametersViewModel()
		{
			//if(SelectedcategoryId != null)
			//ProductNameList = GetProductList(this.SelectedcategoryId);
		}

		public static List<string> GetProductList(long selectedCategoryId)
		{
			List<string> productList = new List<string>();
			RequirementManager RM = new RequirementManager();
			productList = RM.GetProductListFromDB(selectedCategoryId);
			return productList;
		}
	}

	public class MappedRequirementViewModel
	{
		public ResourceTypes SelectedResource { get; set; }
		public string SelectedCategoryName { get; set; }
		public long? SelectedcategoryId { get; set; }
		public int OrganizationId { get; set; }
		public bool resultsFound { get; set; }

		//Target OrgName
		public string TargetOrgName { get; set; }

			// Money
		[Display(Name = "How much you want to donate?")]
		[DataType(DataType.Currency)]
		public int DonationAmount { get; set; }

		[DataType(DataType.Currency)]
		public int AmountTotal { get; set; }
		[DataType(DataType.Currency)]
		public int AmountRemaining { get; set; }

		// Products

		[Display(Name = "What do you want to donate?")]
		public string ProductName { get; set; }

		[Display(Name = "What is the unit of the product(eg. ItemCount, Kg ) ?")]
		public string ProductUnit { get; set; }

		[Display(Name = "How much do you want to donate (specify in the quantity above) ?")]
		public long UserMentionedQuantity { get; set; }
		
		public long ProductQuantity { get; set; }
		public long AvailableQuantity { get; set; }

		// Time
		[Display(Name = "When do you want to start?")]
		[DataType(DataType.Date)]
		public DateTime StartDate { get; set; }

		[Display(Name = "When do you want to end?")]
		[DataType(DataType.Date)]
		public DateTime EndDate { get; set; }

		[Display(Name = "When do you want to start(Time)?")]
		[DataType(DataType.Time)]
		public DateTime StartTime { get; set; }

		[Display(Name = "How many hours can you donate after starting?")]
		public int? HoursPerDate { get; set; }


		//Mapped Orgs
		[Display(Name = "The NGO that matches your requirement")]
		public string OrganizationName { get; set; }

		[Display(Name = "The Address of the NGO")]
		public string OrganizationAddress { get; set; }

		[Display(Name = "The Contact of the NGO")]
		public string OrganizationContact { get; set; }

		[Display(Name = "The Description of the Program")]
		public string ProgramDescription { get; set; }
		

		public MappedRequirementViewModel()
		{
			//StartDate = DateTime.UtcNow.AddHours(5.5);
			//	EndDate = DateTime.UtcNow.AddHours(5.5).AddDays(1);
			//StartTime = DateTime.UtcNow.AddHours(6.5);
			//EndTime = StartTime;
		}
	}

	public class MoneyReqViewModel
	{
		public long? SelectedCategory { get; set; }
		public ResourceTypes SelectedResource { get; set; }
		public string SelectedCategoryName { get; set; }

		//Mapped Orgs
		[Display(Name = "The NGO that matches your requirement")]
		public string OrganizationName { get; set; }
		[Display(Name = "The Address of the NGO")]
		public string OrganizationAddress { get; set; }

		[Display(Name = "The Contact of the NGO")]
		public string OrganizationContact { get; set; }

		[Display(Name = "The Description of the Program")]
		public string ProgramDescription { get; set; }

		[DataType(DataType.Currency)]
		public int DonationAmount { get; set; }

		[DataType(DataType.Currency)]
		public int AmountTotal { get; set; }

		[DataType(DataType.Currency)]
		public int AmountRemaining { get; set; }
	}

	public class ProductReqViewModel
	{
		public long? SelectedCategory { get; set; }
		public ResourceTypes SelectedResource { get; set; }
		public string SelectedCategoryName { get; set; }
		//Mapped Orgs
		[Display(Name = "The NGO that matches your requirement")]
		public string OrganizationName { get; set; }
		[Display(Name = "The NGO that matches your requirement")]
		public string OrgAddress { get; set; }
		[Display(Name = "The NGO that matches your requirement")]
		public string OrgContact { get; set; }

		[Display(Name = "The Description of the Program")]
		public string ProgramDescription { get; set; }

		[Display(Name = "The Name of the Product")]
		public string ProductName { get; set; }

		[Display(Name = "The Unit of the product")]
		public string Unit { get; set; }

		[Display(Name = "The available quantity of the Product")]
		public long ProductQuantity { get; set; }

		[Display(Name = "The User mentioned quantity")]
		public long UserMentionedQuantity { get; set; }
	}

	public class TimeReqViewModel
	{
		public long? SelectedCategory { get; set; }
		public ResourceTypes SelectedResource { get; set; }
		public string SelectedCategoryName { get; set; }

		//Mapped Orgs
		[Display(Name = "The NGO that matches your requirement")]
		public string OrganizationName { get; set; }
		[Display(Name = "The NGO that matches your requirement")]
		public string ProgramDescription { get; set; }
		[Display(Name = "The NGO that matches your requirement")]
		public string OrgAddress { get; set; }
		[Display(Name = "The NGO that matches your requirement")]
		public string OrgContact { get; set; }

		[Display(Name = "The Start Date of the Program")]
		public DateTime StartDate { get; set; }

		[Display(Name = "The End Date of the Program")]
		public DateTime EndDate { get; set; }

		[Display(Name = "The Start Time of the Program")]
		public DateTime StartTime { get; set; }

		[Display(Name = "The Man hours Per day")]
		public int? ManHoursPerDay { get; set; }
	}
}