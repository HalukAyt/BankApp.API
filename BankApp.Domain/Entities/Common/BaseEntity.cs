using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain.Entities.Common
{
    public class BaseEntity
    {
        public ObjectId Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
