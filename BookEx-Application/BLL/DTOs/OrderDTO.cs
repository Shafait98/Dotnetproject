﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }


        public DateTime OrderDate { get; set; }


        public decimal TotalPrice { get; set; }


        public int UserId { get; set; }

    }
}