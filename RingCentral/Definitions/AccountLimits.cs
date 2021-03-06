namespace RingCentral
{
    public partial class AccountLimits
    {
        // The maximum number of free softphone digital lines per user extension
        public long? @freeSoftPhoneLinesPerExtension { get; set; }
        // The maximum number of participants in RingCentral Meeting hosted by this account's user
        public long? @meetingSize { get; set; }
        // The maximum number of extensions which can be included in the list of users monitored for Presence
        public long? @maxMonitoredExtensionsPerUser { get; set; }
    }
}
