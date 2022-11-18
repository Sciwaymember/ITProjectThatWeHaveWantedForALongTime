using LibgenApi.LI.OptionTypes;
using LibgenApi.LI.OptionTypes.AddKeysEnums;
using LibgenApi.LI.OptionTypes.FieldsEnums;

namespace LibgenApi.LI
{
    public interface IWorksRequester
    {
        Task<HttpResponseMessage> FindById(
            int[] ids, WorkFields[]? fields = null, WorkAddKeys[]? add_keys = null);

        Task<HttpResponseMessage> GetDataArea(
            DataMode mode, DateTime time_start, DateTime? time_end = null,
            WorkFields[]? fields = null, WorkAddKeys[]? add_keys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null);

        Task<HttpResponseMessage> GetIdArea(
            int id_start, int? id_end = null,
            WorkFields[]? fields = null, WorkAddKeys[]? add_keys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null);
    }
}
