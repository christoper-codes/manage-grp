namespace manage_grp.Server.Helpers
{
    public static class DateHelper
    {
        public static string ToFriendlyDateTime(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
