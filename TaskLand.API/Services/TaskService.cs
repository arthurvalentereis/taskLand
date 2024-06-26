using System.Collections.Generic;
using TaskLand.API.DTO.Request;
using TaskLand.API.Interfaces.Mappers;
using TaskLand.API.Interfaces.Repositories.Base;
using TaskLand.API.Interfaces.Services;

namespace TaskLand.API.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITaskMapperService _taskMapperService;
        public TaskService(IUnitOfWork unitOfWork, ITaskMapperService taskMapperService)
        {
            _unitOfWork = unitOfWork;
            _taskMapperService = taskMapperService;
        }

        public async Task<Entities.Task> Create(RequestTaskCreate taskRequest)
        {
            var newTask = _taskMapperService.ToEntity(taskRequest);
            var taskCreated = await _unitOfWork.TaskRepository.AddAsync(newTask);
            _unitOfWork.SaveChanges();
            return taskCreated;
        }

        public async Task<Entities.Task> Update(RequestTaskUpdate taskRequest)
        {
            var taskToUpdate = _taskMapperService.ToEntity(taskRequest);
            var updatedTask = await _unitOfWork.TaskRepository.UpdateAsync(taskToUpdate);
            return updatedTask;
        }

        public async Task<Entities.Task> Delete(long taskId)
        {
            var taskToDelete = await GetTask(taskId);
            _unitOfWork.TaskRepository.Delete(taskToDelete);
            return taskToDelete;
        }

        public async Task<Entities.Task> GetTask(long taskId)
        {
            var task = await _unitOfWork.TaskRepository.GetByIdAsync(taskId);
            if (task is null) throw new KeyNotFoundException("task id not found");
            return task;
        }
        public async Task<List<Entities.Task>> List()
        {
            return await _unitOfWork.TaskRepository.ListAsync();
        }
    }
}
