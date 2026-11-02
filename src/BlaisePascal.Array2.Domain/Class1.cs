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

        public void SetWorkingHours(string name, int day, int hours)
        {

            int index = FindEmployee(name);

            if (day < 0 || day > 6)
                throw new Exception("Day must be between 0 and 6.");

            if (hours < 0)
                throw new Exception("Working hours cannot be negative.");

            _workingHours[index, day] = hours;
        }

        public int GetWeeklyHours(string name)
        {

            int index = FindEmployee(name);
            int total = 0;

            for (int day = 0; day < 7; day++)
            {
                total += _workingHours[index, day];
            }

            return total;
        }

        public int GetDepartmentTotalHours()
        {

            int total = 0;

            for (int i = 0; i < _employees.Length; i++)
            {
                for (int day = 0; day < 7; day++)
                {
                    total += _workingHours[i, day];
                }
            }

            return total;
        }

        public void AddProject(string name, string project)
        {

            int index = FindEmployee(name);

            if (string.IsNullOrWhiteSpace(project))
                throw new Exception("Project name cannot be empty.");

            for (int i = 0; i < _projects[index].Length; i++)
            {

                if (_projects[index][i] == project)
                    throw new Exception("The employee is already assigned to this project.");

            }

            string[] newProjects = new string[_projects[index].Length + 1];

            for (int i = 0; i < _projects[index].Length; i++)
            {
                newProjects[i] = _projects[index][i];
            }

            newProjects[newProjects.Length - 1] = project;

            _projects[index] = newProjects;
        }

        public void RemoveProject(string name, string project)
        {
            int index = FindEmployee(name);

            if (string.IsNullOrWhiteSpace(project))
                throw new Exception("Project name cannot be empty.");

            int position = -1;

            for (int i = 0; i < _projects[index].Length; i++)
            {

                if (_projects[index][i] == project)
                {
                    position = i;
                    break;
                }

            }

            if (position == -1)
                throw new Exception("The employee is not assigned to this project.");

            string[] newProjects = new string[_projects[index].Length - 1];

            int j = 0;

            for (int i = 0; i < _projects[index].Length; i++)
            {

                if (i != position)
                {
                    newProjects[j] = _projects[index][i];
                    j++;
                }

            }

            _projects[index] = newProjects;
        }

        public string[] GetEmployeesByProject(string project)
        {

            if (string.IsNullOrWhiteSpace(project))
                throw new Exception("Project name cannot be empty.");

            int count = 0;

            for (int i = 0; i < _employees.Length; i++)
            {

                for (int j = 0; j < _projects[i].Length; j++)
                {
                    if (_projects[i][j] == project)
                    {
                        count++;
                        break;
                    }
                }

            }

            string[] result = new string[count];
            int position = 0;

            for (int i = 0; i < _employees.Length; i++)
            {

                for (int j = 0; j < _projects[i].Length; j++)
                {
                    if (_projects[i][j] == project)
                    {
                        result[position] = _employees[i];
                        position++;
                        break;
                    }
                }

            }

            return result;
        }
    }
}