﻿using MongoDB.Bson.Serialization.Attributes;

namespace ConsumerApi2.Infrastructure.Mongo.Document
{
    public class MessageCarDocument
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public List<MessageCarEngineDocument> Engines { get; set; }
    }
}