using Newtonsoft.Json;

namespace MusicApp.Songs.GetYearsReport
{
    public class YearReportDto
    {
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("months")]
        public int[] Months { get; set; }
    }
}
