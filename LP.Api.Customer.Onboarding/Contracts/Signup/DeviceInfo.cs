namespace LP.Api.Customer.Onboarding.Contracts.Signup
{
    public class DeviceInfo
    {
        public string Type { get; set; } = string.Empty;
        public string Browser { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string Timezone { get; set; } = string.Empty;
    }
}
