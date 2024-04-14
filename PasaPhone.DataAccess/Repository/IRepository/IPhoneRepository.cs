using PasaPhone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasaPhone.DataAccess.Repository.IRepository
{
    public interface IPhoneRepository : IRepository<Phone>
    {
        void Update(Phone phone);
        void CustomUpdate(Phone phone);
    }
}
