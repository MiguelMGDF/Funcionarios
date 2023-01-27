using System;
using System.Collections.Generic;

namespace Funcionarios{ 
    class Program{
        static void Main(string[] args){
            List<Employee> employees = new List<Employee>();
            int option = 0;
            do{
                Console.Clear();
                System.Console.WriteLine("Employee registration system\n---------------------------------------------------------------------------------------");
                System.Console.WriteLine("Options:\n1-Register Employee\n2-Remove Employee\n3-Increase Salary\n8-Show Employees\n9-Exit");
                while(!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.Clear();
                    Console.WriteLine("You entered an invalid number");
                    System.Console.WriteLine("Employee registration system\n---------------------------------------------------------------------------------------");
                    System.Console.WriteLine("Options:\n1-Register Employee\n2-Remove Employee\n3-Increase Salary\n8-Show Employees\n9-Exit");
                }
                switch (option){
                    case 1:
                        employees = RegisterEmployee(employees);
                        break;
                    case 2:
                        employees = RemoveEmployee(employees);
                        break;
                    case 3:
                        employees = IncreaseSalary(employees);
                        break;
                    case 8:
                        ShowEmployees(employees);
                        break;
                    case 9:
                        break;
                    default:
                        System.Console.WriteLine("Error!");
                        break;
                    
                }
            }while(option != 9);

        }

        static List<Employee> RegisterEmployee(List<Employee> employees){
            System.Console.Write("How many employees will be registered? ");
            List<Employee> tempEmployees = employees;
            int op;
            while(!int.TryParse(Console.ReadLine(), out op))
            {
                Console.Clear();
                Console.WriteLine("You entered an invalid number");
                Console.Write("How many employees will be registered? ");
            }

            for(int i = 1; i <= op; i++){
                System.Console.WriteLine("Employee #" + i);
                System.Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());
                System.Console.Write("Name: ");
                string name = Console.ReadLine();
                System.Console.Write("Salary: ");
                double salary = double.Parse(Console.ReadLine());
               
                Employee em = new Employee(id, name, salary);
               
                tempEmployees.Add(em);
            }
            return tempEmployees;
        }
        static void ShowEmployees(List<Employee>employees){
            if (employees.Count == 0){
                System.Console.WriteLine("Error! Empty List!\nPress any key to continue");
                Console.ReadLine();
                return;
                
            }
            else{
                foreach(Employee obj in employees){
                    System.Console.WriteLine(obj);
                }
                System.Console.WriteLine("\n\nPress any key to continue");
                Console.ReadLine();
                return;
            }
            
        }

        static List<Employee> RemoveEmployee(List<Employee> employees){
            int exception = CheckList(employees);
            if (exception == 0){
                System.Console.WriteLine("Error! Empty List!\nPress any key to continue");
                Console.ReadLine();
                return employees;
            }

            List<Employee> tempList = employees;
            System.Console.WriteLine("Enter the employee id that will be deleted: ");
            int delete_id = int.Parse(Console.ReadLine());
            var remove_exception = tempList.RemoveAll(x => x.Id == delete_id);
            while(exception == 0){
                Console.WriteLine("You entered an invalid ID");
                System.Console.WriteLine("Enter the employee id that will be deleted: ");
                delete_id = int.Parse(Console.ReadLine());
                exception = employees.RemoveAll(x => x.Id == delete_id);
            }

            return tempList;
        }

        static List<Employee> IncreaseSalary(List<Employee> employees){
            int exception = CheckList(employees);
            if (exception == 0){
                System.Console.WriteLine("Error! Empty List!\nPress any key to continue");
                Console.ReadLine();
                return employees;
            }

            List<Employee> tempList = employees;
            System.Console.WriteLine("Enter the employee id that will have salary increase: ");
            int employee_id = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter the percentage: ");
            double percentage = double.Parse(Console.ReadLine());
            Employee item = tempList.Find(x => x.Id == employee_id);
            if (item != null){item.IncreaseSalary(percentage);}
            return tempList;
            
        }

        static int CheckList(List<Employee> employees){
            int exception = 1;
            if (employees.Count == 0){
                exception = 0;
            }

            return exception;
        }
        
    }
}