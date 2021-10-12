using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace WebApplication1.Model
{
    public class ContactAdditionalData
    {
        public int Id { get; set; }
        public Contact Contact { get; set; }
        [ForeignKey(nameof(Contact))]
        public long  ContactId { get; set; }
        public string Data { get; set; }
    }
}
