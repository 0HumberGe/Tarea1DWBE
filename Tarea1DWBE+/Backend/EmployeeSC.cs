using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea1DWBE_.DataAccess;
using Tarea1DWBE_.Models;

namespace Tarea1DWBE_.Backend
{
    public class EmployeeSC : BaseSC
    {
        public Employee GetEmployeeById(int id)
        {
            var employee = GetAllEmployees().Where(w => w.EmployeeId == id).FirstOrDefault();

            if (employee == null)
                throw new Exception("El id solicitado para el empleado que quieres obtener, no existe");

            return employee;
        }

        public IQueryable<Employee> GetAllEmployees()
        {
            return dbContext.Employees.Select(s => s);
        }

        public void DeleteEmployeeById(int id)
        {
            var employee = GetEmployeeById(id);
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
        }

        public void UpdateEmployeeFirstNameById(int id, string newName)
        {
            Employee currentEmployee = GetEmployeeById(id);

            if (currentEmployee == null)
                throw new Exception("No se encontró el empleado con el ID proporcionado");

            currentEmployee.FirstName = newName;
            dbContext.SaveChanges();
        }

        public void AddEmployee(EmployeeModel newEmployee)
        {
            var newEmployeeRegister = new Employee()
            {
                FirstName = newEmployee.Name,
                LastName = newEmployee.FamilyName
            };

            dbContext.Employees.Add(newEmployeeRegister);
            dbContext.SaveChanges();
        }
    }
}
