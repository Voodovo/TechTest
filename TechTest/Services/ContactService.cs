using TechTest.Services.Interfaces;
using TechTest.ViewModels;
using Umbraco.Core.Services;

namespace TechTest.Services
{
    public class ContactService : IContactService
    {
        private readonly IContentService contentService;
        private readonly IConfigService configService;

        private readonly int contactTypeParentId;
        private readonly string contactTypeAlias;

        public ContactService(IContentService contentService, IConfigService configService)
        {
            this.contentService = contentService;
            this.configService = configService;

            this.contactTypeParentId = configService.GetValueAsInt("contactTypeParentId");
            this.contactTypeAlias = configService.GetValueAsString("contactTypeAlias");
        }

        public void AddContact(ContactViewModel model)
        {
            var contentName = FullName(model.FirstName, model.LastName);
            var content = contentService.CreateContent(contentName, -1, contactTypeAlias);

            content.SetValue("firstName", model.FirstName);
            content.SetValue("lastName", model.LastName);
            content.SetValue("emailAddress", model.EmailAddress);
            content.SetValue("telephoneNumber", model.TelephoneNumber);

            contentService.Save(content);
        }

        private string FullName(string firstName, string lastName)
        {
            return string.Format("{0} {1}", firstName, lastName);
        }
    }
}