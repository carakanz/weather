using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Security.Policy;
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

namespace WeatherWindowsClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _currentCountry;
        private string _currentRegion;
        private string _currentCity;
        private readonly Uri _baseURL = new Uri(Settings.Default.URL);
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string Status { get; set; } = "Статус:";
        public ObservableCollection<string> Countries { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Regions { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Cities { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<WeatherServer.Models.WeatherForTime> WeatherForTime { get; set; } =
            new ObservableCollection<WeatherServer.Models.WeatherForTime>();

        public string SelectedCountry { get; set; }
        public string SelectedRegion { get; set; }
        public string SelectedCity { get; set; }
        public string CurrentCountry
        {
            get => _currentCountry;
            set
            {
                _currentCountry = value;
                if (value.Length < 2)
                {
                    Countries.Clear();
                    return;
                }
                try
                {
                    using var webClient = new WebClient();
                    webClient.QueryString.Add("country", value);
                    var response = webClient.DownloadString(new Uri(_baseURL, Settings.Default.GetCountry));
                    List<string> newCountries = JsonConvert.DeserializeObject<List<string>>(response);
                    Countries.Clear();
                    newCountries.ForEach(c => Countries.Add(c));
                }
                catch(Exception) {

                }
            }
        }
        public string CurrentRegion
        {
            get => _currentRegion;
            set
            {
                _currentRegion = value;
                if (value.Length < 2)
                {
                    Regions.Clear();
                    return;
                }
                try
                {
                    using var webClient = new WebClient();
                    if (!string.IsNullOrWhiteSpace(CurrentCountry))
                    {
                        webClient.QueryString.Add("country", CurrentCountry);
                    }
                    webClient.QueryString.Add("region", value);
                    var response = webClient.DownloadString(new Uri(_baseURL, Settings.Default.GetRegion));
                    List<string> newRegions = JsonConvert.DeserializeObject<List<string>>(response);
                    Regions.Clear();
                    newRegions.ForEach(r => Regions.Add(r));
                }
                catch (Exception)
                {

                }
            }
        }
        public string CurrentCity
        {
            get => _currentCity;
            set
            {
                _currentCity = value;
                if (value.Length < 2)
                {
                    Cities.Clear();
                    return;
                }
                try
                {
                    using var webClient = new WebClient();
                    if (!string.IsNullOrWhiteSpace(CurrentCountry))
                    {
                        webClient.QueryString.Add("country", CurrentCountry);
                    }
                    if (!string.IsNullOrWhiteSpace(CurrentRegion))
                    {
                        webClient.QueryString.Add("region", CurrentRegion);
                    }
                    webClient.QueryString.Add("city", value);
                    var response = webClient.DownloadString(new Uri(_baseURL, Settings.Default.GetCity));
                    List<string> newCities = JsonConvert.DeserializeObject<List<string>>(response);
                    Cities.Clear();
                    newCities.ForEach(c => Cities.Add(c));
                }
                catch (Exception)
                {

                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CurrentCity) || CurrentCity.Length < 2)
            {
                Status = "Введите название города";
                return;
            }
            try
            {
                using var webClient = new WebClient();
                if (!string.IsNullOrWhiteSpace(CurrentCountry))
                {
                    webClient.QueryString.Add("country", CurrentCountry);
                }
                if (!string.IsNullOrWhiteSpace(CurrentRegion))
                {
                    webClient.QueryString.Add("region", CurrentRegion);
                }
                webClient.QueryString.Add("city", CurrentCity);
                var response = webClient.DownloadString(new Uri(_baseURL, Settings.Default.GetWeather));
                WeatherServer.Models.Weather weather = JsonConvert.DeserializeObject<WeatherServer.Models.Weather>(response);
                WeatherServer.Models.WeatherForTime current = new WeatherServer.Models.WeatherForTime
                {
                    Time = DateTime.Now,
                    Weather = weather.Current
                };
                weather.WeatherInfos.OrderBy(w => w.Time);
                WeatherForTime.Clear();
                WeatherForTime.Add(current);
                foreach (var weatherInfo in weather.WeatherInfos)
                {
                    WeatherForTime.Add(weatherInfo);
                }
                Status = $"{weather.City.NameEn}, {weather.City.Region.NameEn}, {weather.City.Country.NameEn}";
            }
            catch (Exception exc)
            {
                Status = $"Ошибка: {exc}";
            }
        }
    }
}
