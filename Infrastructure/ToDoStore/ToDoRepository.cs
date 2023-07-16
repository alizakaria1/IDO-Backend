using Core.Entities;
using Store.Data;
using Microsoft.EntityFrameworkCore;

namespace Store.ToDoStore
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly StoreContext _context;
        public ToDoRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<ToDoDto> CreateTodo(ToDoDto toDoDto)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var todo = new ToDo
                    {
                        Title= toDoDto.Title,
                        DueDate= toDoDto.DueDate.ToString("dd/MM/yyyy").Replace("-", "/"),
                        EstimatedTime= toDoDto.EstimatedTime,
                        TimeFrame= toDoDto.TimeFrame,
                        Importance= toDoDto.Importance,
                        Category = toDoDto.Category,
                        StatusId= toDoDto.StatusId,
                    };

                    var createdToDo = await _context.ToDo.AddAsync(todo);

                    createdToDo.Entity.TodoId= toDoDto.TodoId;

                    await _context.SaveChangesAsync();

                    return toDoDto;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<ToDo>> GetAllTodos()
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var toDos = await _context.ToDo.ToListAsync();

                    return toDos;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public async Task<ToDo> GetTodoById(int id)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var toDo = await _context.ToDo.Include(c => c.Category).Include(s => s.Status).Where(x => x.TodoId == id).FirstOrDefaultAsync();

                    return toDo;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public async Task<ToDoDto> UpdateTodo(ToDoDto toDoDto)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var existingToDo = await _context.ToDo.FindAsync(toDoDto.TodoId);

                    if (existingToDo != null)
                    {
                        existingToDo.Title = toDoDto.Title;
                        existingToDo.EstimatedTime= toDoDto.EstimatedTime;
                        existingToDo.DueDate= toDoDto.DueDate.ToString("dd/MM/yyyy").Replace("-","/");
                        existingToDo.TimeFrame= toDoDto.TimeFrame;
                        existingToDo.Importance= toDoDto.Importance;
                        existingToDo.Category = toDoDto.Category;
                        existingToDo.StatusId= toDoDto.StatusId;

                        await _context.SaveChangesAsync();

                        return toDoDto;
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
