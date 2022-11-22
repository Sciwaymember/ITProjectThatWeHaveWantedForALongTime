using LibgenApi.LI.OptionTypes;
using LibgenApi.LI.OptionTypes.AddKeysEnums;
using LibgenApi.LI.OptionTypes.FieldsEnums;

namespace LibgenApi.LI
{
    public interface IEditionsRequester
    {
        Task<HttpResponseMessage> FindById(
            int[] ids, EditionFields[]? fields = null, EditionAddKeys[]? addkeys = null);

        Task<HttpResponseMessage> FindByDoi(
            string doi, EditionFields[]? fields = null, EditionAddKeys[]? addkeys = null);

        Task<HttpResponseMessage> FindByDois(
            string[] dois, EditionFields[]? fields = null, EditionAddKeys[]? addkeys = null);

        Task<HttpResponseMessage> FindByIsbn(
            string isbn, EditionFields[]? fields = null, EditionAddKeys[]? addkeys = null);

        Task<HttpResponseMessage> GetDateArea(
            DateMode mode, DateTime timefirs, DateTime? timelast = null,
            EditionFields[]? fields = null, EditionAddKeys[]? addkeys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null);

        Task<HttpResponseMessage> GetIdArea(
            int id_start, int? id_end = null,
            EditionFields[]? fields = null, EditionAddKeys[]? addkeys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null);
    }
}
