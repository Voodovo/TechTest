using Umbraco.Web.Mvc;
using System.Web.Mvc;
using TechTest.Services.Interfaces;
using TechTest.ViewModels;
using System.Configuration;

namespace MentorDigital.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/Contact/";

        private readonly IContactService contactService;
        private readonly IConfigService configService;
        private readonly int contactCreatedPageId;

        public ContactSurfaceController(IContactService contactService, IConfigService configService)
        {
            this.contactService = contactService;
            this.configService = configService;

            this.contactCreatedPageId = configService.GetValueAsInt("contactCreatedPageId");
        }

        public ActionResult RenderForm()
        {
            return PartialView(PARTIAL_VIEW_FOLDER + "_ContactDetail.cshtml");
        }

        public ActionResult SubmitContact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                contactService.AddContact(model);

                return RedirectToUmbracoPage(contactCreatedPageId);
            }

            return CurrentUmbracoPage();
        }

    }
}



