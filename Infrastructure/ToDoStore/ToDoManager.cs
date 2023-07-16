using Core;
using Core.Entities;
using Core.Enums;
using System.Transactions;

namespace Store.ToDoStore
{
    public class ToDoManager
    {
        private IToDoRepository _toDoRepository;

        public ToDoManager(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;   
        }

        public async Task<Result> CreateTodo(ToDoDto toDoDto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (!Enum.TryParse(typeof(Importance.Priority), toDoDto.Importance, out var priority))
                    {
                        return Result.Error("Invalid priority value.");
                    }

                    if (!Enum.TryParse(typeof(TimeFrame.Time), toDoDto.TimeFrame, out var time))
                    {
                        return Result.Error("Invalid time frame value.");
                    }

                    if(toDoDto.StatusId== 0)
                    {
                        toDoDto.StatusId = Constants.todoState;
                    }

                    var createdTodo = await _toDoRepository.CreateTodo(toDoDto);
                    scope.Complete();
                    return Result.Ok(createdTodo);
                }
                catch (Exception ex)
                {
                    return Result.Error(ex.Message);
                }
            }
        }

        public async Task<Result> UpdateTodo(ToDoDto toDoDto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var updatedTodo = await _toDoRepository.UpdateTodo(toDoDto);

                    if(updatedTodo == null)
                    {
                        return Result.Ok("todo not found");
                    }

                    scope.Complete();

                    return Result.Ok(updatedTodo);
                }
                catch (Exception ex)
                {
                    return Result.Error(ex.Message);
                }
            }
        }

        public async Task<Result> GetAllTodos()
        {
            try
            {
                var todos = await _toDoRepository.GetAllTodos();

                if(!todos.Any())
                {
                    return Result.Ok("no todos are created");
                }

                
                return Result.Ok(todos);
            }
            catch (Exception ex)
            {

                return Result.Error(ex.Message);
            }
        }

        public async Task<Result> GetTodoById(int id)
        {
            try
            {
                var todo = await _toDoRepository.GetTodoById(id);

                return Result.Ok(todo);
            }
            catch (Exception ex)
            {

                return Result.Error(ex.Message);
            }
        }
    }
}
