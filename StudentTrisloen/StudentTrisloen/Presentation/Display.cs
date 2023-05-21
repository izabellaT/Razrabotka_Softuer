using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTrisloen.Presentation
{
   public class Display
    {
        private int closeOperationId = 6;
        private StudentBusiness studentBusiness = new StudentBusiness();
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }
        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }
        public Display()
        {
            Input();
        }
        private void Add()
        {
            Student student = new Student();
            Console.WriteLine("Enter first name: ");
            student.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            student.LastName = Console.ReadLine();
            Console.WriteLine("Enter town: ");
            student.Town = Console.ReadLine();
            Console.WriteLine("Enter burth date: ");
            student.BurthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter klass: ");
            student.Klass = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter uspeh: ");
            student.Uspeh = double.Parse(Console.ReadLine());
            studentBusiness.Add(student);
        }
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "STUDENTS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var students = studentBusiness.GetAll();
            foreach (var item in students)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", item.Id, item.FirstName, item.LastName, item.Town, item.BurthDate, item.Klass, item.Uspeh);
            }
        }
        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Student student = studentBusiness.Get(id);
            if (student != null)
            {
                Console.WriteLine("Enter first name: ");
                student.FirstName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                student.LastName = Console.ReadLine();
                Console.WriteLine("Enter town: ");
                student.Town = Console.ReadLine();
                Console.WriteLine("Enter burth date: ");
                student.BurthDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter klass: ");
                student.Klass = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter uspeh: ");
                student.Uspeh = double.Parse(Console.ReadLine());
                studentBusiness.Update(student);
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Student student = studentBusiness.Get(id);
            if (student != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + student.Id);
                Console.WriteLine("FirstName: " + student.FirstName);
                Console.WriteLine("LastName: " + student.LastName);
                Console.WriteLine("Town: " + student.Town);
                Console.WriteLine("BurthDate: " + student.BurthDate);
                Console.WriteLine("Klass: " + student.Klass);
                Console.WriteLine("Uspeh: " + student.Uspeh);
                Console.WriteLine(new string('-', 40));
            }
        }
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            studentBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}
