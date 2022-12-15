using System.Collections.Specialized;
using System.Text;

namespace Transleader.LibraryServer.BusinessL.Settings.DbUpdater
{
    public class LaunchOptions
    {
        public const string Launch = "Launch";

        private Dictionary<string, string> PropertiesNamesAndValues = new Dictionary<string, string>();

        public string TimeNewer { get; set; } = string.Empty;

        public string IdNewer { get; set; } = string.Empty;

        public string TimeLastAdded { get; set; } = string.Empty;

        public string IdLastAdded { get; set; } = string.Empty;


        public override string ToString()
        {
            string result = "{\n";
            UpdateNameValueCollection();

            for (int i = 0; i < PropertiesNamesAndValues.Count - 1; i++)
            {
                result += $"\t\t\"{PropertiesNamesAndValues.ElementAt(i).Key}\": \"{PropertiesNamesAndValues.ElementAt(i).Value}\",\n";
            }

            result += $"\t\t\"{PropertiesNamesAndValues.Last().Key}\": \"{PropertiesNamesAndValues.Last().Value}\"\n";
            result += "\t}";

            return result;
        }

        private void UpdateNameValueCollection()
        {
            PropertiesNamesAndValues[nameof(TimeNewer)] = TimeNewer;
            PropertiesNamesAndValues[nameof(IdNewer)] = IdNewer;
            PropertiesNamesAndValues[nameof(TimeLastAdded)] = TimeLastAdded;
            PropertiesNamesAndValues[nameof(IdLastAdded)] = IdLastAdded;
        }
    }
}