using TechTest.ViewModels;

namespace TechTest.Services.Interfaces
{
    public interface IContactService
    {
        void AddContact(ContactViewModel model);
    }
}