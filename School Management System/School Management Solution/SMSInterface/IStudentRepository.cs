using SMSEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSInterface
{
    public interface IStudentRepository:IRepository<Student>
    {
        List<Student> Search(string keyword);
        List<Student> FindByClassNo(int classNo);
    }
}
