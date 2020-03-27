using Google.Maps;
using Google.Maps.Geocoding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			ForkedMessage();

			README_QuickStart_Sample();

			DoRequestsLoop();

			if (System.Diagnostics.Debugger.IsAttached)
			{
				Console.WriteLine("Hit any key to end.");
				Console.ReadKey();
			}
		}

		private static void ForkedMessage()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("Original Project from: ");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("https://github.com/ericnewton76/gmaps-api-net");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("Forked by: ");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("Jorge Serrano");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("Forked Project in: ");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("https://github.com/ericnewton76/gmaps-api-net");
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("MAIN ACTIONS");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine("\tMigrated to .NET Core 3.1 (USING NET STANDARD 2.1)");
			Console.WriteLine("\tUses System.Text.Json instead of Newtonsoft");
			Console.WriteLine();
			Console.ResetColor();
		}

		public static void README_QuickStart_Sample()
		{
			//always need to use YOUR_API_KEY for requests.  Do this in App_Start.
			var signingInstance = new GoogleSigned("YOUR_API_KEY");
			GoogleSigned.AssignAllServices(signingInstance);

			var request = new GeocodingRequest();
			request.Address = "1600 Pennsylvania Ave NW, Washington, DC 20500";

			var response = new GeocodingService().GetResponse(request);

			//The GeocodingService class submits the request to the API web service, and returns the
			//response strongly typed as a GeocodeResponse object which may contain zero, one or more results.

			//Assuming we received at least one result, let's get some of its properties:
			if (response.Status == ServiceResponseStatus.Ok && response.Results.Count() > 0)
			{
				var result = response.Results.First();

				Console.WriteLine("Full Address: " + result.FormattedAddress);         // "1600 Pennsylvania Ave NW, Washington, DC 20500, USA"
				Console.WriteLine("Latitude: " + result.Geometry.Location.Latitude);   // 38.8976633
				Console.WriteLine("Longitude: " + result.Geometry.Location.Longitude); // -77.0365739
				Console.WriteLine();
			}
			else
				Console.WriteLine("Unable to geocode.  Status={0} and ErrorMessage={1}", response.Status, response.ErrorMessage);
		}

		public static void DoRequestsLoop()
		{
			Dictionary<string, Action> menuchoice = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);

			menuchoice.Add("G", DoGeocodeRequest);
			//menuchoice.Add("Q", null);

			ConsoleKeyInfo keypress;
			do
			{
				Console.WriteLine("Menu\n--------");
				Console.WriteLine("G)eocode request");
				Console.WriteLine("Q)uit");

				keypress = Console.ReadKey(); Console.WriteLine();

				var key = keypress.KeyChar.ToString();

				Action actionfunc = null;

				if (menuchoice.ContainsKey(key) == true)
				{
					actionfunc = menuchoice[key];

					if (actionfunc != null) actionfunc();
				}

			} while (keypress.Key != ConsoleKey.Q);
		}

		public static void DoGeocodeRequest()
		{
			//always need to use YOUR_API_KEY for requests.  Do this in App_Start.
			//GoogleSigned.AssignAllServices(new GoogleSigned("YOUR_API_KEY"));
			//commented out in the loop

			Console.WriteLine();
			Console.WriteLine("Enter an address to geocode: ");

			var geocodeAddress = Console.ReadLine();

			var request = new GeocodingRequest();
			request.Address = geocodeAddress;

			var response = new GeocodingService().GetResponse(request);

			//The GeocodingService class submits the request to the API web service, and returns the
			//response strongly typed as a GeocodeResponse object which may contain zero, one or more results.

			//Assuming we received at least one result, let's get some of its properties:
			if (response.Status == ServiceResponseStatus.Ok && response.Results.Count() > 0)
			{
				var result = response.Results.First();

				Console.WriteLine("Full Address: " + result.FormattedAddress);         // "1600 Pennsylvania Ave NW, Washington, DC 20500, USA"
				Console.WriteLine("Latitude: " + result.Geometry.Location.Latitude);   // 38.8976633
				Console.WriteLine("Longitude: " + result.Geometry.Location.Longitude); // -77.0365739
				Console.WriteLine();
			}
			else
				Console.WriteLine("Unable to geocode.  Status={0} and ErrorMessage={1}", response.Status, response.ErrorMessage);
		}
	}
}