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

            string result = GetEmployee147(context);
            Console.WriteLine(result);
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employee148 = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new 
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    EmployeeProjects = e.EmployeesProjects
                                            .Select(ep => new 
                                            {
                                                ProjectName = ep.Project.Name
                                            })
                                            .OrderBy(ep => ep.ProjectName)
                                            .ToArray()
                })
                .ToArray();

                foreach (var e in employee148)
                {
                    result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                    foreach (var p in e.EmployeeProjects)
                    {
                        result.AppendLine(p.ProjectName);
                    }
                }
            

            return result.ToString().TrimEnd();
        }
    }
}