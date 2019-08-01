using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hart.Models;
using Hart.Services;

namespace Hart.Controllers
{
    public class ContactController : Controller
    {        
        private readonly IContactFormData _contactFormData;
        private readonly IEmailSender _emailSender;

        public ContactController(IContactFormData contactFormData, IEmailSender emailSender)
        {            
            _contactFormData = contactFormData;
            _emailSender = emailSender;
        }
                     
        // GET: ContactUs/Create
        public IActionResult Index()
        {
            return View();
        }

        // POST: ContactUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //async Task<IActionResult>
        //public IActionResult SubmitForm([Bind("ContactId,FullName,Phone,Email,Message")] ContactForm contactForm)
        public async Task<IActionResult> SubmitForm([Bind("ContactId,FullName,Phone,Email,Message")] ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                var newContactForm = new ContactForm();
                newContactForm.FullName = contactForm.FullName;
                newContactForm.Phone = contactForm.Phone;
                newContactForm.Email = contactForm.Email;
                newContactForm.Message = contactForm.Message;

                newContactForm = _contactFormData.Add(newContactForm);
                _contactFormData.Commit();

                // Send email with info saved in database
                //await _emailSender.SendEmailAsync(newContactForm.Email, "Contact Us Inquiry", newContactForm.Message);
                await _emailSender.SendEmailAsync("george.odongo@h-artofafricasafaris.com", "Contact Us Inquiry", newContactForm.Message);

                return RedirectToAction(nameof(ThankYou));
            }
            return View(nameof(Index), contactForm);
        }       

        // GET: ContactUs/Create
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
