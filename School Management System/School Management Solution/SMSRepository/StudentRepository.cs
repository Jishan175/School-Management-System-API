using SMSEntity;
using SMSInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSRepository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        SMSDBContext context = new SMSDBContext();
        public List<Student> FindByClassNo(int classNo)
        {
            return this.context.Students.Where(s => s.Class == classNo).ToList();
        }

        public List<Student> Search(string keyword)
        {
            return this.context.Students.Where(s => s.FirstName == keyword).ToList();
        }
    }
}
