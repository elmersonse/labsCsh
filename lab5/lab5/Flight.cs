namespace lab5
{
    public class Flight
    {
        public int PlaneId { get; set; }
        public string Destination { get; set; }
        public float SeatPrice { get; set; }

        public Flight(int planeId, string destination, float seatPrice)
        {
            PlaneId = planeId;
            Destination = destination;
            SeatPrice = seatPrice;
        }

        public override string ToString()
        {
            return PlaneId.ToString() + ',' + Destination + ',' +SeatPrice.ToString();
        }
    }
}