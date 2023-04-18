using LegoToys.DataAccess.Repository.IRepository;
using LegoToys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoToys.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderHeader OrderHeader)
        {
            _db.OrderHeaders.Update(OrderHeader);
        }

        public void UpdateStatus(int Id, string orderStatus, string? paymentStatus = null)
        {
            var orderHeader = _db.OrderHeaders.FirstOrDefault(o => o.Id == Id);

            if (orderHeader != null)
            {
                orderHeader.OrderStatus = orderStatus;
                if (paymentStatus != null)
                {
                    orderHeader.PaymentStatus = paymentStatus;
                }
            }
        }

        public void UpdateStripePaymentId(int Id, string sessionId, string paymentIntentId)
        {
            var orderHeader = _db.OrderHeaders.FirstOrDefault(o => o.Id == Id);
            if (orderHeader != null)
            {
                orderHeader.PaymentDate = DateTime.Now;
                orderHeader.SessionId = sessionId;
                orderHeader.PaymentIntentId = paymentIntentId;
            }        
        }
    }
}
