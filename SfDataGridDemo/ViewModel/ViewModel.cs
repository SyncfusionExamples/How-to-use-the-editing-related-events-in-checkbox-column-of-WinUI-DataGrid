using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataGridDemo
{
    public class ViewModel:INotifyPropertyChanged
    {       
        private ObservableCollection<OrderInfo> _orders;       

        public ObservableCollection<OrderInfo> Orders
        {
            get { return _orders; }
            set { _orders = value; RaisePropertyChanged("Orders");  }
        }

        public ViewModel()
        {
            _orders = new ObservableCollection<OrderInfo>();
            this.GenerateOrders();
        }

        private void GenerateOrders()
        {
            _orders.Add(new OrderInfo(1001, "Ana Trujilo", "Mexico", "ANATR", "Mexico D.F.",89));
            _orders.Add(new OrderInfo(1003, "Antonio Moreno", "Mexico", "ANTON", "Mexico D.F.", 54));
            _orders.Add(new OrderInfo(1004, "Thomas Hardy", "UK", "AROUT", "London", 32));
            _orders.Add(new OrderInfo(1005, "Christina Berglund", "Sweden", "BERGS", "Lula", 12));
            _orders.Add(new OrderInfo(1006, "Hanna Moos", "Germany", "BLAUS", "Mannheim",99));
            _orders.Add(new OrderInfo(1007, "Frederique Citeaux", "France", "BLONP", "Strasbourg", 67));
            _orders.Add(new OrderInfo(1008, "Martin Sommer", "Spain", "BOLID", "Madrid", 89));
            _orders.Add(new OrderInfo(1009, "Laurence Lebihan", "France", "BONAP", "Marseille", 39));
            _orders.Add(new OrderInfo(1010, "Elizabeth Lincoln", "Canada", "BOTTM", "Tsawassen", 22));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }        
    }
}