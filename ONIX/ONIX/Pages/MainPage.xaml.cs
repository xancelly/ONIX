using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ONIX.Entities;
using LiveCharts;
using ONIX.ViewModels;
using LiveCharts.Wpf;

namespace ONIX.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private readonly ToastViewModel ToastMessage;
        public class GoodPieChartTable
        {
            public string GoodName
            {
                get; set;
            }

            public int Count
            {
                get; set;
            }
        }

        public class CartesianChartTable
        {
            public int Count
            {
                get; set;
            }
            public DateTime Date
            {
                get; set;
            }
        }

        Func<ChartPoint, string> LablePoints = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);

        int CountItem = 5;
        public MainPage()
        {
            InitializeComponent();
            ToastMessage = new ToastViewModel();
            DateFrom.SelectedDate = DateTime.Now.AddMonths(-1);
            DateTo.SelectedDate = DateTime.Now;
           
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public void CartesianChartMaker(DateTime From, DateTime To)
        {
            List<CartesianChartTable> OfferList = new List<CartesianChartTable>();
            List<string> Dates = new List<string>();

            var SaleList = AppData.Context.SaleContract.Where(c => c.IsDeleted == false).ToList();

            foreach (DateTime Date in EachDay(From, To))
            {
                if (SaleList.Where(c => c.Date == Date).Count() > 0)
                {
                    var CurrentOffer = new CartesianChartTable()
                    {
                        Count = SaleList.Where(c => c.Date == Date).Count(),
                        Date = Date,
                    };
                    OfferList.Add(CurrentOffer);
                }
            }

            SeriesCollection Series = new SeriesCollection();
            ChartValues<int> GoodValue = new ChartValues<int>();

            foreach (var item in OfferList.OrderBy(c => c.Date))
            {
                GoodValue.Add(item.Count);
                Dates.Add(item.Date.ToString("dd.MM.yyyy"));
            }

            CartesianChartDiagram.AxisX.Clear();

            CartesianChartDiagram.AxisX.Add(new Axis()
            {
                Title = "Даты",
                Labels = Dates,
            });

            LineSeries GoodLine = new LineSeries();
            GoodLine.Title = "Количество сделок";
            GoodLine.Values = GoodValue;

            Series.Add(GoodLine);

            CartesianChartDiagram.Series = Series;
        }
        public void PieChartMaker(DateTime From, DateTime To)
        {
            List<GoodPieChartTable> GoodPieList = new List<GoodPieChartTable>();

            var SaleContractList = AppData.Context.SaleContract.Where(c => c.IsDeleted == false && c.Date >= From && c.Date <= To).ToList();
            foreach (var Contract in SaleContractList)
            {
                var SpecificationList = AppData.Context.SaleContractSpecification.Where(c => c.IdSaleContract == Contract.Id).ToList();
                foreach (var Specification in SpecificationList)
                {
                    var CurrentGood = GoodPieList.Where(c => c.GoodName == Specification.Good.Name).FirstOrDefault();
                    if (CurrentGood != null)
                    {
                        CurrentGood.Count += Specification.Count;
                    }
                    else
                    {
                        CurrentGood = new GoodPieChartTable()
                        {
                            GoodName = Specification.Good.Name,
                            Count = Specification.Count,
                        };
                        GoodPieList.Add(CurrentGood);
                    }
                }
            }

            SeriesCollection Series = new SeriesCollection();
            foreach (var item in GoodPieList.OrderByDescending(c => c.Count).Take(CountItem))
            {
                PieSeries CurrentSeries = new PieSeries()
                {
                    Title = item.GoodName.ToString(),
                    Values = new ChartValues<int> { item.Count },
                    DataLabels = true,
                    LabelPoint = LablePoints
                };
                Series.Add(CurrentSeries);
            }
            PieChartDiagram.Series = Series;
        }

        public void UpdateData(DateTime From, DateTime To)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(From.ToString()) && !String.IsNullOrWhiteSpace(To.ToString()))
                {
                    if (From > Convert.ToDateTime("01.01.2015") && To > Convert.ToDateTime("01.01.2015"))
                    {
                        if (From < To)
                        {
                            CartesianChartMaker(From, To);
                            PieChartMaker(From, To);
                            var CurrentSaleContract = AppData.Context.SaleContract.Where(c => c.IsDeleted == false && c.Date >= From && c.Date <= To).ToList();
                            var CurrentServiceContract = AppData.Context.ServiceContract.Where(c => c.IsDeleted == false && c.Date >= From && c.Date <= To).ToList();
                            decimal TotalProfit = 0;
                            foreach (var item in CurrentSaleContract)
                            {
                                TotalProfit += item.GetSumWithoutNDS;
                            }
                            GoodProfitText.Text = $"{Math.Round(TotalProfit, 2)} ₽";
                            foreach (var item in CurrentServiceContract)
                            {
                                TotalProfit += item.GetSumWithoutNDS;
                            }
                            TotalProfitText.Text = $"{Math.Round(TotalProfit, 2)} ₽";
                        }
                        else
                        {
                            throw new Exception("Период указан неверно.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateData(Convert.ToDateTime(DateFrom.SelectedDate), Convert.ToDateTime(DateTo.SelectedDate));
        }

        private void DateFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData(Convert.ToDateTime(DateFrom.SelectedDate), Convert.ToDateTime(DateTo.SelectedDate));
        }

        private void DateTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData(Convert.ToDateTime(DateFrom.SelectedDate), Convert.ToDateTime(DateTo.SelectedDate));
        }

        private void TopThreeItem_Click(object sender, RoutedEventArgs e)
        {
            CountItem = 3;
            Page_Loaded(null, null);
        }

        private void TopFiveItem_Click(object sender, RoutedEventArgs e)
        {
            CountItem = 5;
            Page_Loaded(null, null);
        }

        private void TopTenItem_Click(object sender, RoutedEventArgs e)
        {
            CountItem = 10;
            Page_Loaded(null, null);
        }
    }
}
