using SMSEntity;
using SMSInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSRepository
{
    public class AdminRepository: Repository<Admin>,IAdminRepository
    {
        SMSDBContext context = new SMSDBContext();
        public List<Admin> Search(string keyword)
        {
            return this.context.Admins.Where(a => a.FullName == keyword).ToList();
        }
    }
}
