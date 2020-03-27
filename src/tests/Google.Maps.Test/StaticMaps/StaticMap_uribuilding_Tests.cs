using FluentAssertions;
using Google.Maps.Test;
using NUnit.Framework;
using System;

namespace Google.Maps.StaticMaps
{
	[TestFixture]
	public class StaticMap_uribuilding_Tests
	{
		Uri gmapsBaseUri = new Uri("http://maps.google.com/");

		[Test]
		public void BasicUri()
		{
			var expected = Helpers.ParseQueryString("/maps/api/staticmap?center=30.1,-60.2&size=512x512");

			StaticMapRequest sm = new StaticMapRequest()
			{
				Center = new LatLng(30.1, -60.2)
			};

			Uri actualUri = sm.ToUri();
			var actual = Helpers.ParseQueryString(actualUri.PathAndQuery);

			actual.Should().BeEquivalentTo(expected);
		}
	}
}