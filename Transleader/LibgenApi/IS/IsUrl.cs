using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LibgenApi.IS
{
    public class IsUrl
    {
        private string _url = "https://libgen.is/json.php";

        private BookOptionKeys[] _options;

        public IsUrl(BookOptionKeys[] options)
        {
            _options = options;
        }

        public override string ToString()
        {
            string url = "";

            UriBuilder uriBuilder = new UriBuilder(_url);
            NameValueCollection uriParams = HttpUtility.ParseQueryString(uriBuilder.Query);

            for (int i = 0; i < _options.Length; i++)
            {
                BookOptionKeys option = _options[i];
                uriParams[option.Name.ToString()] = option.Value;
            }

            uriBuilder.Query = uriParams.ToString();
            url = uriBuilder.ToString();

            return url;
        }
    }
}
