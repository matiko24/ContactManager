using ContactManager.ContactService;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactManager.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            GetData();
        }

        public async void GetData()
        {
            ContactsList = new ObservableCollection<Contact>(await GetDataFromService());
            EmployeesList = new ObservableCollection<Employees>(await GetEmployeesFromService());
        }

        private async Task<List<Employees>> GetEmployeesFromService()
        {
            List<Employees> list = new List<Employees>();
            using (ContactServiceClient client = new ContactServiceClient())
            {
                list = await client.GetEmployeesAsync();
            }
            return list;
        }

        private async Task<List<Contact>> GetDataFromService()
        {
            List<Contact> list = new List<Contact>();
            using (ContactServiceClient client = new ContactServiceClient())
            { 
                list = await client.GetContactsAsync();
            }
            return list;
        }

        private async Task<List<Contact>> GetFilteredDataFromService(string predicate)
        {
            List<Contact> list = new List<Contact>();
            using (ContactServiceClient client = new ContactServiceClient())
            {
                list = await client.GetFilteredContactsAsync(predicate);
            }
            return list;
        }

        public string FindText { get; set; }

        private async void OnFindTextChanged()
        {
            ContactsList = new ObservableCollection<Contact>(await GetFilteredDataFromService(FindText));
        }
        
        public ObservableCollection<Contact> ContactsListAll { get; set; }
        public ObservableCollection<Contact> ContactsList { get; set; }

        public ObservableCollection<Employees> EmployeesList { get; set; }


        public ICommand CloseCommand => new RelayCommand(Close);

        private void Close()
        {
            Environment.Exit(0);
        }
    }
}
