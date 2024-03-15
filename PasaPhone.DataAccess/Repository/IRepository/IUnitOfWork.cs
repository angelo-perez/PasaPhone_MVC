using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasaPhone.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPhoneRepository Phone { get; }
        Task Save();
    }
}
