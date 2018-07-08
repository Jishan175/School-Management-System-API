using SMSEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSInterface
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        List<Employee> Search(string keyword);
        List<Employee> FindByDesignation(string designation);
    }
}
