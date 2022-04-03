namespace lab5
{
    public class Plane
    {
        public string PlaneType { get; set; }
        public int SeatCount { get; set; }
        public int PlaneId { get; set; }

        public Plane(string type, int seatCount, int planeId)
        { 
            PlaneType = type;
            SeatCount = seatCount;
            PlaneId = planeId;
        }

        public override string ToString()
        {
            return PlaneType + ',' + SeatCount.ToString() + ',' + PlaneId.ToString();
        }
    }
}