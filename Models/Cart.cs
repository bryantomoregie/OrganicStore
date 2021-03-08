using System;
using System.Collections.Generic;

namespace OrganicStore.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public int ClientID { get; set; }
        public Client Client { get; set; }

        public List<CartProduct> CartProducts { get; set; }
    }
}
