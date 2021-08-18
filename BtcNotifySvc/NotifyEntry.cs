using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BtcNotifySvc
{
    public class NotifyEntry : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private string id;
        public string Id
        {
            get { return id; }
            set { SetField(ref id, value, "Id"); }
        }

        private string addr;
        public string Addr
        {
            get { return addr; }
            set { SetField(ref addr, value, "Addr"); }
        }

        private string url;
        public string Url
        {
            get { return url; }
            set { SetField(ref url, value, "Url"); }
        }

        private DateTime added;
        public DateTime Added
        {
            get { return added; }
            set { SetField(ref added, value, "Added"); }
        }

        

        
    }
}
