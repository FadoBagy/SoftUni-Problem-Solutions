using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using var context = new SoftUniContext();

            string result = IncreaseSalaries(context);
            Console.WriteLine(result);
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => 
                    e.Department.Name == "Engineering"
                    || e.Department.Name == "Tool Design"
                    || e.Department.Name == "Marketing"
                    || e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var e in employees)
            {
                e.Salary *= 1.12m;
                result.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }
            context.SaveChanges();
            return result.ToString().TrimEnd();
        }
    }
}