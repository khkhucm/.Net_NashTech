using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment01.Models.RequestModels;

namespace Assignment01.Services
{
    public class TasksService : ITasksService
    {
        private static List<NewTaskRequestModel> _tasksList = new List<NewTaskRequestModel>(){
        new NewTaskRequestModel{
            Id = Guid.NewGuid(),
            Title = "Task 01",
            IsCompleted = false
        },
        new NewTaskRequestModel{
            Id = Guid.NewGuid(),
            Title = "Task 02",
            IsCompleted = true
        },
        new NewTaskRequestModel{
            Id = Guid.NewGuid(),
            Title = "Task 03",
            IsCompleted = true
        }
    };
        public List<NewTaskRequestModel> GetAll()
        {
            return _tasksList;
        }

        public NewTaskRequestModel? GetOne(Guid id)
        {
            return _tasksList.FirstOrDefault(t => t.Id == id);
        }

        public NewTaskRequestModel AddTask(NewTaskRequestModel taskRequestModel)
        {
            var newTask = new NewTaskRequestModel
            {
                Id = Guid.NewGuid(),
                Title = taskRequestModel.Title,
                IsCompleted = taskRequestModel.IsCompleted
            };
            _tasksList.Add(newTask);

            return newTask;
        }

        public NewTaskRequestModel? DeleteTask(Guid id)
        {
            var deleteTask = _tasksList.FirstOrDefault(d => d.Id == id);
            if (deleteTask != null)
            {
                var result = deleteTask;
                _tasksList.Remove(deleteTask);
                return result;
            }

            return null;
        }

        public NewTaskRequestModel EditTask(NewTaskRequestModel taskRequestModel)
        {
            var edit = _tasksList.FirstOrDefault(t => t.Id == taskRequestModel.Id);
            if (edit != null)
            {
                edit.Title = taskRequestModel.Title;
                edit.IsCompleted = taskRequestModel.IsCompleted;
                return edit;
            }
            return null!;
        }

        public Task<List<NewTaskRequestModel>> AddBulkTasks(List<NewTaskRequestModel> tasks)
        {
            _tasksList.AddRange(tasks);
            return Task.FromResult(tasks);
        }

        public Task<List<NewTaskRequestModel>> DeleteBulkTasks(List<Guid> ids)
        {
            foreach (var id in ids)
            {
                var deleteTask = _tasksList.FirstOrDefault(d => d.Id == id);
                if (deleteTask != null)
                {
                    _tasksList.Remove(deleteTask);
                }
            }

            return Task.FromResult(_tasksList);
        }
    }
}