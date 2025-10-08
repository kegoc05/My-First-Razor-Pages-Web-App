using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyResumeSite.Pages
{
    public class ActivityModel : PageModel
    {
        public RectangleCalculation? RectangleResult { get; set; }
        public double? AverageResult { get; set; }
        public double? GradeResult { get; set; }
        public double? InterestResult { get; set; }

        public class RectangleCalculation
        {
            public double Area { get; set; }
            public double Perimeter { get; set; }
        }

        public void OnGet()
        {
            // Initialize page
        }

        public IActionResult OnPostRectangle(double length, double width)
        {
            if (length <= 0 || width <= 0)
            {
                ModelState.AddModelError("", "Length and width must be positive numbers.");
                return Page();
            }

            var area = length * width;
            var perimeter = 2 * (length + width);

            RectangleResult = new RectangleCalculation
            {
                Area = Math.Round(area, 2),
                Perimeter = Math.Round(perimeter, 2)
            };

            return Page();
        }

        public IActionResult OnPostAverage(double num1, double num2, double num3)
        {
            var average = (num1 + num2 + num3) / 3;
            AverageResult = Math.Round(average, 2);
            return Page();
        }

        public IActionResult OnPostGrade(double earned, double maximum)
        {
            if (maximum <= 0)
            {
                ModelState.AddModelError("", "Maximum points must be greater than zero.");
                return Page();
            }

            if (earned < 0)
            {
                ModelState.AddModelError("", "Earned points cannot be negative.");
                return Page();
            }

            if (earned > maximum)
            {
                ModelState.AddModelError("", "Earned points cannot exceed maximum points.");
                return Page();
            }

            var percentage = (earned / maximum) * 100;
            GradeResult = Math.Round(percentage, 2);
            return Page();
        }

        public IActionResult OnPostInterest(double principal, double rate, double time)
        {
            if (principal <= 0)
            {
                ModelState.AddModelError("", "Principal amount must be greater than zero.");
                return Page();
            }

            if (rate < 0)
            {
                ModelState.AddModelError("", "Interest rate cannot be negative.");
                return Page();
            }

            if (time <= 0)
            {
                ModelState.AddModelError("", "Time must be greater than zero.");
                return Page();
            }

            var interest = (principal * rate * time) / 100;
            InterestResult = Math.Round(interest, 2);
            return Page();
        }
    }
}