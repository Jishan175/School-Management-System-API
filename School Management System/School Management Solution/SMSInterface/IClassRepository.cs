using SMSEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSInterface
{
    public interface IClassRepository:IRepository<Class>
    {
        List<Class> SearchBySection(string keyword);
        
       
    }
}
