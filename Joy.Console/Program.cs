using System;
using System.Linq;
using Joy.Core;
namespace Joy.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var allStations = MrtManager.GetAllStations();
            var random = new Random();
            var nextLine = allStations.ToArray()[random.Next(allStations.Count())];
            System.Console.WriteLine(nextLine.Name);
            var nextStation = nextLine.Stations.ToArray()[random.Next(nextLine.Stations.Count())];
            System.Console.WriteLine(nextStation.Name);
            System.Console.ReadKey();
        }
    }
}
