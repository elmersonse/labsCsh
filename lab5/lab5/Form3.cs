using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form3 : Form
    {
        private List<Plane> planes = new List<Plane>
        {
            new Plane("Boeing 747", 120, 1),
            new Plane("Boeing 737", 100, 2),
            new Plane("Mig 7", 2, 3),
            new Plane("Prikol", 600, 4),
            new Plane("Ne-prikol", 150, 5)
        };
        private List<Flight> flights = new List<Flight>
        {
            new Flight(1, "Panama", 120),
            new Flight(2, "Minsk", 30),
            new Flight(3, "Moscow", 50),
            new Flight(3, "Berlin", 130),
            new Flight(4, "London", 80),
            new Flight(5, "Tokyo", 55),
            new Flight(2, "Monako", 100),
            new Flight(1, "Paris", 40),
        };
        public Form3()
        {
            InitializeComponent();
            textBox1.Text = "100";
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            List<Plane> tempPlanes;
            List<Flight> tempFlights;

            richTextBox1.Text += "TASK 1\n";
            tempPlanes = new List<Plane>(planes.Where(p => p.PlaneType
                .ToLower()
                .Contains("boeing")));
            foreach (var p in tempPlanes)
            {
                richTextBox1.Text += p + "\n";
            }

            richTextBox1.Text += '\n';

            richTextBox1.Text += "TASK 2\n";
            tempFlights = new List<Flight>(flights.Where(f => f.Destination.StartsWith("M"))
                .Where(f => f.SeatPrice < int.Parse(textBox1.Text)));
            foreach (var f in tempFlights)
            {
                richTextBox1.Text += f + "\n";
            }

            richTextBox1.Text += '\n';

            richTextBox1.Text += "TASK 3\n";
            tempFlights = new List<Flight>(flights.OrderBy(f => f.SeatPrice));
            foreach (var f in tempFlights)
            {
                richTextBox1.Text += f + "\n";
            }

            richTextBox1.Text += '\n';

            richTextBox1.Text += "TASK 4\n";
            richTextBox1.Text += "Кол-во самолётов со вместимостью >= 150 мест\n";
            int c = planes.Count(p => p.SeatCount >= 150);
            richTextBox1.Text += c + "\n";

            richTextBox1.Text += "TASK 5\n";
            richTextBox1.Text += "Max = " + flights.Max(f => f.SeatPrice) + '\n';
            richTextBox1.Text += "Avg = " + flights.Average(f => f.SeatPrice) + '\n';
            richTextBox1.Text += "Sum = " + flights.Sum(f => f.SeatPrice) + '\n';
            richTextBox1.Text += '\n';

            richTextBox1.Text += "TASK 6\n";
            var temp1 = from tempFlight in tempFlights
                let dest = $"Destination: {tempFlight.Destination}"
                select dest;
            foreach (var t in temp1)
            {
                richTextBox1.Text += t + '\n';
            }

            richTextBox1.Text += '\n';

            richTextBox1.Text += "TASK 7\n";
            var temp2 = flights.GroupBy(f => f.PlaneId);
            foreach (var t in temp2)
            {
                richTextBox1.Text += t.Key + ": \n";
                foreach (var f in t)
                {
                    richTextBox1.Text += $"  {f.Destination},{f.SeatPrice}\n";
                }
            }

            richTextBox1.Text += '\n';

            richTextBox1.Text += "TASK 8\n";
            var temp3 = planes.Join(flights, p => p.PlaneId, f => f.PlaneId, (p, f) => new
            {
                PlaneId=p.PlaneId,
                PlaneType=p.PlaneType,
                Destination=f.Destination,
                SeatCount=p.SeatCount,
                SeatPrice=f.SeatPrice
            });
            foreach (var t in temp3)
            {
                richTextBox1.Text += $"{t.PlaneId}, {t.PlaneType}, {t.Destination}, {t.SeatCount}, {t.SeatPrice}\n";
            }
            richTextBox1.Text += '\n';
            
            richTextBox1.Text += "TASK 9\n";
            var temp4 = planes.GroupJoin(flights, p => p.PlaneId, f => f.PlaneId, (p, f) => new
            {
                PlaneType = p.PlaneType,
                Flight = f
            });
            foreach (var t in temp4)
            {
                richTextBox1.Text += $"{t.PlaneType}:";
                foreach (var f in t.Flight)
                {
                    richTextBox1.Text += $"  {f.Destination}, {f.SeatPrice}\n";
                }
            }
            richTextBox1.Text += '\n';
            
            richTextBox1.Text += "TASK 10\n";
            var temp5 = planes.All(p => p.SeatCount >= 100);
            richTextBox1.Text += $"{temp5}\n\n";
            
            richTextBox1.Text += "TASK 11\n";
            var temp6 = flights.Any(f => f.SeatPrice < 50);
            richTextBox1.Text += $"{temp6}\n\n";
        }
    }
}