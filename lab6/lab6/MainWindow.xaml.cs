using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private const string ConnectionString = "Server=ALEXTRAZA\\SQLEXPRESS;Database=Planets;Trusted_Connection=True;";
        private static string _selectedTable;
        private SqlConnection _connection;
        private List<Planet> Planets = new List<Planet>();

        public MainWindow()
        {
            InitializeComponent();
            HideAll();
            MainFrame.Visibility = Visibility.Visible;
            HideEl();
            l1.Visibility = Visibility.Visible;
            l2.Visibility = Visibility.Visible;
            _connection = new SqlConnection(ConnectionString);
            Grid1.IsReadOnly = true;
        }

        private void HideAll()
        {
            MainFrame.Visibility = Visibility.Hidden;
            ViewFrame.Visibility = Visibility.Hidden;
            AddFrame.Visibility = Visibility.Hidden;
            EditFrame.Visibility = Visibility.Hidden;
            DeleteFrame.Visibility = Visibility.Hidden;
        }
        
        private void HideEl()
        {
            l1.Visibility = Visibility.Hidden;
            tb1.Visibility = Visibility.Hidden;
            l2.Visibility = Visibility.Hidden;
            tb2.Visibility = Visibility.Hidden;
            chb1.Visibility = Visibility.Hidden;
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            HideAll();
            ViewFrame.Visibility = Visibility.Visible;
        }

        private void Cb1_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_selectedTable.Equals("Планета"))
            {
                switch (cb1.SelectedIndex)
                {
                    case 0:
                        HideEl();
                        l1.Visibility = Visibility.Visible;
                        tb1.Visibility = Visibility.Visible;
                        l1.Content = "Значение";
                        break;
                    case 1:
                        HideEl();
                        l1.Visibility = Visibility.Visible;
                        tb1.Visibility = Visibility.Visible;
                        l2.Visibility = Visibility.Visible;
                        tb2.Visibility = Visibility.Visible;
                        l1.Content = "От";
                        l2.Content = "До";
                        break;
                    case 2:
                        HideEl();
                        l1.Visibility = Visibility.Visible;
                        tb1.Visibility = Visibility.Visible;
                        l2.Visibility = Visibility.Visible;
                        tb2.Visibility = Visibility.Visible;
                        l1.Content = "От";
                        l2.Content = "До";
                        break;
                    case 3:
                        HideEl();
                        l1.Visibility = Visibility.Visible;
                        l1.Content = "Значение";
                        chb1.Visibility = Visibility.Visible;
                        break;
                    case 4:
                        HideEl();
                        l1.Visibility = Visibility.Visible;
                        l1.Content = "Значение";
                        chb1.Visibility = Visibility.Visible;
                        break;
                }
            }
            else if (_selectedTable.Equals("Спутник"))
            {
                switch (cb1.SelectedIndex)
                {
                    case 0:
                        HideEl();
                        l1.Visibility = Visibility.Visible;
                        tb1.Visibility = Visibility.Visible;
                        l1.Content = "Значение";
                        break;
                    case 1:
                        HideEl();
                        l1.Visibility = Visibility.Visible;
                        tb1.Visibility = Visibility.Visible;
                        l2.Visibility = Visibility.Visible;
                        tb2.Visibility = Visibility.Visible;
                        l1.Content = "От";
                        l2.Content = "До";
                        break;
                    case 2:
                        HideEl();
                        l1.Visibility = Visibility.Visible;
                        tb1.Visibility = Visibility.Visible;
                        l2.Visibility = Visibility.Visible;
                        tb2.Visibility = Visibility.Visible;
                        l1.Content = "От";
                        l2.Content = "До";
                        break;
                }
            }
            else if (_selectedTable.Equals("Галактика"))
            {
                switch (cb1.SelectedIndex)
                {
                    case 0:
                        HideEl();
                        l1.Visibility = Visibility.Visible;
                        tb1.Visibility = Visibility.Visible;
                        l1.Content = "Значение";
                        break;
                }
            }
        }

        private void Planeta_OnClick(object sender, RoutedEventArgs e)
        {
            HideEl();
            _selectedTable = "Планета";
            cb1.ItemsSource = new HashSet<string>()
            {
                "Название",
                "Радиус",
                "Температура ядра",
                "Наличие атмосферы",
                "Наличие жизни"
            };

            using (_connection = new SqlConnection(ConnectionString))
            {
                _connection.Open();
                SqlCommand c1 = new SqlCommand();
                c1.CommandText = "select * from Planet";
                c1.Connection = _connection;
                SqlDataReader r1 = c1.ExecuteReader();
                int i = 0;
                if (r1.HasRows)
                {
                    while (r1.Read())
                    {
                        Planet p1 = new Planet();
                        p1.Id = r1.GetInt32(0);
                        p1.Name = r1.GetString(1);
                        p1.GalaxyId = r1.GetInt32(2);
                        p1.Radius = r1.GetInt32(3);
                        p1.CoreTemperature = r1.GetInt32(4);
                        p1.Atmosphere = r1.GetInt32(5);
                        p1.Life = r1.GetInt32(6);
                        Planets.Add(p1);
                    }
                }

                Grid1.ItemsSource = Planets;
            }
        }

        private void Sputnik_OnClick(object sender, RoutedEventArgs e)
        {
            HideEl();
            _selectedTable = "Спутник";
            cb1.ItemsSource = new HashSet<string>()
            {
                "Название",
                "Радиус",
                "Расстояние до планеты"
            };
        }

        private void Galaktika_OnClick(object sender, RoutedEventArgs e)
        {
            HideEl();
            _selectedTable = "Галактика";
            cb1.ItemsSource = new HashSet<string>()
            {
                "Название"
            };
        }
    }
}