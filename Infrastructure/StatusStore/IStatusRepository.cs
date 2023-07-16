using Core.Entities;

namespace Store.StatusStore
{
    public interface IStatusRepository
    {
        Task<Status> CreateStatus(Status status);
        Task<Status> UpdateStatus(Status status);
        Task<List<Status>> GetStatuses();
    }
}
