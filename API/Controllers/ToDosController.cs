using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.StatusStore;
using Store.ToDoStore;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private ToDoManager _toDoManager;
        public ToDosController(ToDoManager toDoManager)
        {
            _toDoManager = toDoManager;
        }

        [Route("GetAllTodos")]
        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            try
            {
                var todos = await _toDoManager.GetAllTodos();

                return Ok(todos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("GetTodoById")]
        [HttpGet]
        public async Task<IActionResult> GetTodoById(int id)
        {
            try
            {
                var todo = await _toDoManager.GetTodoById(id);

                return Ok(todo);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("CreateTodo")]
        [HttpPost]
        public async Task<IActionResult> CreateTodo(ToDoDto toDoDto)
        {
            try
            {
                var createdTodo = await _toDoManager.CreateTodo(toDoDto);

                return Ok(createdTodo);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("UpdateTodo")]
        [HttpPut]
        public async Task<IActionResult> UpdateTodo(ToDoDto toDoDto)
        {
            try
            {
                var updatedTodo = await _toDoManager.UpdateTodo(toDoDto);

                return Ok(updatedTodo);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
