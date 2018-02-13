using ContactManager.Helpers;
using ContactManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactManager.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            ContactsList = new ObservableCollection<Contact>(Contact.GetFakeData());
        }

        string findText;
        private ObservableCollection<Contact> contactsList;

        public string FindText
        {
            get
            {
                return findText;
            }
            set
            {
                if (ContactsListAll == null)
                    ContactsListAll = new ObservableCollection<Contact>(ContactsList);

                ContactsList = new ObservableCollection<Contact>(ContactsListAll);

                if (!string.IsNullOrWhiteSpace(value))
                {

                    var tempList = ContactsList.Where(x => x.FirstName.Contains(value)
                                                        || x.LastName.Contains(value)
                                                        || x.Email.Contains(value)
                                                        || x.Address.Street.Contains(value)
                                                        || x.Address.City.Contains(value));
                  if (tempList.Count() > 0)
                    {
                        ContactsList = new ObservableCollection<Contact>(tempList);
                    }
                }
                findText = value;
            }
        }

        public ObservableCollection<Contact> ContactsListAll { get; set; }
        public ObservableCollection<Contact> ContactsList
        {
            get => contactsList;
            set
            {
                contactsList = value;
                RaisePropertyChanged();
            }
        }

        public ICommand CloseCommand => new DelegateCommand(Close);

        private void Close()
        {
            Environment.Exit(0);
        }
    }
}
