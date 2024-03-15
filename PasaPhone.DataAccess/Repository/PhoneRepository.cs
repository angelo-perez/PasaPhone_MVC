using PasaPhone.DataAccess.Data;
using PasaPhone.DataAccess.Repository.IRepository;
using PasaPhone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PasaPhone.DataAccess.Repository
{
    public class PhoneRepository : Repository<Phone>, IPhoneRepository
    {
        private ApplicationDbContext _context;

        public PhoneRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Phone phone)
        {
            _context.Phones.Update(phone);
        }
    }
}
