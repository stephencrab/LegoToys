﻿using LegoToys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoToys.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader OrderHeader);
        void UpdateStatus(int Id, string orderStatus, string? paymentStatus = null);
        void UpdateStripePaymentId(int Id, string sessionId, string paymentIntentId);
    }
}
