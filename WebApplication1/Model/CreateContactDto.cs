using System;

namespace WebApplication1.Model
{
    public class CreateContactDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    public class EditContactDto : CreateContactDto
    {
        public int Id { get; set; }
    }

    public class ContactDto : EditContactDto
    {
        public DateTime CreationDate { get; set; }
    }
}