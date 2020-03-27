using FluentAssertions;
using Google.Maps.Test;
using NUnit.Framework;
using System;

namespace Google.Maps.StreetView
{
	[TestFixture]
	public class StreetView_uribuilding_Tests
	{
		Uri gmapsBaseUri = new Uri("http://maps.google.com/");

		[Test]
		public void BasicUri()
		{
			//arrange
			var expected = Helpers.ParseQueryString("/maps/api/streetview?location=30.1,-60.2&size=512x512");

			StreetViewRequest sm = new StreetViewRequest()
			{
				Location = new LatLng(30.1, -60.2)
				,
				Size = new MapSize(512, 512)
			};

			//act
			Uri actualUri = sm.ToUri();
			var actual = Helpers.ParseQueryString(actualUri.PathAndQuery);

			//assert
			actual.Should().BeEquivalentTo(expected);
		}

		[Test]
		public void BasicUri_heading()
		{
			//arrange
			var expected = Helpers.ParseQueryString("/maps/api/streetview?location=30.1,-60.2&size=512x512&heading=15");

			StreetViewRequest sm = new StreetViewRequest()
			{
				Location = new LatLng(30.1, -60.2)
				,
				Size = new MapSize(512, 512)
				,
				Heading = 15
			};

			//act
			Uri actualUri = sm.ToUri();
			var actual = Helpers.ParseQueryString(actualUri.PathAndQuery);

			//assert
			actual.Should().BeEquivalentTo(expected);
		}

		[Test]
		public void BasicUri_pitch()
		{
			//arrange
			var expected = Helpers.ParseQueryString("/maps/api/streetview?location=30.1,-60.2&size=512x512&pitch=15");

			StreetViewRequest sm = new StreetViewRequest()
			{
				Location = new LatLng(30.1, -60.2)
				,
				Size = new MapSize(512, 512)
				,
				Pitch = 15
			};

			//act
			Uri actualUri = sm.ToUri();
			var actual = Helpers.ParseQueryString(actualUri.PathAndQuery);

			//assert
			actual.Should().BeEquivalentTo(expected);
		}
	}
}