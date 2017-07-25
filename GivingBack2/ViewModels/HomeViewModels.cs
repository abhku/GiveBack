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

		public ResourceTypes SelectedResource { get; set; }
	}

	public class ChooseCategoryViewModel
	{
		public ResourceTypes SelectedResource { get; set; }

		public List<Category> CategoryList;
		public int SelectedCategoryId { get; set; }

		public ChooseCategoryViewModel()
		{
			CategoryList = GetCategories();
		}

		private List<Category> GetCategories()
		{
			List<Category> categoryList = new List<Category>();
			categoryList.Add(new Category() { CategoryName = "Women", CategoryDisplayName = "Want to Empower Women ?", CategoryId = 1 });

			categoryList.Add(new Category() { CategoryName = "SeniorCitizen", CategoryDisplayName = "Want to help Senior Citizen ?", CategoryId = 2 });

			categoryList.Add(new Category() { CategoryName = "Child", CategoryDisplayName = "Want to Educate children ?", CategoryId = 3 });
			return categoryList;
		}
	}
}