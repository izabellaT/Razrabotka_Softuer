using DbFirstDemo.Data.Models;
using System;
using System.Linq;
using System.Text;

namespace DbFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            string result = GetEmployeesWhereProjectIsClassicVest(context);
            Console.WriteLine(result);
        }

        //2
        public static string AllEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees.Select(x => new
            {
                x.FirstName,
                x.Salary
            }).OrderBy(x => x.FirstName).Where(x => x.Salary > 50000).ToArray();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }
            return sb.ToString().Trim();
        }

        //3
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees.Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.Salary,
                DepartmentName = x.Department.Name
            }).Where(x => x.DepartmentName == "Research and Development").OrderBy(x => x.Salary).ThenByDescending(x => x.FirstName).ToArray();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
            }
            return sb.ToString().Trim();
        }

        //4
        public static string EmployeesCount(SoftUniContext context)
        {
            var employees = context.Employees.ToArray();
            return $"{employees.Count()}";
        }

        //5
        public static string GetEmployeesWithFirstNameStartWithN(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employee = context.Employees.Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.Salary
            }).Where(x => x.FirstName.StartsWith("N")).OrderByDescending(x => x.Salary).ToArray();
            foreach (var e in employee)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.Salary:f2}");
            }
            return sb.ToString().Trim();
        }

        //6
        public static string GetFirstTenEmployeesWithDepartment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees.Take(10).Select(x => new
            {
                x.FirstName,
                x.LastName,
                DepartmentName = x.Department.Name
            }).OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToArray();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.DepartmentName}");
            }
            return sb.ToString().Trim();
        }

        //7
        public static string GetEmployeesFromSalesAndMarketing(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees.Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.Salary,
                DepartmentName = x.Department.Name
            }).Where(x => x.DepartmentName == "Sales" || x.DepartmentName == "Marketing").OrderBy(x => x.DepartmentName).ThenByDescending(x => x.Salary).ToArray();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
            }
            return sb.ToString().Trim();
        }

        //8
        public static string GetEmployeesWhereProjectIsClassicVest(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employeeProjects = context.EmployeesProjects.Select(x => new
            {
                FirstName = x.Employee.FirstName,
                LastName = x.Employee.LastName,
                ProjectName = x.Project.Name
            }).Where(x => x.ProjectName == "Classic Vest").OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToArray();

            foreach (var e in employeeProjects)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.ProjectName}");
            }
            return sb.ToString().Trim();
        }

        //9
        public static void AddNewProject(SoftUniContext context)
        {
            var project = new Project()
            {
                Name = "Judge system",
                StartDate = DateTime.UtcNow
            };
            context.Projects.Add(project);
            context.SaveChanges();
        }

        //10
        public static void AddTown(SoftUniContext context)
        {
            Town town = new Town()
            { Name = "Pernik" };
            context.Towns.Add(town);
            context.SaveChanges();
        }

        //11
        public static void AddEmployeeWithProject(SoftUniContext context)
        {
            Employee employee = new Employee()
            {
                FirstName = "Ani",
                LastName = "Ivanova",
                JobTitle = "Designer",
                HireDate = DateTime.UtcNow,
                Salary = 2000,
                DepartmentId = 2
            };
            context.Employees.Add(employee);
            employee.EmployeesProjects.Add(new EmployeesProject
            {
                Project = new Project
                {
                    Name = "TTT",
                    StartDate = DateTime.UtcNow
                }
            });
            context.SaveChanges();
        }

        //12
        public static void UpdateEmployee(SoftUniContext context)
        {
            var employee = context.Employees.FirstOrDefault();
            employee.FirstName = "Alex";
            context.SaveChanges();
        }

        //13
        public static void UpdateProject(SoftUniContext context)
        {
            var project = context.Projects.FirstOrDefault(x => x.Name == "TTT");
            project.Name = "Shkolo system";
            project.StartDate = new DateTime(2021, 12, 22);
            context.SaveChanges();
        }

        //14
        public static void DeleteEmployeeProject(SoftUniContext context)
        {
            var employeeProject = context.EmployeesProjects.OrderByDescending(x => x.EmployeeId == 14).First();
            context.EmployeesProjects.Remove(employeeProject);
            context.SaveChanges();
        }

        //15
        public static void DeleteProject(SoftUniContext context)
        {
            var project = context.Projects.Where(x => x.Name == "Judge System").First();
            context.Projects.Remove(project);
            context.SaveChanges();
        }
    }
}
