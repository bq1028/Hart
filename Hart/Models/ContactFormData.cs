using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hart.Models
{
    public class ContactFormData : IContactFormData
    {
        private readonly HartContext _context;
        
        public ContactFormData(HartContext context)
        {
            _context = context;
        }

        public ContactForm Add(ContactForm contactForm)
        {
            _context.Add(contactForm);
            return contactForm;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
