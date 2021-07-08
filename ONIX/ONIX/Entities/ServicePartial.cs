using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ONIX.Entities
{
    public partial class Service
    {
        public BitmapImage GetImage
        {
            get
            {
                if (PreviewImage != null)
                {
                    BitmapImage Image = new BitmapImage();
                    using (MemoryStream Stream = new MemoryStream(PreviewImage))
                    {
                        Image.BeginInit();
                        Image.UriSource = null;
                        Image.CacheOption = BitmapCacheOption.OnLoad;
                        Image.StreamSource = Stream;
                        Image.EndInit();
                    }
                    return Image;
                }
                else
                {
                    BitmapImage Image = new BitmapImage();
                    Image.BeginInit();
                    Image.UriSource = new Uri(@"/ONIX;component/Resources/noimage.png", UriKind.Relative);
                    Image.EndInit();
                    return Image;
                }
            }
        }

        public decimal GetLastPrice
        {
            get
            {
                var LastPrice = AppData.Context.ServicePrice.OrderByDescending(c => c.Date).Where(c => c.IdService == Id).FirstOrDefault();
                return Math.Round(LastPrice.Price, 2);
            }
        }

        public decimal GetLastNDS
        {
            get
            {
                var LastNDS = AppData.Context.ServiceNDS.OrderByDescending(c => c.Date).Where(c => c.IdService == Id).FirstOrDefault();
                return LastNDS.NDS;
            }
        }
    }
}
