namespace Zen
{
#if DEVELOPMENT_BUILD || UNITY_EDITOR
    public static class AppSettings
    {
        public const string GraphQLURL = "http://localhost:7080/graphql";
        public const string AddressablesURL = "http://localhost:4200/assets/unity/ServerData";
        public const string ColyseusURL = "ws://localhost:7080";

    }
#else
    public static class AppSettings
    {
        public const string GraphQLURL = "https://api.zen.com/graphql";
        public const string AddressablesURL = "http://zen.com/assets/unity/ServerData";
        public const string ColyseusURL = "ws://api.zen.com";
    }
#endif
}
