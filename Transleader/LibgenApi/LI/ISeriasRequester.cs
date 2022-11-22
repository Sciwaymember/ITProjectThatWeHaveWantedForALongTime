using LibgenApi.LI.OptionTypes;
using LibgenApi.LI.OptionTypes.AddKeysEnums;
using LibgenApi.LI.OptionTypes.FieldsEnums;


namespace LibgenApi.LI
{
    public interface ISeriasRequester
    {
        Task<HttpResponseMessage> FindById(
            int[] ids, SeriaFields[]? fields = null, SeriaAddKeys[]? add_keys = null);

        Task<HttpResponseMessage> GetDateArea(
            DateMode mode, DateTime time_start, DateTime? time_end = null,
            SeriaFields[]? fields = null, SeriaAddKeys[]? add_keys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null);

        Task<HttpResponseMessage> GetIdArea(
            int id_start, int? id_end = null,
            SeriaFields[]? fields = null, SeriaAddKeys[]? add_keys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null);
    }
}
