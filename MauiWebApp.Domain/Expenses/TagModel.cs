using System;
using System.Security.Cryptography;
using System.Text;

namespace MauiWebApp.Domain.Expenses;

public class BaseTags
{
    public static readonly List<string> Tags = [
        // Essentials
        "Rent/Mortgage",
        "Utilities",
        "Groceries",
        "Transportation",
        "Insurance",

        // Lifestyle
        "Dining Out",
        "Entertainment",
        "Fitness",
        "Personal Care",

        // Financial Obligations
        "Debt Payments",
        "Savings",
        "Investments",

        // Health & Wellness
        "Medical Expenses",
        "Mental Health",

        // Education
        "Tuition",
        "Books & Supplies",
        "Courses/Certifications",

        // Family & Relationships
        "Childcare",
        "Pets",
        "Gifts & Donations",

        // Travel
        "Flights",
        "Accommodation",
        "Activities",
        "Miscellaneous Travel",

        // Miscellaneous
        "Shopping",
        "Home Improvement",
        "Emergencies",
        "Unplanned Expenses"
    ];
}

public class TagModel : BaseDomainModel
{
    public required string Name { get; set; }

    public static string GetHexColor(string input)
    {
        using var sha256 = SHA256.Create();
        byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Convert first 3 bytes to RGB
        int r = hashBytes[0];
        int g = hashBytes[1];
        int b = hashBytes[2];

        // Convert RGB to HSL
        (double h, double s, double l) = RgbToHsl(r, g, b);

        // Adjust lightness to ensure good contrast (keep within 30% - 70%)
        l = Math.Max(0.3, Math.Min(0.7, l));

        // Convert back to RGB
        (r, g, b) = HslToRgb(h, s, l);

        return $"#{r:X2}{g:X2}{b:X2}";
    }

    private static (double H, double S, double L) RgbToHsl(int r, int g, int b)
    {
        double rNorm = r / 255.0;
        double gNorm = g / 255.0;
        double bNorm = b / 255.0;

        double max = Math.Max(rNorm, Math.Max(gNorm, bNorm));
        double min = Math.Min(rNorm, Math.Min(gNorm, bNorm));
        double delta = max - min;

        double h = 0, s = 0, l = (max + min) / 2.0;

        if (delta > 0)
        {
            s = l < 0.5 ? delta / (max + min) : delta / (2 - max - min);

            if (max == rNorm)
                h = (gNorm - bNorm) / delta + (gNorm < bNorm ? 6 : 0);
            else if (max == gNorm)
                h = (bNorm - rNorm) / delta + 2;
            else
                h = (rNorm - gNorm) / delta + 4;

            h *= 60;
        }

        return (h, s, l);
    }

    private static (int R, int G, int B) HslToRgb(double h, double s, double l)
    {
        double C = (1 - Math.Abs(2 * l - 1)) * s;
        double X = C * (1 - Math.Abs((h / 60) % 2 - 1));
        double m = l - C / 2;

        double r = 0, g = 0, b = 0;

        if (h < 60) { r = C; g = X; }
        else if (h < 120) { r = X; g = C; }
        else if (h < 180) { g = C; b = X; }
        else if (h < 240) { g = X; b = C; }
        else if (h < 300) { r = X; b = C; }
        else { r = C; b = X; }

        return ((int)((r + m) * 255), (int)((g + m) * 255), (int)((b + m) * 255));
    }
}
