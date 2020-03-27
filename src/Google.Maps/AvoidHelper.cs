using System;
using System.Text;

namespace Google.Maps
{
	internal static class AvoidHelper
	{
		internal static string MakeAvoidString(Avoid avoid)
		{
			var stringBuilder = new StringBuilder();

			foreach (Avoid avoidFlag in Enum.GetValues(typeof(Avoid)))
				if (avoidFlag != 0 && ((avoid & avoidFlag) == avoidFlag))
					stringBuilder.Append((stringBuilder.Length > 0 ? "|" : "") + avoidFlag.ToString());

			return stringBuilder.ToString();
		}
	}
}