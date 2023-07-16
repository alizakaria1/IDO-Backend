using Core.Entities;

namespace Store.ToDoStore
{
    public interface IToDoRepository
    {
        Task<ToDoDto> CreateTodo(ToDoDto toDoDto);
        Task<ToDoDto> UpdateTodo(ToDoDto toDoDto);
        Task<List<ToDo>> GetAllTodos();
        Task<ToDo> GetTodoById(int id);
    }
}
