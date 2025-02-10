using System;
using System.ComponentModel.DataAnnotations;

namespace MauiWebApp.Domain.Expenses;

public class ExpenseModel : BaseDomainModel
{
    public decimal Amount { get; set; }
    public DateTime ExpenseDate { get; set; }
    [Required]
    [MinLength(1)]
    [MaxLength(255)]
    public required string Description { get; set; }
    public bool IsRecurring { get; set; }
    public string? Frequency { get; set; }
    public List<TagModel> ExpenseTags { get; set; } = [];
}
