using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class EmployeeBusiness
    {
        private EmployeeContext productContext;
        public List<Employee> GetAll()
        {
            using (productContext = new EmployeeContext())
            {
                return productContext.Employees.ToList();
            }
        }
        public Employee Get(int id)
        {
            using (productContext = new EmployeeContext())
            {
                return productContext.Employees.Find(id);
            }
        }
        public void Add(Employee employee)
        {
            using (productContext = new EmployeeContext())
            {
                productContext.Employees.Add(employee);
                productContext.SaveChanges();
            }
        }
        public void Update(Employee employee)
        {
            using (productContext = new EmployeeContext())
            {
                var item = productContext.Employees.Find(employee.Id);
                if (item != null)
                {
                    productContext.Entry(item).CurrentValues.SetValues(employee);
                    productContext.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {
            using (productContext = new EmployeeContext())
            {
                var employee = productContext.Employees.Find(id);
                if (employee != null)
                {
                    productContext.Employees.Remove(employee);
                    productContext.SaveChanges();
                }
            }
        }
    }
}
