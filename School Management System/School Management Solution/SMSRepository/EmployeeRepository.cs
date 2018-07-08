using SMSEntity;
using SMSInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSRepository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        SMSDBContext context = new SMSDBContext();
        public List<Employee> FindByDesignation(string designation)
        {
            return this.context.Employees.Where(e => e.Designation == designation).ToList();
        }

        public List<Employee> Search(string keyword)
        {
            return this.context.Employees.Where(e => e.FirstName == keyword).ToList();
        }
    }
}
