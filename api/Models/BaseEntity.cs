using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class BaseEntity
    {
        
        public int Id { get; set;}
        //DateTime.UtcNow is the current time in UTC, so every server agrees on the time. 
      
    }
}