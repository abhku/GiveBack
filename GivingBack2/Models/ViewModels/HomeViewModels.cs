using GivingBack2.Models;
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
		public int SelectedCategoryId { get; set; }

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
			categoryList.Add(new Category() { CategoryName = "Women", CategoryDisplayName = "Want to Empower Women ?", CategoryId = 0 });

			categoryList.Add(new Category() { CategoryName = "SeniorCitizen", CategoryDisplayName = "Want to help Senior Citizen ?", CategoryId = 1 });

			categoryList.Add(new Category() { CategoryName = "Child", CategoryDisplayName = "Want to Educate children ?", CategoryId = 2 });
			return categoryList;
		}
	}

	public class ChooseCategoryViewModel
	{
		public ResourceTypes SelectedResource { get; set; }

		public int SelectedCategoryId { get; set; }
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
		public int SelectedcategoryId { get; set; }

		// Money
		[Display(Name = "How much you want to donate?")]
		[DataType(DataType.Currency)]
		public int DonationAmount { get; set; }

		// Products

		[Display(Name = "What do you want to donate?")]
		public string ProductName { get; set; }

		[Display(Name = "What is the unit of the product(eg. ItemCount, Kg ) ?")]
		public string ProductUnit { get; set; }

		[Display(Name = "How much do you want to donate (specify in the quantity above) ?")]
		public string ProductQuantity { get; set; }

		// Time
		[Display(Name = "When do you want to start?")]
		[DataType(DataType.Date)]
		public string StartDate { get; set; }

		[Display(Name = "When do you want to end?")]
		[DataType(DataType.Date)]
		public string EndDate { get; set; }

		[Display(Name = "When do you want to start(Time)?")]
		[DataType(DataType.Time)]
		public Time StartTime { get; set; }
		
		[Display(Name = "How many hours can you donate after starting?")]
		public int HoursPerDate { get; set; }

		public SpecifyParametersViewModel()
		{
			//StartDate = DateTime.UtcNow.AddHours(5.5);
			//EndDate = DateTime.UtcNow.AddHours(5.5).AddDays(1);
			//StartTime = DateTime.UtcNow.AddHours(6.5);
			//EndTime = StartTime;
		}
	}

	public class MappedRequirementViewModel
	{
		public ResourceTypes SelectedResource { get; set; }
		public string SelectedCategoryName { get; set; }
		public int SelectedcategoryId { get; set; }
		public int OrganizationId { get; set; }

		// Money
		[Display(Name = "How much you want to donate?")]
		[DataType(DataType.Currency)]
		public int DonationAmount { get; set; }

		// Products

		[Display(Name = "What do you want to donate?")]
		public string ProductName { get; set; }

		[Display(Name = "What is the unit of the product(eg. ItemCount, Kg ) ?")]
		public string ProductUnit { get; set; }

		[Display(Name = "How much do you want to donate (specify in the quantity above) ?")]
		public string ProductQuantity { get; set; }

		// Time
		[Display(Name = "When do you want to start?")]
		[DataType(DataType.Date)]
		public string StartDate { get; set; }

		[Display(Name = "When do you want to end?")]
		[DataType(DataType.Date)]
		public string EndDate { get; set; }

		[Display(Name = "When do you want to start(Time)?")]
		[DataType(DataType.Time)]
		public string StartTime { get; set; }

		[Display(Name = "How many hours can you donate after starting?")]
		public int HoursPerDate { get; set; }


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
}