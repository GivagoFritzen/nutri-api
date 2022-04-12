namespace CrossCutting.Helpers
{
    public static class StringHelper
    {
        public static string GetEventName(string name)
        {
            return name.Replace("Event", "")
                .Replace("ViewModel", "")
                .Replace("Entity", "");
        }
    }
}
