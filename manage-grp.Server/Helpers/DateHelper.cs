namespace manage_grp.Server.Helpers
{
    public static class DateHelper
    {
        public static string ToFriendlyDateTime(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static DateTime GetTimeInTimeZone()
        {
            TimeZoneInfo mexicoTimeZone;

            try
            {
                mexicoTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");
            }
            catch (TimeZoneNotFoundException)
            {
                mexicoTimeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Mexico_City");
            }

            DateTime utcNow = DateTime.UtcNow;

            DateTime mexicoTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, mexicoTimeZone);

            return mexicoTime;
        }
    }
}