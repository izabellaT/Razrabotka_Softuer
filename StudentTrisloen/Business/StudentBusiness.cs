using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class StudentBusiness
    {
        private StudentContext studentContext;
        public List<Student> GetAll()
        {
            using (studentContext = new StudentContext())
            {
                return studentContext.Students.ToList();
            }
        }
        public Student Get(int id)
        {
            using (studentContext = new StudentContext())
            {
                return studentContext.Students.Find(id);
            }
        }
        public void Add(Student student)
        {
            using (studentContext = new StudentContext())
            {
                studentContext.Students.Add(student);
                studentContext.SaveChanges();
            }
        }
        public void Update(Student student)
        {
            using (studentContext = new StudentContext())
            {
                var item = studentContext.Students.Find(student.Id);
                if (item != null)
                {
                    studentContext.Entry(item).CurrentValues.SetValues(student);
                    studentContext.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {
            using (studentContext = new StudentContext())
            {
                var product = studentContext.Students.Find(id);
                if (product != null)
                {
                    studentContext.Students.Remove(product);
                    studentContext.SaveChanges();
                }
            }
        }
    }
}
