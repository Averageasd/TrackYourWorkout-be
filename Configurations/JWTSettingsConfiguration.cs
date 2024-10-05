namespace TrackYourWorkout.Configurations
{

    // configuration class that contains Key, Issuer and Audience mapped
    // from appsettings.json
    public class JWTSettingsConfiguration
    {
        public string Key { get; set; } 
        public string Issuer { get; set; }
        public string Audience { get; set; }

    }
}
