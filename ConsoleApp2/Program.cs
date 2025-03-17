using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp2
{
    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public int DepartmentId { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sinh vien: Tran Lam Nghia, msv: 22115053122231\n");
            List<Department> departments_231 = new List<Department>
            {
                new Department { Id = 1, Name = "IT" },
                new Department { Id = 2, Name = "HR" },
                new Department { Id = 3, Name = "Finance" }
            };
            List<Employee> employees_231 = new List<Employee>
            {
                new Employee { Id = 1, Name = "An", Age = 25, Salary = 5000000, DepartmentId = 1 },
                new Employee { Id = 2, Name = "Binh", Age = 30, Salary = 6000000, DepartmentId = 1 },
                new Employee { Id = 3, Name = "Chau", Age = 35, Salary = 7000000, DepartmentId = 2 },
                new Employee { Id = 4, Name = "Dung", Age = 40, Salary = 8000000, DepartmentId = 2 },
                new Employee { Id = 5, Name = "Ha", Age = 28, Salary = 5500000, DepartmentId = 3 },
                new Employee { Id = 6, Name = "Lan", Age = 50, Salary = 9000000, DepartmentId = 3 }
            };


            var employeeAndDepartment_231 = from e in employees_231
                                            join d in departments_231 on e.DepartmentId equals d.Id
                                            select new
                                            {
                                                e.Name,
                                                e.Age,
                                                e.Salary,
                                                DepartmentName = d.Name
                                            };
            Console.WriteLine("Danh sach cac nhan vien cua phong ban:");
            foreach (var emp in employeeAndDepartment_231)
            {
                Console.WriteLine("Ten : " + emp.Name + ", tuoi : " + emp.Age + ", luong : " + emp.Salary + ", phong ban : " + emp.DepartmentName);
            }


            Console.WriteLine("\nThong tin nhan vien theo tung phong ban:");
            var groupedemployees_231 = from e in employees_231
                                       group e by e.DepartmentId into deptGroup
                                       join d in departments_231 on deptGroup.Key equals d.Id
                                       select new
                                       {
                                           departmentName = d.Name,
                                           youngest = deptGroup.OrderBy(e => e.Age).First(),
                                           oldest = deptGroup.OrderByDescending(e => e.Age).First(),
                                           avgAge = deptGroup.Average(e => e.Age)
                                       };
            foreach (var group in groupedemployees_231)
            {
                Console.WriteLine("Phong ban: " + group.departmentName);
                Console.WriteLine("\tTre nhat: " + group.youngest.Name + "tuoi: " + group.youngest.Age);
                Console.WriteLine("\tGia nhat: " + group.oldest.Name + "tuoi: " + group.oldest.Age);
                Console.WriteLine("\tTuoi trung binh: " + group.avgAge);
            }


            double averageSalary = employees_231.Average(e => e.Salary);
            Console.WriteLine("\nLuong trung binh cua cong ty: " + averageSalary);
        }
    }
}

