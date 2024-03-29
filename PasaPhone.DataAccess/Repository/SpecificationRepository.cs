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
    public class SpecificationRepository : Repository<Specification>, ISpecificationRepository
    {
        private ApplicationDbContext _context;

        public SpecificationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Specification specification)
        {
            _context.Specifications.Update(specification);
        }
    }
}
