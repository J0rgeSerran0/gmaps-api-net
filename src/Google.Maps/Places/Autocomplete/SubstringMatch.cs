using Newtonsoft.Json;

namespace Google.Maps.Places
{
	public class SubstringMatch
	{
		[JsonProperty("length")]
		public int Length { get; set; }

		[JsonProperty("offset")]
		public int Offset { get; set; }
	}
}