using LibgenApi.LI.OptionTypes;
using System.Collections.Specialized;
using System.Web;

namespace LibgenApi.LI
{
    public class LiUrl
    {
        private string _url = "https://libgen.li/json.php";

        private BiblioObject _obj;

        private BiblioOptionKeys[] _options;

        public LiUrl(BiblioObject obj, BiblioOptionKeys[] options)
        {
            _obj = obj;
            _options = options;
        }

        public override string ToString()
        {
            string url = "";

            UriBuilder uriBuilder = new UriBuilder(_url);
            NameValueCollection uriParams = HttpUtility.ParseQueryString(uriBuilder.Query);

            uriParams["object"] = _obj.ToString();

            for (int i = 0; i < _options.Length; i++)
            {
                BiblioOptionKeys option = _options[i];
                uriParams[option.Name.ToString()] = option.Value;
            }

            uriBuilder.Query = uriParams.ToString();
            url = uriBuilder.ToString();

            return url;
        }
    }
}
