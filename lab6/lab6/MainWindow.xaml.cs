using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
            cb1.ItemsSource = new HashSet<string>()
            {
                "Название",
                "Радиус",
                "Температура ядра",
                "Наличие атмосферы",
                "Наличие жизни"
            };
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Visible;
        }

        private void Cb1_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cb1.Text)
            {
                case "Название":
                    l2.Visibility = Visibility.Hidden;
                    tb2.Visibility = Visibility.Hidden;
                    break;
                case "Радиус":
                    break;
                case "Температура ядра":
                    break;
                case "Наличие атмосферы":
                    break;
                case "Наличие жизни":
                    break;
            }
        }
    }
}