using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hart.Models
{
    public interface IInquireNowFormData
    {
        InquireNowForm Add(InquireNowForm inquireNowForm);
        void Commit();
    }
}
