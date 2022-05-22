using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using TwojeRemonty.Data.Entity;

namespace TwojeRemonty.Extensions
{
	public static class SpecializationsExtensions
	{
		public static List<SelectListItem> ToSelectOptions()
        {
            var values = (Specializations[])Enum.GetValues(typeof(Specializations));
            var specializationSelect = new List<SelectListItem>();
            foreach (var value in values)
            {
                var listItem = new SelectListItem
                {
                    Text = value.ToString(),
                    Value = value.ToString()
                };

                specializationSelect.Add(listItem);
                
            }

            return specializationSelect;
        }
	}
}