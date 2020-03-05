namespace LoggingKata
{

    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {

            if (line == null)
            {
                logger.LogInfo("input was null");
                    return null;
               
            }
            var cells = line.Split(',');

            if (cells.Length < 3)
            {

                return null;
            }


            var latitude = double.Parse(cells[0]);

            var longitude = double.Parse(cells[1]);

            var tacoName = (cells[2]);

            TacoBell Coords = new TacoBell(tacoName, latitude, longitude);

            logger.LogInfo($"{latitude} {longitude} {tacoName}");
            return Coords;
        }
    }
}