using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace WebApplication1.Model
{
    public class Contact
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Phone { get; set; }
        public ICollection<ContactAdditionalData> AdditionalData { get; set; }

        
        public DateTimeOffset CreationDate { get; set; }

        public Contact()
        {
            CreationDate = DateTime.Now;
        }
    }
}
