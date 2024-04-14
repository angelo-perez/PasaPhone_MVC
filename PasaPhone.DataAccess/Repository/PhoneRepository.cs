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

        public void CustomUpdate(Phone phone)
        {
            var phoneFromDb = _context.Phones.FirstOrDefault(p => p.Id == phone.Id);
            if(phoneFromDb != null)
            {
                if(phoneFromDb.ImageUrl != null)
                {
                    phoneFromDb.ImageUrl = phone.ImageUrl;
                }
                phoneFromDb.Brand = phone.Brand;
                phoneFromDb.Model = phone.Model;
                phoneFromDb.Condition = phone.Condition;
                phoneFromDb.Price = phone.Price;
                phoneFromDb.Description = phone.Description;
                phoneFromDb.Issues = phone.Issues;
                phoneFromDb.Location = phone.Location;
                phoneFromDb.MeetupPreference = phone.MeetupPreference;
                phoneFromDb.DateModified = phone.DateModified;
            }
        }
    }
}
