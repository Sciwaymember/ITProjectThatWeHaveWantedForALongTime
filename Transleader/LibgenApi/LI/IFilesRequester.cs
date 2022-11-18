using LibgenApi.LI.OptionTypes;
using LibgenApi.LI.OptionTypes.AddKeysEnums;
using LibgenApi.LI.OptionTypes.FieldsEnums;

namespace LibgenApi.LI
{
    public interface IFilesRequester
    {
        Task<HttpResponseMessage> FindById(
            int[] ids, FileFields[]? fields = null, FileAddKeys[]? add_keys = null);

        Task<HttpResponseMessage> FindByMd5(
            string md5, FileFields[]? fields = null, FileAddKeys[]? add_keys = null);

        Task<HttpResponseMessage> GetDataArea(
            DataMode mode, DateTime time_start, DateTime? time_end = null,
            FileFields[]? fields = null, FileAddKeys[]? add_keys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null);

        Task<HttpResponseMessage> GetIdArea(
            int id_start, int? id_end = null,
            FileFields[]? fields = null, FileAddKeys[]? add_keys = null,
            Topic? topic = null, int? limit1 = null, int? limit2 = null);
    }
}
