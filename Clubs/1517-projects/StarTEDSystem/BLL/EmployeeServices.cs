using StarTEDSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarTEDSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace StarTEDSystem.BLL
{
    public class EmployeeServices
    {
        #region setup of the context connection variable and class constructor
        private readonly StarTEDContext _context;

        internal EmployeeServices(StarTEDContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion

        #region Queries

        // TODO: Add more filter to the query
        public List<Employee> Employee_GetAll()
        {
            IEnumerable<Employee> info = _context.Employees;
            return info.ToList();
        }

        public List<Employee> Employee_GetEmployeesWithAClub()
        {
            IEnumerable<Employee> info = _context.Employees.OrderBy(p => p.LastName).Include(p => p.Clubs).Where(p => p.Clubs.Count > 0);


            return info.ToList();
        }

        // instructor 4, office admin 5, technical support 6
        public List<Employee> Employee_GetEmployeesHaveSpecificPosition()
        {

            IEnumerable<Employee> info = _context.Employees.OrderBy(p => p.LastName).Include(p => p.Position).Where(p => p.Position.Description == "Instructor" || p.Position.Description == "Office Administrator" || p.Position.Description == "Technical Support");

            return info.ToList();

        }


        #endregion


    }
}
