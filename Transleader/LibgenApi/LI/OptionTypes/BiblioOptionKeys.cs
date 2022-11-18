
namespace LibgenApi.LI.OptionTypes
{
    public struct BiblioOptionKeys
    {
        public Option Name { get; set; }

        public string Value { get; set; }

        public BiblioOptionKeys(Option name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
