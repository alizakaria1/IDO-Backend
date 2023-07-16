using Core.Entities;
using Store.Data;
using Microsoft.EntityFrameworkCore;

namespace Store.StatusStore
{
    public class StatusRepository : IStatusRepository
    {
        private readonly StoreContext _context;
        public StatusRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<Status> CreateStatus(Status status)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var createdStatus = await _context.Status.AddAsync(status);

                    await _context.SaveChangesAsync();

                    return createdStatus.Entity;
                }
                catch (Exception ex)
                {
                    throw ex;
                } 
            }
        }

        public async Task<List<Status>> GetStatuses()
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var statuses = await _context.Status
                        .Include(x => x.ToDos)
                        .ToListAsync();

                    return statuses;
                }
                catch (Exception ex)
                {
                    throw ex;
                } 
            }
        }

        public async Task<Status> UpdateStatus(Status status)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var existingStatus = await _context.Status.FindAsync(status.StatusId);

                    if (existingStatus != null)
                    {
                        existingStatus.StatusName = status.StatusName;

                        await _context.SaveChangesAsync();

                        return status;
                    }

                    return null;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
