using System;

namespace MauiWebApp.Domain.Expenses;

public class BudgetModel : BaseDomainModel
{
    public required string Name { get; set; }
    public decimal Amount { get; set; }
    public string Duration { get; set; } = BudgetDuration.Monthly;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<TagModel>? BudgetTags { get; set; }

    public class BudgetDuration
    {
        public const string Weekly = "Weekly";
        public const string Monthly = "Monthly";
        public const string Quarterly = "Quarterly";
        public const string Yearly = "Yearly";
        public const string Custom = "Custom";
        public const string NonRecurring = "NonRecurring";
        public static readonly string[] AllDurations =
        [Weekly, Monthly, Quarterly, Yearly, Custom, NonRecurring];
    }
}
