using AppDbFirst.Models;
using System;
using System.Linq;
using System.Text;

namespace AppDbFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            var result = GetEmployeeFromEngeneering(context);
            //2  var result = GetEmployeesAsMarketingSpecialist(context);
            //3  var result = GetEmployeesByProjects(context);
            Console.WriteLine(result);
        }

        //1
        public static string GetEmployeeFromEngeneering(SoftUniContext context)
        {
            var employees = context.Employees
               .Select(x => new
               {
                   x.FirstName,
                   x.LastName,
                   x.JobTitle,
                   x.Salary
               })
               .OrderBy(x => x.FirstName).ToList();
            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - {employee.Salary:f2}");
            }
            var result = sb.ToString().TrimEnd();
            return result;
        }

        //2
        public static string GetEmployeesAsMarketingSpecialist(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.JobTitle == "Marketing Specialist")
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    Address = x.Address.AddressText,
                    x.JobTitle,
                    DepartmentName = x.Department.Name,
                })
                .OrderBy(x => x.JobTitle).Take(3).ToList();
            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.Address} - {employee.JobTitle} - {employee.DepartmentName}");
            }
            var result = sb.ToString().TrimEnd();
            return result;
        }

        //3
        public static string GetEmployeesByProjects(SoftUniContext context)
        {
                StringBuilder sb = new StringBuilder();
                var employeeProjects = context.EmployeesProjects.Select(x => new
                {
                    FirstName = x.Employee.FirstName,
                    LastName = x.Employee.LastName,
                    Salary = x.Employee.Salary,
                    ProjectName = x.Project.Name
                }).Where(x => x.ProjectName == "Classic Vest" || x.ProjectName == "Sport-100").OrderByDescending(x => x.Salary).ToArray();

            foreach (var employee in employeeProjects)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.Salary}");
                }
                return sb.ToString().Trim();
        }

        //4
        public static void AddTown(SoftUniContext context)
        {
            Town town = new Town()
            { Name = "Zagora" };
            context.Towns.Add(town);
            context.SaveChanges();
        }

        //5
        public static void UpdateTown(SoftUniContext context)
        {
            var town = context.Towns.FirstOrDefault(x => x.Name == "Zagora");
            town.Name = "Nova Zagora";
            context.SaveChanges();
        }

        //6
        public static void DeleteTown(SoftUniContext context)
        {
            var town = context.Towns.Where(x => x.Name == "Nova Zagora").First();
            context.Towns.Remove(town);
            context.SaveChanges();
        }
    }
}

