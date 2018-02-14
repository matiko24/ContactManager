/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:ContactManager"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using Autofac;
using CommonServiceLocator;
using ContactManager.Helpers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace ContactManager.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            IoC.Setup();            
        }

        public MainViewModel Main => IoC.Container.Resolve<MainViewModel>();
        
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}