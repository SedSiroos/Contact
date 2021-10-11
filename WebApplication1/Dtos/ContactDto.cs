using System;

namespace WebApplication1.Dtos
{
    public class ContactDto : EditContactDto
    {
        public string FullName { get; set; }
        public string CreationDate { get; set; }
    }
}