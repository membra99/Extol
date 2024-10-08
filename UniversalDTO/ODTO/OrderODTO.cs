﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.DTO.ODTO
{
    public class OrderODTO
    {
        public int OrderId { get; set; }
        public int UsersId { get; set; }
        public string OrderDate { get; set; }
        public string? OrderStatus { get; set; }
        public string? Email { get; set; }
        public string UpdatedAt { get; set; }

	}

    public class FullOrderODTO
    {
        public int OrderId { get; set;}
        public UsersODTO UsersODTO { get; set; }
        public string? Status { get; set; }
        public string CreatedAt { get; set; }
        public string? Name { get; set; }
        public int TotalPrice { get; set;}
        public List<ProductDetailsForOrderODTO> ProductODTO { get; set; }
    }
}
