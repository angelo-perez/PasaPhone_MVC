using PasaPhone.DataAccess.Data;
using PasaPhone.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasaPhone.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public IPhoneRepository Phone{ get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Phone = new PhoneRepository(_context);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
