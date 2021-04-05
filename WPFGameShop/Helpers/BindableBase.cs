using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFGameShop
{
    public class BindableBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new(propertyName));
            // MessageBox.Show(propertyName);
        }


    }
}
