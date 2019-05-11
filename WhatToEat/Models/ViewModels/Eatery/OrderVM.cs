﻿using System;
using WhatToEat.Models.Data;

namespace WhatToEat.Models.ViewModels.Eatery
{
    public class OrderVM
    {
        public OrderVM()
    {
    }

    public OrderVM(OrderDTO row)
    {
        OrderId = row.OrderId;
        UserId = row.UserId;
        CreatedAt = row.CreatedAt;
    }

    public int OrderId { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    }
}