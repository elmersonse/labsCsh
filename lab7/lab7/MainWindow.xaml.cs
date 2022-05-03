using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace lab7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private const string ConnectionString =
            "Server=ALEXTRAZA\\SQLEXPRESS;Database=Planets;Trusted_Connection=True;";

        private static string ?_selectedTable;
        private static string ?_action;
        private static int _id;
        private SqlConnection _connection;
        private List<Planet> Planets = new List<Planet>();
        private List<Satellite> Satellites = new List<Satellite>();
        private List<Galaxy> Galaxies = new List<Galaxy>();
        private List<Query1> query1s = new List<Query1>();
        private List<Query3> query3s = new List<Query3>();
        private List<Query4> query4s = new List<Query4>();
        private Dictionary<int, string> PlanetNames = new Dictionary<int, string>();
        private Dictionary<int, string> GalaxyNames = new Dictionary<int, string>();

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
            dg1.IsReadOnly = true;
            cb2.ItemsSource = new HashSet<string>
            {
                "Запрос 1",
                "Запрос 2",
                "Запрос 3"
            };
        }

        private void HideAll()
        {
            MainFrame.Visibility = Visibility.Hidden;
            ViewFrame.Visibility = Visibility.Hidden;
            AddFrame.Visibility = Visibility.Hidden;
            QueryFrame.Visibility = Visibility.Hidden;
        }

        private void HideEl()
        {
            l1.Visibility = Visibility.Hidden;
            tb1.Visibility = Visibility.Hidden;
            l2.Visibility = Visibility.Hidden;
            tb2.Visibility = Visibility.Hidden;
            chb1.Visibility = Visibility.Hidden;
        }

        private void HideAddEl()
        {
            addl2.Visibility = Visibility.Hidden;
            addl3.Visibility = Visibility.Hidden;
            addl4.Visibility = Visibility.Hidden;
            addl5.Visibility = Visibility.Hidden;
            addl6.Visibility = Visibility.Hidden;
            addl7.Visibility = Visibility.Hidden;
            addtb2.Visibility = Visibility.Hidden;
            addtb3.Visibility = Visibility.Hidden;
            addtb4.Visibility = Visibility.Hidden;
            addtb5.Visibility = Visibility.Hidden;
            addcb1.Visibility = Visibility.Hidden;
            addchb1.Visibility = Visibility.Hidden;
            addchb2.Visibility = Visibility.Hidden;
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            HideAll();
            ViewFrame.Visibility = Visibility.Visible;
        }

        private void Query_OnClick(object sender, RoutedEventArgs e)
        {
            HideAll();
            QueryFrame.Visibility = Visibility.Visible;
            cb2.SelectedIndex = -1;
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
            cb1.SelectedIndex = -1;
            _selectedTable = "Планета";
            cb1.ItemsSource = new HashSet<string>()
            {
                "Название",
                "Радиус",
                "Температура ядра",
                "Наличие атмосферы",
                "Наличие жизни"
            };

            using PlanetsContext context = new PlanetsContext();
            Grid1.ItemsSource = context.Planets.ToList();
            Grid1.Columns[7].Visibility = Visibility.Collapsed;
            Grid1.Columns[8].Visibility = Visibility.Collapsed;
        }

        private void Sputnik_OnClick(object sender, RoutedEventArgs e)
        {
            HideEl();
            cb1.SelectedIndex = -1;
            _selectedTable = "Спутник";
            cb1.ItemsSource = new HashSet<string>()
            {
                "Название",
                "Радиус",
                "Расстояние до планеты"
            };
            using PlanetsContext context = new PlanetsContext();
            Grid1.ItemsSource = context.Satellites.ToList();
            Grid1.Columns[5].Visibility = Visibility.Collapsed;
        }

        private void Galaktika_OnClick(object sender, RoutedEventArgs e)
        {
            Galaxies.Clear();
            cb1.SelectedIndex = -1;
            HideEl();
            _selectedTable = "Галактика";
            cb1.ItemsSource = new HashSet<string>()
            {
                "Название"
            };
            using PlanetsContext context = new PlanetsContext();
            Grid1.ItemsSource = context.Galaxies.ToList();
            Grid1.Columns[2].Visibility = Visibility.Collapsed;
        }

        private void Execute_OnClick(object sender, RoutedEventArgs e)
        {
            using PlanetsContext context = new();
            int c;
            switch (_selectedTable)
            {
                case "Планета":
                    var pl = context.Planets.ToList();
                    switch (cb1.SelectedIndex)
                    {
                        case 0:
                            Grid1.ItemsSource = pl.Where(p => p.Name == tb1.Text).ToList();
                            break;
                        case 1:
                            Grid1.ItemsSource = pl.Where(p => p.Radius >= int.Parse(tb1.Text) && p.Radius <= int.Parse(tb2.Text));
                            break;
                        case 2:
                            Grid1.ItemsSource = pl.Where(p => p.CoreTemperature >= int.Parse(tb1.Text) && p.CoreTemperature <= int.Parse(tb2.Text));
                            break;
                        case 3:
                            if (chb1.IsChecked == true)
                            {
                                c = 1;
                            }
                            else
                            {
                                c = 0;
                            }
                            Grid1.ItemsSource = pl.Where(p => p.Atmosphere == c);
                            break;
                        case 4:
                            if (chb1.IsChecked == true)
                            {
                                c = 1;
                            }
                            else
                            {
                                c = 0;
                            }
                            Grid1.ItemsSource = pl.Where(p => p.Life == c);
                            break;
                    }
                    if (Grid1.Items.Count != 0)
                    {
                        Grid1.Columns[7].Visibility = Visibility.Collapsed;
                        Grid1.Columns[8].Visibility = Visibility.Collapsed;
                    }
                    break;
                case "Спутник":
                    var s1 = context.Satellites.ToList();
                    switch (cb1.SelectedIndex)
                    {
                        case 0:
                            Grid1.ItemsSource = s1.Where(s => s.Name == tb1.Text);
                            break;
                        case 1:
                            Grid1.ItemsSource = s1.Where(s => s.Radius >= int.Parse(tb1.Text) && s.Radius <= int.Parse(tb2.Text));
                            break;
                        case 2:
                            Grid1.ItemsSource = s1.Where(s => s.Distance >= int.Parse(tb1.Text) && s.Distance <= int.Parse(tb2.Text));
                            break;
                    }
                    if (Grid1.Items.Count != 0)
                    {
                        Grid1.Columns[5].Visibility = Visibility.Collapsed;
                    }
                    break;
                case "Галактика":
                    var g1 = context.Galaxies.ToList();
                    switch (cb1.SelectedIndex)
                    {
                        case 0:
                            Grid1.ItemsSource = g1.Where(g => g.Name == tb1.Text);
                            break;
                    }
                    if(Grid1.Items.Count != 0)
                    {
                        Grid1.Columns[2].Visibility = Visibility.Collapsed;
                    }
                    break;
            }

        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            using PlanetsContext context = new PlanetsContext();
            _action = "Add";
            HideAll();
            AddFrame.Visibility = Visibility.Visible;
            HideAddEl();
            switch (_selectedTable)
            {
                case "Планета":
                    addl2.Visibility = Visibility.Visible;
                    addl3.Visibility = Visibility.Visible;
                    addl4.Visibility = Visibility.Visible;
                    addl5.Visibility = Visibility.Visible;
                    addl6.Visibility = Visibility.Visible;
                    addl7.Visibility = Visibility.Visible;
                    addcb1.Visibility = Visibility.Visible;
                    addtb3.Visibility = Visibility.Visible;
                    addtb4.Visibility = Visibility.Visible;
                    addtb5.Visibility = Visibility.Visible;
                    addchb1.Visibility = Visibility.Visible;
                    addchb2.Visibility = Visibility.Visible;
                    addl2.Content = "ID галактики";
                    addl3.Content = "Название";
                    addl4.Content = "Радиус";
                    addl5.Content = "Температура ядра";
                    addl6.Content = "Наличие атмосферы";
                    addl7.Content = "Наличие жизни";
                    Galaxies = context.Galaxies.ToList();
                    foreach (var g in Galaxies)
                    {
                        if (!GalaxyNames.ContainsKey(g.Id))
                        {
                            GalaxyNames.Add(g.Id, g.Name);
                        }
                    }
                    addcb1.ItemsSource = GalaxyNames.Values;
                    break;
                case "Спутник":
                    addl2.Visibility = Visibility.Visible;
                    addl3.Visibility = Visibility.Visible;
                    addl4.Visibility = Visibility.Visible;
                    addl5.Visibility = Visibility.Visible;
                    addcb1.Visibility = Visibility.Visible;
                    addtb3.Visibility = Visibility.Visible;
                    addtb4.Visibility = Visibility.Visible;
                    addtb5.Visibility = Visibility.Visible;
                    addl2.Content = "ID планеты";
                    addl3.Content = "Название";
                    addl4.Content = "Радиус";
                    addl5.Content = "Расстояние до планеты";
                    Planets = context.Planets.ToList();
                    foreach (var p in Planets)
                    {
                        if (!PlanetNames.ContainsKey(p.Id))
                        {
                            PlanetNames.Add(p.Id, p.Name);
                        }
                    }
                    addcb1.ItemsSource = PlanetNames.Values;
                    break;
                case "Галактика":
                    addl2.Visibility = Visibility.Visible;
                    addtb2.Visibility = Visibility.Visible;
                    addl2.Content = "Название";
                    break;
            }
        }

        private void AddBack(object sender, RoutedEventArgs e)
        {
            HideAll();
            ViewFrame.Visibility = Visibility.Visible;
        }

        private void AddConfirm(object sender, RoutedEventArgs e)
        {
            using PlanetsContext context = new();
            int c1, c2;
            if (_action.Equals("Add"))
            {
                switch (_selectedTable)
                {
                    case "Планета":
                        if (addchb1.IsChecked == true)
                        {
                            c1 = 1;
                        }
                        else
                        {
                            c1 = 0;
                        }
                        if (addchb2.IsChecked == true)
                        {
                            c2 = 1;
                        }
                        else
                        {
                            c2 = 0;
                        }
                        context.Planets.Add(new Planet(addtb3.Text, GalaxyNames.First(g => g.Value == addcb1.Text).Key, int.Parse(addtb4.Text), int.Parse(addtb5.Text), c1, c2));
                        context.SaveChanges();
                        Grid1.ItemsSource = context.Planets.ToList();
                        if (Grid1.Items.Count != 0)
                        {
                            Grid1.Columns[7].Visibility = Visibility.Collapsed;
                            Grid1.Columns[8].Visibility = Visibility.Collapsed;
                        }
                        break;
                    case "Спутник":
                        context.Satellites.Add(new Satellite(PlanetNames.First(g => g.Value == addcb1.Text).Key, addtb3.Text, int.Parse(addtb4.Text), int.Parse(addtb5.Text)));
                        context.SaveChanges();
                        Grid1.ItemsSource = context.Satellites.ToList();
                        if (Grid1.Items.Count != 0)
                        {
                            Grid1.Columns[5].Visibility = Visibility.Collapsed;
                        }
                        break;
                    case "Галактика":
                        context.Galaxies.Add(new Galaxy(addtb3.Text));
                        context.SaveChanges();
                        Grid1.ItemsSource = context.Galaxies.ToList();
                        break;
                }
            }
            else if (_action.Equals("Edit"))
            {
                switch (_selectedTable)
                {
                    case "Планета":
                        if (addchb1.IsChecked == true)
                        {
                            c1 = 1;
                        }
                        else
                        {
                            c1 = 0;
                        }
                        if (addchb2.IsChecked == true)
                        {
                            c2 = 1;
                        }
                        else
                        {
                            c2 = 0;
                        }
                        var tp = (Planet)Grid1.SelectedItem;
                        var tmp = new Planet(tp.Id, addtb3.Text, GalaxyNames.First(g => g.Value == addcb1.Text).Key, int.Parse(addtb4.Text), int.Parse(addtb5.Text), c1, c2);
                        context.Planets.Update(tmp);
                        context.SaveChanges();
                        Grid1.ItemsSource = context.Planets.ToList();
                        if (Grid1.Items.Count != 0)
                        {
                            Grid1.Columns[7].Visibility = Visibility.Collapsed;
                            Grid1.Columns[8].Visibility = Visibility.Collapsed;
                        }
                        break;
                    case "Спутник":
                        var ts = (Satellite)Grid1.SelectedItem;
                        var tms = new Satellite(ts.Id, PlanetNames.First(g => g.Value == addcb1.Text).Key, addtb3.Text, int.Parse(addtb4.Text), int.Parse(addtb5.Text));
                        context.Satellites.Update(tms);
                        context.SaveChanges();
                        Grid1.ItemsSource = context.Satellites.ToList();
                        if (Grid1.Items.Count != 0)
                        {
                            Grid1.Columns[5].Visibility = Visibility.Collapsed;
                        }
                        break;
                    case "Галактика":
                        var tg = (Galaxy)Grid1.SelectedItem;
                        var tmg = new Galaxy(tg.Id, addtb2.Text);
                        context.Galaxies.Update(tmg);
                        context.SaveChanges();
                        Grid1.ItemsSource = context.Galaxies.ToList();
                        break;
                }
            }
            addtb2.Clear();
            addtb3.Clear();
            addtb4.Clear();
            addtb5.Clear();
            addcb1.SelectedIndex = -1;
            addchb1.IsChecked = false;
            addchb2.IsChecked = false;
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            using PlanetsContext context = new PlanetsContext();
            switch (_selectedTable)
            {
                case "Планета":
                    var s1 = (Planet)Grid1.SelectedItem;
                    context.Planets.Remove(s1);
                    context.SaveChanges();
                    Grid1.ItemsSource = context.Planets.ToList();
                    if (Grid1.Items.Count != 0)
                    {
                        Grid1.Columns[7].Visibility = Visibility.Collapsed;
                        Grid1.Columns[8].Visibility = Visibility.Collapsed;
                    }
                    break;
                case "Спутник":
                    var s2 = (Satellite)Grid1.SelectedItem;
                    context.Satellites.Remove(s2);
                    context.SaveChanges();
                    Grid1.ItemsSource = context.Satellites.ToList();
                    if (Grid1.Items.Count != 0)
                    {
                        Grid1.Columns[5].Visibility = Visibility.Collapsed;
                    }
                    break;
                case "Галактика":
                    var s3 = (Galaxy)Grid1.SelectedItem;
                    context.Galaxies.Remove(s3);
                    context.SaveChanges();
                    Grid1.ItemsSource = context.Galaxies.ToList();
                    break;
            }
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            _action = "Edit";
            HideAll();
            AddFrame.Visibility = Visibility.Visible;
            HideAddEl();
            using PlanetsContext context = new();
            switch (_selectedTable)
            {
                case "Планета":
                    addl2.Visibility = Visibility.Visible;
                    addl3.Visibility = Visibility.Visible;
                    addl4.Visibility = Visibility.Visible;
                    addl5.Visibility = Visibility.Visible;
                    addl6.Visibility = Visibility.Visible;
                    addl7.Visibility = Visibility.Visible;
                    addcb1.Visibility = Visibility.Visible;
                    addtb3.Visibility = Visibility.Visible;
                    addtb4.Visibility = Visibility.Visible;
                    addtb5.Visibility = Visibility.Visible;
                    addchb1.Visibility = Visibility.Visible;
                    addchb2.Visibility = Visibility.Visible;
                    addl2.Content = "ID галактики";
                    addl3.Content = "Название";
                    addl4.Content = "Радиус";
                    addl5.Content = "Температура ядра";
                    addl6.Content = "Наличие атмосферы";
                    addl7.Content = "Наличие жизни";
                    Planet temp1 = (Planet)Grid1.SelectedCells[0].Item;
                    Galaxies = context.Galaxies.ToList();
                    foreach (var g in Galaxies)
                    {
                        if (!GalaxyNames.ContainsKey(g.Id))
                        {
                            GalaxyNames.Add(g.Id, g.Name);
                        }
                    }

                    addcb1.ItemsSource = GalaxyNames.Values;
                    int i;
                    for (i = 0; i < GalaxyNames.Count; i++)
                    {
                        if (GalaxyNames.Values.ElementAt(i) == Galaxies.First(g => g.Id == temp1.GalaxyId).Name)
                        {
                            break;
                        }
                    }
                    addcb1.SelectedIndex = i;
                    addtb3.Text = temp1.Name;
                    addtb4.Text = temp1.Radius.ToString();
                    addtb5.Text = temp1.CoreTemperature.ToString();
                    if (temp1.Atmosphere == 1)
                    {
                        addchb1.IsChecked = true;
                    }

                    if (temp1.Life == 1)
                    {
                        addchb2.IsChecked = true;
                    }

                    _id = temp1.Id;
                    break;
                case "Спутник":
                    addl2.Visibility = Visibility.Visible;
                    addl3.Visibility = Visibility.Visible;
                    addl4.Visibility = Visibility.Visible;
                    addl5.Visibility = Visibility.Visible;
                    addcb1.Visibility = Visibility.Visible;
                    addtb3.Visibility = Visibility.Visible;
                    addtb4.Visibility = Visibility.Visible;
                    addtb5.Visibility = Visibility.Visible;
                    addl2.Content = "ID планеты";
                    addl3.Content = "Название";
                    addl4.Content = "Радиус";
                    addl5.Content = "Расстояние до планеты";
                    Satellite temp2 = (Satellite)Grid1.SelectedCells[0].Item;
                    Planets = context.Planets.ToList();
                    foreach (var p in Planets)
                    {
                        if (!PlanetNames.ContainsKey(p.Id))
                        {
                            PlanetNames.Add(p.Id, p.Name);
                        }
                    }
                    addcb1.ItemsSource = PlanetNames.Values;
                    int j;
                    for (j = 0; j < PlanetNames.Count; j++)
                    {
                        if (PlanetNames.Values.ElementAt(j) == Planets.First(g => g.Id == temp2.PlanetId).Name)
                        {
                            break;
                        }
                    }
                    addcb1.SelectedIndex = j;
                    addtb3.Text = temp2.Name;
                    addtb4.Text = temp2.Radius.ToString();
                    addtb5.Text = temp2.Distance.ToString();
                    _id = temp2.Id;
                    break;
                case "Галактика":
                    Galaxy temp3 = (Galaxy)Grid1.SelectedCells[0].Item;
                    addl2.Visibility = Visibility.Visible;
                    addtb2.Visibility = Visibility.Visible;
                    addl2.Content = "Название";
                    addtb2.Text = temp3.Name;
                    _id = temp3.Id;
                    break;
            }
        }

        private void ExecuteQuery_OnClick(object sender, RoutedEventArgs e)
        {
            using PlanetsContext context = new();
            switch (cb2.SelectedIndex)
            {
                case 0:
                    var l1 = context.Planets.ToList();
                    var l2 = context.Galaxies.ToList();
                    dg1.ItemsSource = l1.Where(p => p.GalaxyId == l2.Find(g => g.Name == qtb1.Text).Id);
                    if (dg1.Items.Count != 0)
                    {
                        dg1.Columns[7].Visibility = Visibility.Collapsed;
                        dg1.Columns[8].Visibility = Visibility.Collapsed;
                    }
                    break;
                case 1:
                    var l3 = context.Satellites.ToList().Count;
                    qtb1.Text = l3.ToString();
                    break;
                case 2:
                    var l4 = context.Planets.ToList();
                    var l5 = context.Satellites.ToList();
                    dg1.ItemsSource = l5.Where(s => s.PlanetId == l4.Find(p => p.Name == qtb1.Text).Id);
                    if (dg1.Items.Count != 0)
                    {
                        dg1.Columns[5].Visibility = Visibility.Collapsed;
                    }
                    break;
            }
        }

        private void Cb2_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cb2.SelectedIndex)
            {
                case 0:
                    ql2.Text = "Вывести информацию обо всех планетах из заданной галактики";
                    break;
                case 1:
                    ql2.Text = "Вывести суммарное количество спутников";
                    break;
                case 2:
                    ql2.Text = "Вывести информацию о спутниках указанной планеты";
                    break;
            }
        }
    }
}