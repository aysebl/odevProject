using Odev.Entities.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Odev.Core.Utilities;
using Odev.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odev.Entities.Model
{
    [BsonCollection("shoppnigCarts")]
    public class ShoppingCart : Document
    {
        //public User User { get; set; }

        public ProductLookedUp Product { get; set; }

        public int Count { get; set; } = 1;

        public CartStatus CartStatus { get; set; } = CartStatus.Active;
    }
}
