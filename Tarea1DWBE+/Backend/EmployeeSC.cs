using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea1DWBE_.DataAccess;

namespace Tarea1DWBE_.Backend
{
    class EmployeeSC : BaseSC
    {
        public Employee GetEmployeeById(int id)
        {
            return GetAllEmployees().Where(w => w.EmployeeId == id).FirstOrDefault();
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
    }
}
