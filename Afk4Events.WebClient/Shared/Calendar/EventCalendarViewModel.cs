using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Afk4Events.Models.Events;
using Microsoft.AspNetCore.Components;

namespace Afk4Events.WebClient.Shared.Calendar
{
  public class EventCalendarViewModel : ComponentBase
  {
		/// <summary>
		/// Date used as pivot point by the calendar.
		/// Initially set to Today's date. Should be set via Parameter.
		/// </summary>
	  [Parameter] protected DateTime InitialDate { get; set; } = DateTime.Now;

		protected const int MaxDayOfMonth = 31;
		protected const int DaysPerWeek = 7;

		/// <summary>
		/// Change the current month by some amount (usually 1 month)
		/// </summary>
		/// <param name="shift">Number of months to go forward (positive) or backwards (negative)</param>
	  public void ChangeMonth(int shift)
		{
			InitialDate = InitialDate.AddMonths(shift);
		}
  }
}
