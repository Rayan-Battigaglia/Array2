using BlaisePascal.Array2.Domain;
using System;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] employees = { "Mario", "Luca", "Smith", "John" };

            Department department = new Department(employees);


            department.SetWorkingHours("Henry", 0, 8);
            department.SetWorkingHours("Henry", 1, 8);
            department.SetWorkingHours("Henry", 2, 8);
            department.SetWorkingHours("Henry", 3, 8);
            department.SetWorkingHours("Henry", 4, 8);

            department.SetWorkingHours("Alexis", 0, 6);
            department.SetWorkingHours("Alexis", 1, 6);
            department.SetWorkingHours("Alexis", 2, 6);
            department.SetWorkingHours("Alexis", 3, 6);
            department.SetWorkingHours("Alexis", 4, 6);

            department.SetWorkingHours("Smith", 0, 8);
            department.SetWorkingHours("Smith", 1, 8);
            department.SetWorkingHours("Smith", 2, 8);
            department.SetWorkingHours("Smith", 3, 8);
            department.SetWorkingHours("Smith", 4, 8);
            department.SetWorkingHours("Smith", 5, 4);

            department.SetWorkingHours("John", 0, 7);
            department.SetWorkingHours("John", 1, 7);
            department.SetWorkingHours("John", 2, 7);
            department.SetWorkingHours("John", 3, 7);
            department.SetWorkingHours("John", 4, 7);


            Console.WriteLine("WEEKLY HOURS");

            Console.WriteLine("Henry: " +
                department.GetWeeklyHours("Henry") + " hours");

            Console.WriteLine("Alexis: " +
                department.GetWeeklyHours("Alexis") + " hours");

            Console.WriteLine("Smith: " +
                department.GetWeeklyHours("Smith") + " hours");

            Console.WriteLine("John: " +
                department.GetWeeklyHours("John") + " hours");


            Console.WriteLine("\nTOTAL DEPARTMENT HOURS");

            Console.WriteLine(
                department.GetDepartmentTotalHours() + " hours");


            department.AddProject("Henry", "Website");
            department.AddProject("Henry", "NAS");

            department.AddProject("Alexis", "NAS");

            department.AddProject("Smith", "Portable App");
            department.AddProject("Smith", "Website");
            department.AddProject("Smith", "NAS");

            department.AddProject("John", "Mobile App");
            department.AddProject("John", "Cyber security");

            Console.WriteLine("\nProjects assigned successfully.");


            department.RemoveProject("Smith", "Portable App");

            Console.WriteLine(
                "Portable App project removed from Smith.");


            Console.WriteLine("\nEMPLOYEES ASSIGNED TO NAS");

            string[] databaseEmployees = department.GetEmployeesByProject("NAS");

            for (int i = 0; i < databaseEmployees.Length; i++)
            {
                Console.WriteLine(databaseEmployees[i]);
            }


            Console.WriteLine("\nALL DEPARTMENT EMPLOYEES");

            string[] allEmployees = department.GetEmployees();

            for (int i = 0; i < allEmployees.Length; i++)
            {
                Console.WriteLine(allEmployees[i]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}