using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GetImage
{
    public class XuLyHinhAnh : BaseViewModel
    {
        private int _IDhinh;

        public int ID { get => _IDhinh; set { _IDhinh = value; OnPropertyChanged(); } }

        private string _tenhinh;

        public string tenhinh { get => _tenhinh; set { _tenhinh = value; OnPropertyChanged(); } }

        private byte[] _hinh;
        public byte[] hinh { get => _hinh; set { _hinh = value; OnPropertyChanged(); } }

        public ObservableCollection<Image> _listhinh;
        public ObservableCollection<Image> listhinhanh { get => _listhinh; set { _listhinh = value; OnPropertyChanged(); } }

        private ImageSource _HinhSource;

        public ImageSource HinhSource { get => _HinhSource; set { _HinhSource = value; OnPropertyChanged(); } }
        public static BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
        public static BitmapImage GetImage(byte[] imageSourceString)
        {
            var img = System.Drawing.Image.FromStream(new MemoryStream(Convert.ToByte(imageSourceString)));
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(img);
            BitmapImage hinh = BitmapToImageSource(bitmap);
            return hinh;
        }
        public void loadhinhanh()
        {
            var db = new hinhanhContext();
            listhinhanh = new ObservableCollection<Image>();
            var ha = db.Image;
            foreach (var item in ha)
            {
                Image hinhanhContext = new Image();
                hinhanhContext.IdHinh = item.IdHinh;
                hinhanhContext.TenHinh = item.TenHinh;
                hinhanhContext.Hinh = item.Hinh;
                HinhSource = GetImage(item.Hinh);
                listhinhanh.Add(hinhanhContext);
            }
        }
    }
}
