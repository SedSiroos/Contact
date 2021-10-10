using System;

namespace WebApplication1.Model
{
    public class Contact
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime CreationDate { get; set; }

        public Contact( string name, string phone)
        {
            
            Name = name;
            Phone = phone;
            CreationDate = DateTime.Now;
        }
        //public void Edit (long id, string name, string phone)
        //{
        //    Id = id;
        //    Name = name;
        //    Phone = phone;
        //}
    }
}
