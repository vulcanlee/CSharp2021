using Geocoding;
using Geocoding.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csAddressToGPS
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IGeocoder geocoder = new GoogleGeocoder() { ApiKey = "this-is-my-optional-google-api-key" };
            IEnumerable<Address> addresses = await geocoder.GeocodeAsync("高雄市鼓山區明倫路59號");
            Console.WriteLine("Formatted: " + addresses.First().FormattedAddress);
            Console.WriteLine("Coordinates: " + addresses.First().Coordinates.Latitude + ", " + addresses.First().Coordinates.Longitude); 
        }
    }
}
