using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hart.Models;
using Hart.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hart.Controllers
{
    public class InquireNowController : Controller
    {
        private readonly IInquireNowFormData _iInquireNowFormData;
        private readonly IEmailSender _emailSender;

        public InquireNowController(IInquireNowFormData iInquireNowFormData, IEmailSender emailSender)
        {
            _iInquireNowFormData = iInquireNowFormData;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            var inquire = new InquireNowForm();
            inquire.AdultsList = GetTravellers();
            inquire.TeensList = GetTravellers();
            inquire.ChildrenList = GetTravellers();

            return View(inquire);
        }

        private List<SelectListItem> GetTravellers()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "" },
                new SelectListItem { Value = "1", Text = "1" },
                new SelectListItem { Value = "2", Text = "2" },
                new SelectListItem { Value = "3", Text = "3" },
                new SelectListItem { Value = "4", Text = "4" },
                new SelectListItem { Value = "5", Text = "5" },
                new SelectListItem { Value = "6", Text = "6+" },
            };            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //async Task<IActionResult>
        //public IActionResult SubmitForm([Bind("ContactId,FullName,Phone,Email,Message")] ContactForm contactForm)
        public async Task<IActionResult> SubmitForm([Bind("InquireNowId,Name,Email,ArrivalDate,Adults,Teens,Children,Message")] InquireNowForm inquireNowForm)
        {
            if (ModelState.IsValid)
            {
                var newInquireForm = new InquireNowForm();
                newInquireForm.Name = inquireNowForm.Name;
                newInquireForm.Email = inquireNowForm.Email;
                newInquireForm.ArrivalDate = inquireNowForm.ArrivalDate;
                newInquireForm.Adults = inquireNowForm.Adults;
                newInquireForm.Teens = inquireNowForm.Teens;
                newInquireForm.Children = inquireNowForm.Children;
                newInquireForm.Message = inquireNowForm.Message;
                
                newInquireForm = _iInquireNowFormData.Add(newInquireForm);
                _iInquireNowFormData.Commit();

                // Send email with info saved in database
                //await _emailSender.SendEmailAsync(newContactForm.Email, "Contact Us Inquiry", newContactForm.Message);
                await _emailSender.SendEmailAsync("george.odongo@h-artofafricasafaris.com", "Quote Request Inquiry", newInquireForm.Message);

                return RedirectToAction(nameof(ThankYou));
            }
            
            inquireNowForm.AdultsList = GetTravellers();
            inquireNowForm.TeensList = GetTravellers();
            inquireNowForm.ChildrenList = GetTravellers();

            return View(nameof(Index), inquireNowForm);
        }

        // GET: ContactUs/Create
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}