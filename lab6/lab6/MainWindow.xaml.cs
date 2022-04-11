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
        private List<Satellite> Satellites = new List<Satellite>();
        private List<Galaxy> Galaxies = new List<Galaxy>();

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
                Planets.Clear();
                _connection.Open();
                SqlCommand c1 = new SqlCommand();
                c1.CommandText = "select * from Planet";
                c1.Connection = _connection;
                Planets = PlanetRead(c1);
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

            using (_connection = new SqlConnection(ConnectionString))
            {
                Satellites.Clear();
                _connection.Open();
                SqlCommand c1 = new SqlCommand();
                c1.Connection = _connection;
                c1.CommandText = "select * from Satellite";
                Satellites = SatelliteRead(c1);
                Grid1.ItemsSource = Satellites;
            }
        }

        private void Galaktika_OnClick(object sender, RoutedEventArgs e)
        {
            Galaxies.Clear();
            HideEl();
            _selectedTable = "Галактика";
            cb1.ItemsSource = new HashSet<string>()
            {
                "Название"
            };
            using (_connection = new SqlConnection(ConnectionString))
            {
                _connection.Open();
                SqlCommand c1 = new SqlCommand();
                c1.Connection = _connection;
                c1.CommandText = "select * from Galaxy";
                Galaxies = GalaxyRead(c1);
                Grid1.ItemsSource = Galaxies;
            }
        }

        private void Execute_OnClick(object sender, RoutedEventArgs e)
        {
            using (_connection = new SqlConnection(ConnectionString))
            {
                _connection.Open();
                SqlCommand c1 = new SqlCommand();
                c1.Connection = _connection;
                switch (_selectedTable)
                {
                    case "Планета":
                        Planets.Clear();
                        switch (cb1.SelectedIndex)
                        {
                            case 0:
                                c1.CommandText = "select * from Planet where Name like @name";
                                c1.Parameters.Add("@name", SqlDbType.VarChar).Value = tb1.Text;
                                break;
                            case 1:
                                c1.CommandText = "select * from Planet where Radius between @p1 and @p2";
                                c1.Parameters.Add("@p1", SqlDbType.Int).Value = int.Parse(tb1.Text);
                                c1.Parameters.Add("@p2", SqlDbType.Int).Value = int.Parse(tb2.Text);
                                break;
                            case 2:
                                c1.CommandText = "select * from Planet where Core_temperature between @p1 and @p2";
                                c1.Parameters.Add("@p1", SqlDbType.Int).Value = int.Parse(tb1.Text);
                                c1.Parameters.Add("@p2", SqlDbType.Int).Value = int.Parse(tb2.Text);
                                break;
                            case 3:
                                c1.CommandText = "select * from Planet where Atmosphere = @p";
                                if (chb1.IsChecked == true)
                                {
                                    c1.Parameters.Add("@p", SqlDbType.Int).Value = 1;
                                }
                                else
                                {
                                    c1.Parameters.Add("@p", SqlDbType.Int).Value = 0;
                                }
                                break;
                            case 4:
                                c1.CommandText = "select * from Planet where Life = @p";
                                if (chb1.IsChecked == true)
                                {
                                    c1.Parameters.Add("@p", SqlDbType.Int).Value = 1;
                                }
                                else
                                {
                                    c1.Parameters.Add("@p", SqlDbType.Int).Value = 0;
                                }
                                break;
                        }
                        Planets = PlanetRead(c1);
                        Grid1.ItemsSource = Planets;
                        break;
                    case "Спутник":
                        switch (cb1.SelectedIndex)
                        {
                            case 0:
                                c1.CommandText = "select * from Satellite where Name like @name";
                                c1.Parameters.Add("@name", SqlDbType.VarChar).Value = tb1.Text;
                                break;
                            case 1:
                                c1.CommandText = "select * from Satellite where Radius between @p1 and @p2";
                                c1.Parameters.Add("@p1", SqlDbType.Int).Value = int.Parse(tb1.Text);
                                c1.Parameters.Add("@p2", SqlDbType.Int).Value = int.Parse(tb2.Text);
                                break;
                            case 2:
                                c1.CommandText = "select * from Satellite where Distance between @p1 and @p2";
                                c1.Parameters.Add("@p1", SqlDbType.Int).Value = int.Parse(tb1.Text);
                                c1.Parameters.Add("@p2", SqlDbType.Int).Value = int.Parse(tb2.Text);
                                break;
                        }
                        Satellites = SatelliteRead(c1);
                        Grid1.ItemsSource = Satellites;
                        break;
                    case "Галактика":
                        switch (cb1.SelectedIndex)
                        {
                            case 0:
                                c1.CommandText = "select * from Galaxy where Name LIKE @name";
                                c1.Parameters.Add("@name", SqlDbType.VarChar).Value = tb1.Text;
                                break;
                        }
                        Galaxies = GalaxyRead(c1);
                        Grid1.ItemsSource = Galaxies;
                        break;
                }
            }
            
        }

        private List<Planet> PlanetRead(SqlCommand c1)
        {
            List<Planet> temp = new List<Planet>();
            SqlDataReader r1 = c1.ExecuteReader();
            if (r1.HasRows)
            {
                while (r1.Read())
                {
                    temp.Add(new Planet(r1.GetInt32(0), 
                        r1.GetString(1), 
                        r1.GetInt32(2), 
                        r1.GetInt32(3), 
                        r1.GetInt32(4), 
                        r1.GetInt32(5), 
                        r1.GetInt32(6)));
                }
            }

            return temp;
        }

        private List<Galaxy> GalaxyRead(SqlCommand c1)
        {
            List<Galaxy> temp = new List<Galaxy>();
            SqlDataReader r1 = c1.ExecuteReader();
            if (r1.HasRows)
            {
                while (r1.Read())
                {
                    temp.Add(new Galaxy(r1.GetInt32(0),
                        r1.GetString(1)));
                }
            }

            return temp;
        }

        private List<Satellite> SatelliteRead(SqlCommand c1)
        {
            List<Satellite> temp = new List<Satellite>();
            SqlDataReader r1 = c1.ExecuteReader();
            if (r1.HasRows)
            {
                while (r1.Read())
                {
                    temp.Add(new Satellite(r1.GetInt32(0), 
                        r1.GetInt32(1), 
                        r1.GetString(2), 
                        r1.GetInt32(3), 
                        r1.GetInt32(4)));
                }
            }

            return temp;
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}