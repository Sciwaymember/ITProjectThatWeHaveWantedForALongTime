using LibgenApi.LI.OptionTypes;
using LibgenApi.LI.OptionTypes.AddKeysEnums;
using LibgenApi.LI.OptionTypes.FieldsEnums;

namespace LibgenApi.LI
{
    public interface IAuthorsRequester
    {

        Task<HttpResponseMessage> FindById(
            int[] ids, AuthorFields[]? fields = null, AuthorAddKeys[]? addkeys = null);

        Task<HttpResponseMessage> GetDataArea(
            DataMode mode, DateTime timefirst, DateTime? timelast = null,
            AuthorFields[]? fields = null, AuthorAddKeys[]? addkeys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null);

        Task<HttpResponseMessage> GetIdArea(
            int id_start, int? id_end = null,
            AuthorFields[]? fields = null, AuthorAddKeys[]? addkeys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null);
    }
}
