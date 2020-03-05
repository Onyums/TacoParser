using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log an error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            // logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS
            // Grab the path from the name of your file

            // Now, here's the new code

            // Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            // Create a `double` variable to store the distance
            TacoBell pos1 = null;
            TacoBell pos2 = null;
            double distance = 0;


            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`


            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)

            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long
            for (int i = 0; i < locations.Length; i++)
            {
                TacoBell locA = (TacoBell)locations[i];
                GeoCoordinate CorA = new GeoCoordinate(locA.latitude, locA.longitude);
                for (int j = i + 1; j < locations.Length; j++)
                {
                    TacoBell locB = (TacoBell)locations[j];
                    GeoCoordinate CorB = new GeoCoordinate(locB.latitude, locB.longitude);
                    double temp = CorA.GetDistanceTo(CorB);
                    if (temp > distance)
                    {
                        distance = temp;
                        pos1 = locA;
                        pos2 = locB;
                    }
                }
            }
                Console.WriteLine($"{pos1.name} and {pos2.name} are {Math.Floor(distance)} meters away");
                TacoBell Ala1 = null;
                TacoBell Ala2 = null;
                double aladis = 0;
                double top = 34.99;
                double bottom = 31.018;
                double right = -84.977;
                double left = -88.477;
                for (int i = 0; i < locations.Length; i++)
                {
                    TacoBell locA = (TacoBell)locations[i];
                GeoCoordinate corA = new GeoCoordinate(locA.latitude, locA.longitude);
                if ((locA.latitude < top && locA.latitude > bottom)&&(locA.longitude < right && locA.longitude > left))
                {
                    for (int j = i+1; j < locations.Length; j++)
                    {
                        TacoBell locB = (TacoBell)locations[j];
                        GeoCoordinate corB = new GeoCoordinate(locB.latitude, locB.longitude);
                        if ((locB.latitude < top && locB.latitude > bottom) && (locB.longitude < right && locB.longitude > left)) 
                        {
                            double temp = corA.GetDistanceTo(corB);
                            if (temp > distance)
                            {
                                distance = temp;
                                pos1 = locA;
                                pos2 = locB;
                            }

                            
                        }
                    }
                }
                }

            }
            
            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.


            
        }
    }
}