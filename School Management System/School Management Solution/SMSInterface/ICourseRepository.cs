using SMSEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSInterface
{
    public interface ICourseRepository:IRepository<Course>
    {
        List<Course> Search(string keyword);
        List<Course> FindByClass(int ClassNo);
    }
}
