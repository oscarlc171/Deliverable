﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.DB.Interfaces
{
    interface IOrderRepository : IGenericRepository<Order>

    {
        Order GetOrderByCustomer(int id);
    }
}
