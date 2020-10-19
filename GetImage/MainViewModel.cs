using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;


namespace GetImage
{
    class MainViewModel : BaseViewModel
    {
        public enum ChucNangQL
        {
            Load
        };
        private int _ChucNang;
        public int ChucNang { get => _ChucNang; set { _ChucNang = value; OnPropertyChanged(); } }
        public ICommand LaydulieuCommand { get; set; }

        public ObservableCollection<XuLyHinhAnh> _listhinh;
        public ObservableCollection<XuLyHinhAnh> listhinhanh { get => _listhinh; set { _listhinh = value; OnPropertyChanged(); } }

       

        public MainViewModel()
        {
            LaydulieuCommand = new RelayCommand<Grid>((p) =>
            { return true; }, (p) =>
            {
                ChucNang = (int)ChucNangQL.Load;
            });
        }
        
    }
}
