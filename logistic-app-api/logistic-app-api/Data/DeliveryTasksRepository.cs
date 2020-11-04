using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Data
{
    public class DeliveryTasksRepository : IRepository<DeliveryTask>
    {
        private readonly LogisticContext _context;

        public DeliveryTasksRepository(LogisticContext context)
        {
            _context = context;
        }

        public void Create(DeliveryTask item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.DeliveryTasks.Add(item);
        }

        public void Delete(DeliveryTask item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.DeliveryTasks.Remove(item);
        }

        public IEnumerable<DeliveryTask> GetAll()
        {
            return _context.DeliveryTasks.ToList();
        }

        public DeliveryTask GetById(int id)
        {
            return _context.DeliveryTasks.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(DeliveryTask item)
        {
             //nothing
        }
    }
}
