using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Odev.Core.Utilities;

namespace Odev.Entities.Base
{
    [BsonIgnoreExtraElements]
    public class Document : IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreatedAt { get => _createDate; set => _createDate = value; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public EntityStatus Status { get; set; } = EntityStatus.Active;

    }
}
