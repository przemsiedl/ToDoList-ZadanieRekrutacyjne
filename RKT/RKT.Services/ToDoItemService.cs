using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RKT.Db;
using RKT.Dto;
using RKT.Model;
using RKT.Services.Interfaces;

namespace RKT.Services
{
    public class ToDoItemService : ServiceBase<ToDoItemService>, IToDoItemService
    {
        public ToDoItemService(IDbContextFactory factory, ILogger<ToDoItemService> logger) : base(factory, logger)
        {
        }

        public async Task<ToDoItemDto?> Get(long id)
        {
            using (var dbContext = Factory.NewContext())
            {
                return await dbContext.ToDoItems
                    .Where(a => a.Id == id)
                    .AsView()
                    .FirstOrDefaultAsync();
            }
        }

        public async Task<List<ToDoItemDto>> GetAll(DateTime? day = null)
        {
            using (var dbContext = Factory.NewContext())
            {
                IQueryable<ToDoItem> query = dbContext.ToDoItems;

                if (day != null)
                {
                    query = query.Where(a => a.Date == day);
                }

                return await query.OrderBy(a => a.Date).AsView()
                    .ToListAsync();
            }
        }

        public async Task<ToDoItemDto> AddNew(ToDoItemDto toDoItemDto)
        {
            using (var dbContext = Factory.NewContext())
            {
                ToDoItem newItem = new ToDoItem(toDoItemDto);

                var newItemResult = await dbContext.AddAsync(newItem);
                await dbContext.SaveChangesAsync();

                return newItemResult.Entity.FromSingle().AsView().First();
            }
        }

        public async Task<ToDoItemDto> Update(long id, ToDoItemDto toDoItemDto)
        {
            using (var dbContext = Factory.NewContext())
            {
                ToDoItem? toUpdateItem = await dbContext.ToDoItems.FirstOrDefaultAsync(a => a.Id == id);

                if (toUpdateItem is null)
                {
                    throw new InvalidOperationException("ToDoItem o podanym id nie istnieje");
                }

                toUpdateItem.Update(toDoItemDto);
                var updateResult = dbContext.ToDoItems.Update(toUpdateItem);
                await dbContext.SaveChangesAsync();

                return updateResult.Entity.FromSingle().AsView().First();
            }
        }

        public async Task Remove(long id)
        {
            using (var dbContext = Factory.NewContext())
            {
                ToDoItem? toRemoveItem = await dbContext.ToDoItems.FirstOrDefaultAsync(a => a.Id == id);

                if (toRemoveItem is null)
                {
                    throw new InvalidOperationException("ToDoItem o podanym id nie istnieje.");
                }

                dbContext.ToDoItems.Remove(toRemoveItem);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
