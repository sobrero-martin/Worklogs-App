using Worklogs.Shared.ENUM;

namespace Worklogs.DB.Data
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        EnumRecordStatus RecordStatus { get; set; }
    }
}