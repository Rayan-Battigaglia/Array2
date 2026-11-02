using System;

namespace BlaisePascal.Array2.Domain
{

    public class Department
    {
        private string[] _employees;
        private int[,] _workingHours;
        private string[][] _projects;

        public Department(string[] employees)
        {
            if (employees == null || employees.Length == 0)
                throw new Exception("The employee list cannot be empty.");

            _employees = (string[])employees.Clone();

            for (int i = 0; i < _employees.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(_employees[i]))
                    throw new Exception("An employee name cannot be empty.");

                for (int j = 0; j < i; j++)
                {
                    if (_employees[i] == _employees[j])
                        throw new Exception("Employee names must be unique.");
                }
            }

            _workingHours = new int[_employees.Length, 7];

            _projects = new string[_employees.Length][];

            for (int i = 0; i < _employees.Length; i++)
            {
                _projects[i] = new string[0];
            }
        }

        private int FindEmployee(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Employee name cannot be empty.");

            for (int i = 0; i < _employees.Length; i++)
            {
                if (_employees[i] == name)
                    return i;
            }

            throw new Exception("Employee not found.");
        }

        public string[] GetEmployees()
        {
            return (string[])_employees.Clone();
        }



    }
}
