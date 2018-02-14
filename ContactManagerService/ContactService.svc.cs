using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ContactManagerService.DB;
using ContactManagerService.Model;

namespace ContactManagerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ContactService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ContactService.svc or ContactService.svc.cs at the Solution Explorer and start debugging.
    public class ContactService : IContactService
    {
        static IList<Contact> contacts;

        public IEnumerable<Contact> GetContacts()
        {
            if(contacts == null || contacts.Count == 0)
                contacts = Contact.GetFakeData();

            return contacts; 
        }

        public IEnumerable<Employees> GetEmployees()
        {
            IEnumerable<Employees> result = new List<Employees>();
            using (NorthwindDbContext dbContext = new NorthwindDbContext())
            {
                result = dbContext.Employees.ToList();
            }

            return result;
        }

        public IEnumerable<Contact> GetFilteredContacts(string predicate)
        {
            IEnumerable<Contact> tempList = GetContacts();
            if (!string.IsNullOrEmpty(predicate))
            {
                tempList = contacts.Where(x => x.FirstName.Contains(predicate)
                                                       || x.LastName.Contains(predicate)
                                                       || x.Email.Contains(predicate)
                                                       || x.Address.Street.Contains(predicate)
                                                       || x.Address.City.Contains(predicate));

                //if(tempList.Count()>0)
                 //   contacts = new List<Contact>(tempList);
            }
            return tempList;
        }
    }
}
