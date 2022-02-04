using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp5.Entities;
using ConsoleApp5.Repository;
namespace ConsoleApp5.UI
{
    class ManageDepartment
    {
        IRepository<Department> _repository;
        public ManageDepartment()
        {
            _repository = new DepartmentRepository();
        }
        void AddDepartment()
        {
            Department department = new Department();
            Console.Write("Enter Id = ");
            department.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name = ");
            department.Name = Console.ReadLine();
            Console.Write("Enter Location = ");
            department.Location = Console.ReadLine();
            _repository.Insert(department);
            Console.WriteLine("Department Added successfully");

        }
        void PrintAllDepartment()
        {
            IEnumerable<Department> departmentList = _repository.GetAll();
            foreach (var item in departmentList)
            {
                Console.WriteLine($"{item.Id}\t{item.Name} \t {item.Location}");
            }
        }

        void DeleteDepartment()
        {
            Console.Write("Enter Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            _repository.Delete(id);
            Console.WriteLine("Department deleted successfully");
        }

        void UpdateDepartment()
        {
            Department department = new Department();
            Console.Write("Enter Id = ");
            department.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name = ");
            department.Name = Console.ReadLine();
            Console.Write("Enter Location = ");
            department.Location = Console.ReadLine();
            _repository.Update(department);
            Console.WriteLine("Department updated successfully");

        }

        public void Run()
        {
            int choice = (int)Options.Exit;
            Menu m = new Menu();
            do
            {
                Console.Clear();
                choice = m.Print();
                switch (choice) {
                    case (int)Options.Insert:
                        AddDepartment();
                        break;
                        case (int)Options.Delete:
                        DeleteDepartment();
                        break;
                    case (int)Options.PrintAll:
                        PrintAllDepartment();
                        break;
                    case (int)Options.Update:
                        UpdateDepartment();
                        break;
                    case (int)Options.Exit:
                        Console.WriteLine("Thanks for visiting !!!!");
                        break;
                    default:
                        Console.WriteLine("Invalid value....");
                        break;
                }
                Console.WriteLine("Press Enter to Continue....");
                Console.ReadLine();
            } while (choice != (int)Options.Exit);
        }
    }
}
