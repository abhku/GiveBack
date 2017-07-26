using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivingBack2.Models
{
	public class Time
	{
		public static List<string> TimeList = new List<string>();

		static Time()
		{
			TimeList.Add("12 AM");

			for (int i = 1; i < 12; i++)
				TimeList.Add(i.ToString()+" AM");

			TimeList.Add("12 PM");

			for (int i = 1; i < 12; i++)
				TimeList.Add(i.ToString() + " PM");

		}

		public int SelectedTimeIndex { get; set; }
		public string SelectedTime
		{
			get;
			set;
		}
	}
}