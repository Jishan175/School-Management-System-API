using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSEntity;
using SMSInterface;

namespace SMSRepository
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        SMSDBContext context = new SMSDBContext();
        public List<Class> SearchBySection(string keyword)
        {
            return this.context.Classes.Where(c => c.SectionName == keyword).ToList();
        }
    }
}
