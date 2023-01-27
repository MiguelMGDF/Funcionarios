using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionarios
{
    internal class Employee
    {
        public int Id;
        public string Name;
        public double Salary;
        public Employee(int id, string name, double salary) { 
            Id = id;
            Name = name;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"\nID: {Id}\nName: {Name}\nSalary: {Salary:F2}\n";
        }

        public string Get_Name(){
            return Name;
        }

        public void IncreaseSalary(double percentage){
            Salary += Salary * percentage/100;
        }
    }
}
