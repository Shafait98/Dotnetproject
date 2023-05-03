using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderItemDTO
    {
        public int Id { get; set; }


        public int Quantity { get; set; }


        public int OrderId { get; set; }


        public int BookId { get; set; }

    }
}
