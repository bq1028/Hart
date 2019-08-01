using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hart.Models
{
    public interface IContactFormData
    {
        ContactForm Add(ContactForm ContactForm);
        void Commit();
    }
}
