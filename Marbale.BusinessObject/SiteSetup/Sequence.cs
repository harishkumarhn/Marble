namespace Marbale.BusinessObject.SiteSetup
{
    public class Sequence
    {
        public int SequenceId { get; set; }
        public string SequenceName { get; set; }
        public int Seed { get; set; }
        public int Increment { get; set; }
        public int CurrentValue { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }

    }
}
