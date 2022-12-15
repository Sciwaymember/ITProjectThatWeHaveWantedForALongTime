using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace LibgenApi.IS
{
    public class BookController
    {
        private HttpClient _client;

        public BookController()
        {
            _client = new HttpClient();
        }

        public BookController(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> FindByIdAsync(int[] ids, BookFields[]? fields = null)
        {
            string idsString = ids.Count() != 0 ? ids.First().ToString() : throw new ArgumentNullException();
            for (int i = 1; i < ids.Length; i++)
            {
                idsString += "," + ids[i];
            }

            string fieldsString = FieldsStringConverter(fields);

            string url = new IsUrl(
                    new BookOptionKeys[] {
                        new BookOptionKeys(Option.ids, idsString),
                        new BookOptionKeys(Option.fields, fieldsString),
                    }
                    ).ToString();

            HttpResponseMessage result = await _client.GetAsync(url.ToString());

            return result;
        }

        public async Task<HttpResponseMessage> GetDateAreaAsync(
            DateMode mode, DateTime timefirst, DateTime? timelast = null,
            BookFields[]? fields = null, int? limit1 = null, int? limit2 = null)
        {
            if (limit1 == null && limit2 != null)
            {
                throw new NullReferenceException("limit1 must be setted up, if limit2 was");
            }

            string fieldsString = FieldsStringConverter(fields);
            string timefirstString = DateConverter(timefirst, mode);
            string timelastString = DateConverter(timelast, mode);

            string url = new IsUrl(
                    new BookOptionKeys[] {
                        new BookOptionKeys(Option.mode, mode.ToString()),
                        new BookOptionKeys(Option.timefirst, timefirstString),
                        new BookOptionKeys(Option.timelast, timelastString),
                        new BookOptionKeys(Option.fields, fieldsString),
                        new BookOptionKeys(Option.limit1, limit1.ToString()),
                        new BookOptionKeys(Option.limit2, limit2.ToString())
                    }
                    ).ToString();

            HttpResponseMessage result = await _client.GetAsync(url.ToString());

            return result;
        }

        public async Task<HttpResponseMessage> GetNewerAreaAsync(
            DateTime timenewer, int idnewer = 0,
            BookFields[]? fields = null, int? limit1 = null, int? limit2 = null,
            CancellationToken token = default)
        {
            if (limit1 == null && limit2 != null)
            {
                throw new NullReferenceException("limit1 must be setted up, if limit2 was");
            }

            string fieldsString = FieldsStringConverter(fields);
            string timenewerString = DateConverter(timenewer);

            string url = new IsUrl(
                    new BookOptionKeys[] {
                        new BookOptionKeys(Option.mode, "newer"),
                        new BookOptionKeys(Option.timenewer, timenewerString),
                        new BookOptionKeys(Option.idnewer, idnewer.ToString()),
                        new BookOptionKeys(Option.fields, fieldsString),
                        new BookOptionKeys(Option.limit1, limit1.ToString()),
                        new BookOptionKeys(Option.limit2, limit2.ToString())
                    }
                    ).ToString();

            HttpResponseMessage result = await _client.GetAsync(url.ToString(), token);

            return result;
        }

        private string FieldsStringConverter(BookFields[]? fields)
        {
            if (fields == null || fields.Count() == 0)
            {
                return "*";
            }

            string fieldsString = "*";

            if (fields != null && fields.Count() != 0)
            {
                fieldsString = fields.First().ToString();
                for (int i = 1; i < fields.Length; i++)
                {
                    fieldsString += "," + fields[i];
                }
            }

            return fieldsString;
        }

        private string DateConverter(DateTime? date, DateMode? mode = null)
        {
            string dateString = "";

            if (date == null)
            {
                return dateString;
            }

            if (mode == null)
            {
                dateString = date.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                dateString = date.Value.ToString("yyyy-MM-dd");
            }

            return dateString;
        }
    }
}
