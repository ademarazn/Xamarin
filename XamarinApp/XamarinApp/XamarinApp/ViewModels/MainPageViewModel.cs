using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _textOk = "Hello World, from Xamarin.Forms!";

        public MainPageViewModel()
        {
            OkClickCommand = new Command(ExecuteOkClickCommand);
        }

        public string TextOk {
            get
            {
                return _textOk;
            }
            set
            {
                _textOk = value;
                OnPropertyChanged();
            }
        }

        private void ExecuteOkClickCommand()
        {
            TextOk = "Wow, it worked perfectly on " + Device.RuntimePlatform + "!";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand OkClickCommand { get; private set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
