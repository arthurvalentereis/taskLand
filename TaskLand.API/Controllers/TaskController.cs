using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TaskLand.API.Controllers.Base;
using TaskLand.API.DTO.Request;
using TaskLand.API.DTO.Response;
using TaskLand.API.Interfaces.Services;
using TaskLand.API.Model;

namespace TaskLand.API.Controllers
{
    public class TaskController : BaseController
    {
        private ITaskService _taskService;
        public TaskController(
            ITaskService taskService) : base()

        {
            _taskService = taskService;
        }

   

        [HttpGet("task")]
        [ProducesResponseType(typeof(List<ResponseTask>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Busca uma lista de task"
        )]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> List()
        {
            try
            {
                var task = await _taskService.List();
                return Ok(task);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(List<ResponseTask>), StatusCodes.Status201Created)]
        [SwaggerOperation(
            Summary = "Busca uma lista de task"
        )]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromBody] RequestTaskCreate taskRequest)
        {
            try
            {
                var taskCreated = await _taskService.Create(taskRequest);
                return Ok(taskCreated);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("task/{id}")]
        [ProducesResponseType(typeof(ResponseTask), 200)]
        [SwaggerOperation(
            Summary = "Busca uma task através do ID"
        )]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var task = await _taskService.GetTask(id);
                return Ok(task);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("update/{id}")]
        [ProducesResponseType(typeof(ResponseTask), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Atualiza uma task"
        )]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(long id, [FromBody] RequestTaskUpdate taskRequest )
        {
            try
            {
                var taskCreated = await _taskService.Update(id,taskRequest);
                return Ok(taskCreated);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(typeof(ResponseTask), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Deleta uma task"
        )]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var taskCreated = await _taskService.Delete(id);
                return Ok(taskCreated);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
