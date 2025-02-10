using System;
using Bogus;
using MauiWebApp.Domain.Expenses;

namespace MauiWebApp.Shared.Services;

public class FetchExpenseDataService
{
    public async Task<List<ExpenseModel>> GetExpensesAsync()
    {
        await Task.Delay(200);

        var faker = new Faker<ExpenseModel>()
            .RuleFor(e => e.Amount, f => f.Finance.Amount(1, 150)) // Positive values
            .RuleFor(e => e.ExpenseDate, f => f.Date.Recent(30)) // Last month
            .RuleFor(e => e.Description, f => f.Lorem.Sentence()) // Random sentence
            .RuleFor(e => e.IsRecurring, f => f.Random.Bool()) // Random bool
            .RuleFor(e => e.Frequency, (f, e) =>
                e.IsRecurring ? f.PickRandom(BudgetModel.BudgetDuration.AllDurations[..^1]) : BudgetModel.BudgetDuration.NonRecurring)
            .RuleFor(e => e.ExpenseTags, f =>
                f.Random.ListItems(BaseTags.Tags, f.Random.Int(1, 3)) // 1 to 3 random tags
                 .Select(tag => new TagModel { Name = tag })
                 .ToList());

        // Generate a list of fake expenses
        var fakeExpenses = faker.Generate(5);

        // Print out the generated data
        foreach (var expense in fakeExpenses)
        {
            Console.WriteLine($"Amount: {expense.Amount:C}");
            Console.WriteLine($"Date: {expense.ExpenseDate:d}");
            Console.WriteLine($"Description: {expense.Description}");
            Console.WriteLine($"Recurring: {expense.IsRecurring}");
            Console.WriteLine($"Frequency: {expense.Frequency}");
            Console.WriteLine($"Tags: {string.Join(", ", expense.ExpenseTags.Select(t => t.Name))}");
            Console.WriteLine(new string('-', 50));
        }

        return fakeExpenses;
    }
}
