using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSEntity;
using SMSInterface;
namespace SMSRepository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        SMSDBContext context = new SMSDBContext();
        public List<Course> FindByClass(int ClassNo)
        {
            return this.context.Courses.Where(c => c.ClassId == ClassNo).ToList();
        }

        public List<Course> Search(string keyword)
        {
            return this.context.Courses.Where(c => c.CourseName == keyword).ToList();
        }
    }
}
