namespace LoggingKata
{
    public class TacoBell : ITrackable
    {
        public string name;
        public double longitude;
        public double latitude;
        public TacoBell(string name, double lat, double longi)
        {
            this.name = name;
            this.longitude = longi;
            this.latitude = lat;

        }

        string ITrackable.Name
        {
            get; set;
        }
        Point ITrackable.Location
        {
            get; set;
        }
    }
}