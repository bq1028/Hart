using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hart.Models
{
    public class InquireNowFormData : IInquireNowFormData
    {
        private readonly HartContext _context;

        public InquireNowFormData(HartContext context)
        {
            _context = context;
        }
        public InquireNowForm Add(InquireNowForm inquireNowForm)
        {
            _context.Add(inquireNowForm);
            return inquireNowForm;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
