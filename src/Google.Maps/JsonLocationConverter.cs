using Newtonsoft.Json.Linq;
using System;

namespace Google.Maps
{
	public class JsonLocationConverter : JsonCreationConverter<Location>
	{
		protected override Location Create(Type objectType, JObject jsonObject) =>
			new LatLng(jsonObject.Value<double>("lat"), jsonObject.Value<double>("lng"));
	}
}