using ContactManagerService.DB;
using ContactManagerService.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace ContactManagerService
{
    [ServiceContract]
    public interface IContactService
    {
        [OperationContract]
        IEnumerable<Contact> GetContacts();

        [OperationContract]
        IEnumerable<Contact> GetFilteredContacts(string predicate);

        [OperationContract]
        IEnumerable<Employees> GetEmployees();
    }
}
