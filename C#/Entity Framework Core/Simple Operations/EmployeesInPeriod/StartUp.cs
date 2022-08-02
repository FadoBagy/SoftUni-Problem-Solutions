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

            string result = GetEmployeesInPeriod(context);
            Console.WriteLine(result);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employees = context
                .Employees
                .Take(10)
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 &&
                                                          ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    AllProjects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                            EndDate = ep.Project.EndDate.HasValue ?
                                ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished"
                        })
                        .ToArray()
                })
                .ToArray();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
                foreach (var p in e.AllProjects)
                {
                    result.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}
