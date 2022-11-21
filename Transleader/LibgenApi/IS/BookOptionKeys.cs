
namespace LibgenApi.IS
{
    public struct BookOptionKeys
    {
        public Option Name { get; set; }

        public string Value { get; set; }

        public BookOptionKeys(Option name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
