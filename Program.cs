using System;
using System.Globalization;
using Project_050922.Entities;
using Project_050922.Entities.Enums;

namespace Project_050922
{
       class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // Dessa maneira, os dados do trabalhador está instanciados de certo modo que a classe department está sendo referencia da worker, cada uma com suas respectivas função.
            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.WriteLine("How many contracts to this worker?");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++) // Agora o programa vai solicitar que o usúario entre com o número de contratos e seus respectivos dados.
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Durantion (hours): ");
                int hours = int.Parse(Console.ReadLine());
                
                // Após o usúrio fornecer o dados de um contrato ele será adicionado na lista de contratos do trabalhador.
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract); 
            }
            Console.WriteLine();

            Console.Write("Enter month and year to calcule income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month).ToString("F2",
                CultureInfo.InvariantCulture));
        }
    }
}