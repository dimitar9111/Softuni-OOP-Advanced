using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_TrafficLights
{
    public class Program
    {
        public static void Main()
        {
            var tokens = Console.ReadLine().Split().ToList();
            var trafficLights = new List<TrafficLight>();

            foreach (var token in tokens)
            {
                var check = Enum.TryParse(typeof(Light), token, out object color);
                if (check)
                {
                    trafficLights.Add(new TrafficLight((Light)color));
                }
            }

            var count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                foreach (var trafficLight in trafficLights)
                {
                    trafficLight.ChangeLight();
                }

                Console.WriteLine(string.Join(" ", trafficLights));
            }
        }
    }
}
