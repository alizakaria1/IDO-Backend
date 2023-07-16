using Core.Entities;
using System.Transactions;

namespace Store.StatusStore
{
    public class StatusManager
    {
        private IStatusRepository _statusRepository;
        public StatusManager(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;   
        }
        public async Task<Result> CreateStatus(Status status)
        {
            using(var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var createdStatus = await _statusRepository.CreateStatus(status);
                    scope.Complete();
                    return Result.Ok(createdStatus);
                }
                catch (Exception ex)
                {

                    return Result.Error(ex.Message);
                }
            }
        }

        public async Task<Result> UpdateStatus(Status status)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var updatedStatus = await _statusRepository.UpdateStatus(status);

                    if(updatedStatus == null)
                    {
                        return Result.Ok("no status found");
                    }

                    scope.Complete();

                    return Result.Ok(updatedStatus);
                }
                catch (Exception ex)
                {

                    return Result.Error(ex.Message);
                }
            }
        }

        public async Task<Result> GetStatuses()
        {
            try
            {
                var statuses = await _statusRepository.GetStatuses();

                if (!statuses.Any())
                {
                    return Result.Ok("no statuses are found");
                }

                foreach (var status in statuses)
                {
                    status.ToDos = status.ToDos.OrderByDescending(x => x.TodoId).ToList();
                }

                return Result.Ok(statuses);
            }
            catch (Exception ex)
            {

                return Result.Error(ex.Message);
            }
        }
    }
}
