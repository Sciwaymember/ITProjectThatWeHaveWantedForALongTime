using LibgenApi.LI.OptionTypes;
using LibgenApi.LI.OptionTypes.AddKeysEnums;
using LibgenApi.LI.OptionTypes.FieldsEnums;
using System.Collections.Specialized;

namespace LibgenApi.LI
{
    public class BiblioController :
        IAuthorsRequester,
        IEditionsRequester,
        IFilesRequester,
        IPublishersRequester,
        ISeriasRequester,
        IWorksRequester
    {
        private HttpClient _client;

        public BiblioController()
        {
            _client = new HttpClient();
        }

        public BiblioController(HttpClient client)
        {
            _client = client;
        }

        async Task<HttpResponseMessage> IAuthorsRequester.FindById(
            int[] ids, AuthorFields[]? fields = null, AuthorAddKeys[]? addkeys = null)
        {
            return await FindById(
                BiblioObject.a,
                ids,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null
                );
        }

        async Task<HttpResponseMessage> IAuthorsRequester.GetDateArea(
            DateMode mode, DateTime timefirst, DateTime? timelast = null,
            AuthorFields[]? fields = null, AuthorAddKeys[]? addkeys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null)
        {
            return await GetNewerArea(
                BiblioObject.a,
                mode, timefirst, timelast,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null,
                topic, limit1, limit2
                );
        }

        async Task<HttpResponseMessage> IAuthorsRequester.GetIdArea(
            int id_start, int? id_end = null,
            AuthorFields[]? fields = null, AuthorAddKeys[]? addkeys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null)
        {
            return await GetIdArea(
                BiblioObject.a,
                id_start, id_end,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null,
                topic, limit1, limit2
                );
        }


        async Task<HttpResponseMessage> IEditionsRequester.FindById(
            int[] ids, EditionFields[]? fields = null, EditionAddKeys[]? addkeys = null)
        {
            return await FindById(
                BiblioObject.e,
                ids,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null
                );
        }

        async Task<HttpResponseMessage> IEditionsRequester.FindByDoi(
            string doi, EditionFields[]? fields = null, EditionAddKeys[]? addkeys = null)
        {
            return await FindEditionByDoi(
                BiblioObject.e,
                doi,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null
                );
        }

        async Task<HttpResponseMessage> IEditionsRequester.FindByDois(
            string[] dois, EditionFields[]? fields = null, EditionAddKeys[]? addkeys = null)
        {
            return await FindEditionByDois(
                BiblioObject.e,
                dois,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null
                );
        }

        async Task<HttpResponseMessage> IEditionsRequester.FindByIsbn(
            string isbn, EditionFields[]? fields = null, EditionAddKeys[]? addkeys = null)
        {
            return await FindEditionByIsbn(
                BiblioObject.e,
                isbn,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null
                );
        }

        async Task<HttpResponseMessage> IEditionsRequester.GetDateArea(
            DateMode mode, DateTime timefirst, DateTime? timelast = null,
            EditionFields[]? fields = null, EditionAddKeys[]? addkeys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null)
        {
            return await GetNewerArea(
                BiblioObject.e,
                mode, timefirst, timelast,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null,
                topic, limit1, limit2
                );
        }

        async Task<HttpResponseMessage> IEditionsRequester.GetIdArea(
            int id_start, int? id_end = null,
            EditionFields[]? fields = null, EditionAddKeys[]? addkeys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null)
        {
            return await GetIdArea(
                BiblioObject.e,
                id_start, id_end,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null,
                topic, limit1, limit2
                );
        }

        async Task<HttpResponseMessage> IFilesRequester.FindById(
            int[] ids, FileFields[]? fields = null, FileAddKeys[]? addkeys = null)
        {
            return await FindById(
                BiblioObject.f,
                ids,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null
                );
        }

        async Task<HttpResponseMessage> IFilesRequester.FindByMd5(
            string md5, FileFields[]? fields = null, FileAddKeys[]? addkeys = null)
        {
            return await FindFileByMd5(
                BiblioObject.f,
                md5,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null
                );
        }

        async Task<HttpResponseMessage> IFilesRequester.GetDateArea(
            DateMode mode, DateTime timefirst, DateTime? timelast = null,
            FileFields[]? fields = null, FileAddKeys[]? addkeys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null)
        {
            return await GetNewerArea(
                BiblioObject.f,
                mode, timefirst, timelast,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null,
                topic, limit1, limit2
                );
        }

        async Task<HttpResponseMessage> IFilesRequester.GetIdArea(
            int id_start, int? id_end = null,
            FileFields[]? fields = null, FileAddKeys[]? addkeys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null)
        {
            return await GetIdArea(
                BiblioObject.f,
                id_start, id_end,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null,
                topic, limit1, limit2
                );
        }

        async Task<HttpResponseMessage> IPublishersRequester.FindById(
            int[] ids, PublisherFields[]? fields = null, PublisherAddKeys[]? addkeys = null)
        {
            return await FindById(
                BiblioObject.p,
                ids,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null
                );
        }

        async Task<HttpResponseMessage> IPublishersRequester.GetDateArea(
            DateMode mode, DateTime timefirst, DateTime? timelast = null,
            PublisherFields[]? fields = null, PublisherAddKeys[]? addkeys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null)
        {
            return await GetNewerArea(
                BiblioObject.p,
                mode, timefirst, timelast,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null,
                topic, limit1, limit2
                );
        }

        async Task<HttpResponseMessage> IPublishersRequester.GetIdArea(
            int id_start, int? id_end = null,
            PublisherFields[]? fields = null, PublisherAddKeys[]? addkeys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null)
        {
            return await GetIdArea(
                BiblioObject.p,
                id_start, id_end,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null,
                topic, limit1, limit2
                );
        }

        async Task<HttpResponseMessage> ISeriasRequester.FindById(
            int[] ids, SeriaFields[]? fields = null, SeriaAddKeys[]? addkeys = null)
        {
            return await FindById(
                BiblioObject.s,
                ids,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null
                );
        }

        async Task<HttpResponseMessage> ISeriasRequester.GetDateArea(
            DateMode mode, DateTime timefirst, DateTime? timelast = null,
            SeriaFields[]? fields = null, SeriaAddKeys[]? addkeys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null)
        {
            return await GetNewerArea(
                BiblioObject.s,
                mode, timefirst, timelast,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null,
                topic, limit1, limit2
                );
        }

        async Task<HttpResponseMessage> ISeriasRequester.GetIdArea(
            int id_start, int? id_end = null,
            SeriaFields[]? fields = null, SeriaAddKeys[]? addkeys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null)
        {
            return await GetIdArea(
                BiblioObject.s,
                id_start, id_end,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null,
                topic, limit1, limit2
                );
        }

        async Task<HttpResponseMessage> IWorksRequester.FindById(
            int[] ids, WorkFields[]? fields = null, WorkAddKeys[]? addkeys = null)
        {
            return await FindById(
                BiblioObject.w,
                ids,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null
                );
        }

        async Task<HttpResponseMessage> IWorksRequester.GetDateArea(
            DateMode mode, DateTime timefirst, DateTime? timelast = null,
            WorkFields[]? fields = null, WorkAddKeys[]? addkeys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null)
        {
            return await GetNewerArea(
                BiblioObject.w,
                mode, timefirst, timelast,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null,
                topic, limit1, limit2
                );
        }

        async Task<HttpResponseMessage> IWorksRequester.GetIdArea(
            int id_start, int? id_end = null,
            WorkFields[]? fields = null, WorkAddKeys[]? addkeys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null)
        {
            return await GetIdArea(
                BiblioObject.w,
                id_start, id_end,
                fields != null && fields.Count() != 0 ? fields.Select(f => f.ToString()).ToArray() : null,
                addkeys != null && addkeys.Count() != 0 ? addkeys.Select(k => (int)k).ToArray() : null,
                topic, limit1, limit2
                );
        }

        private NameValueCollection FieldsAndKeysStringConverter(
           string[]? fields, int[]? addkeys)
        {
            string? fieldsString = null;
            string? addkeysString = null;

            if (fields != null && fields.Count() != 0)
            {
                fieldsString = fields.First().ToString();
                for (int i = 1; i < fields.Length; i++)
                {
                    fieldsString += "," + fields[i];
                }
            }

            if (addkeys != null && addkeys.Count() != 0)
            {
                addkeysString = addkeys.First().ToString();
                for (int i = 1; i < addkeys.Length; i++)
                {
                    addkeysString += "," + addkeys[i];
                }
            }

            NameValueCollection nameValueCollection = new NameValueCollection();
            nameValueCollection["fields"] = fieldsString;
            nameValueCollection["addkeys"] = addkeysString;

            return nameValueCollection;
        }

        private async Task<HttpResponseMessage> FindById(
            BiblioObject objectType, int[] ids, string[]? fields, int[]? addkeys)
        {
            string idsString = ids.Count() != 0 ? ids.First().ToString() : throw new ArgumentNullException();
            for (int i = 1; i < ids.Length; i++)
            {
                idsString += "," + ids[i];
            }

            NameValueCollection nameValueCollection = FieldsAndKeysStringConverter(fields, addkeys);
            string? fieldsString = nameValueCollection["fields"];
            string? addkeysString = nameValueCollection["addkeys"];

            string url = new LiUrl(
                    objectType, new BiblioOptionKeys[] {
                        new BiblioOptionKeys(Option.ids, idsString),
                        new BiblioOptionKeys(Option.fields, fieldsString),
                        new BiblioOptionKeys(Option.addkeys, addkeysString)
                    }
                    ).ToString();

            HttpResponseMessage result = await _client.GetAsync(url.ToString());

            return result;
        }

        private async Task<HttpResponseMessage> GetNewerArea(
            BiblioObject objectType,
            DateMode mode, DateTime timefirst, DateTime? timelast,
            string[]? fields, int[]? addkeys,
            Topic? topic, int? limit1, int? limit2)
        {
            if (limit1 == null && limit2 != null)
            {
                throw new NullReferenceException("limit1 must be setted up, if limit2 was");
            }

            NameValueCollection nameValueCollection = FieldsAndKeysStringConverter(fields, addkeys);
            string? fieldsString = nameValueCollection["fields"];
            string? addkeysString = nameValueCollection["addkeys"];

            LiUrl url = new LiUrl(
                    objectType, new BiblioOptionKeys[] {
                    new BiblioOptionKeys(Option.mode, mode.ToString()),
                    new BiblioOptionKeys(Option.timefirst, timefirst.ToString()),
                    new BiblioOptionKeys(Option.timelast, timelast.ToString()),
                    new BiblioOptionKeys(Option.fields, fieldsString),
                    new BiblioOptionKeys(Option.addkeys, addkeysString),
                    new BiblioOptionKeys(Option.topic, topic.ToString()),
                    new BiblioOptionKeys(Option.limit1, limit1.ToString()),
                    new BiblioOptionKeys(Option.limit2, limit2.ToString()) }
                    );

            HttpResponseMessage result = await _client.GetAsync(url.ToString());

            return result;
        }

        private async Task<HttpResponseMessage> GetIdArea(
           BiblioObject objectType,
           int id_start, int? id_end,
           string[]? fields, int[]? addkeys,
           Topic? topic, int? limit1, int? limit2)
        {
            if (limit1 == null && limit2 != null)
            {
                throw new NullReferenceException("limit1 must be setted up, if limit2 was");
            }

            NameValueCollection nameValueCollection = FieldsAndKeysStringConverter(fields, addkeys);
            string? fieldsString = nameValueCollection["fields"];
            string? addkeysString = nameValueCollection["addkeys"];

            LiUrl url = new LiUrl(
                    objectType, new BiblioOptionKeys[] {
                    new BiblioOptionKeys(Option.id_start, id_start.ToString()),
                    new BiblioOptionKeys(Option.id_end, id_end.ToString()),
                    new BiblioOptionKeys(Option.fields, fieldsString),
                    new BiblioOptionKeys(Option.addkeys, addkeysString),
                    new BiblioOptionKeys(Option.topic, topic.ToString()),
                    new BiblioOptionKeys(Option.limit1, limit1.ToString()),
                    new BiblioOptionKeys(Option.limit2, limit2.ToString()) }
                    );

            HttpResponseMessage result = await _client.GetAsync(url.ToString());

            return result;
        }

        private async Task<HttpResponseMessage> FindEditionByDoi(
            BiblioObject objectType,
            string doi, string[]? fields, int[]? addkeys)
        {
            NameValueCollection nameValueCollection = FieldsAndKeysStringConverter(fields, addkeys);
            string? fieldsString = nameValueCollection["fields"];
            string? addkeysString = nameValueCollection["addkeys"];

            string url = new LiUrl(
                    objectType, new BiblioOptionKeys[] {
                        new BiblioOptionKeys(Option.doi, doi),
                        new BiblioOptionKeys(Option.fields, fieldsString),
                        new BiblioOptionKeys(Option.addkeys, addkeysString)
                    }
                    ).ToString();

            HttpResponseMessage result = await _client.GetAsync(url.ToString());

            return result;
        }

        private async Task<HttpResponseMessage> FindEditionByDois(
           BiblioObject objectType,
           string[] dois, string[]? fields, int[]? addkeys)
        {
            string doisString = dois.Count() != 0 ? dois.First() : throw new ArgumentNullException();
            for (int i = 1; i < dois.Length; i++)
            {
                doisString += "," + dois[i];
            }

            NameValueCollection nameValueCollection = FieldsAndKeysStringConverter(fields, addkeys);
            string? fieldsString = nameValueCollection["fields"];
            string? addkeysString = nameValueCollection["addkeys"];

            string url = new LiUrl(
                    objectType, new BiblioOptionKeys[] {
                        new BiblioOptionKeys(Option.dois, doisString),
                        new BiblioOptionKeys(Option.fields, fieldsString),
                        new BiblioOptionKeys(Option.addkeys, addkeysString)
                    }
                    ).ToString();

            HttpResponseMessage result = await _client.GetAsync(url.ToString());

            return result;
        }

        private async Task<HttpResponseMessage> FindEditionByIsbn(
            BiblioObject objectType,
            string isbn, string[]? fields, int[]? addkeys)
        {
            NameValueCollection nameValueCollection = FieldsAndKeysStringConverter(fields, addkeys);
            string? fieldsString = nameValueCollection["fields"];
            string? addkeysString = nameValueCollection["addkeys"];

            string url = new LiUrl(
                    objectType, new BiblioOptionKeys[] {
                        new BiblioOptionKeys(Option.isbn, isbn),
                        new BiblioOptionKeys(Option.fields, fieldsString),
                        new BiblioOptionKeys(Option.addkeys, addkeysString)
                    }
                    ).ToString();

            HttpResponseMessage result = await _client.GetAsync(url.ToString());

            return result;
        }

        private async Task<HttpResponseMessage> FindFileByMd5(
           BiblioObject objectType,
           string md5, string[]? fields, int[]? addkeys)
        {
            NameValueCollection nameValueCollection = FieldsAndKeysStringConverter(fields, addkeys);
            string? fieldsString = nameValueCollection["fields"];
            string? addkeysString = nameValueCollection["addkeys"];

            string url = new LiUrl(
                    objectType, new BiblioOptionKeys[] {
                        new BiblioOptionKeys(Option.md5, md5),
                        new BiblioOptionKeys(Option.fields, fieldsString),
                        new BiblioOptionKeys(Option.addkeys, addkeysString)
                    }
                    ).ToString();

            HttpResponseMessage result = await _client.GetAsync(url.ToString());

            return result;
        }
    }
}
