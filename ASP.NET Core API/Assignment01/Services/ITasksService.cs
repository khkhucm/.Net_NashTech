using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment01.Models.RequestModels;

namespace Assignment01.Services
{
    public interface ITasksService
    {
        public List<NewTaskRequestModel> GetAll();
        public NewTaskRequestModel? GetOne(Guid id);
        public NewTaskRequestModel AddTask(NewTaskRequestModel taskRequestModel);
        public NewTaskRequestModel? DeleteTask(Guid id);
        public NewTaskRequestModel EditTask(NewTaskRequestModel taskRequestModel);
        public Task<List<NewTaskRequestModel>> AddBulkTasks(List<NewTaskRequestModel> tasks);
        public Task<List<NewTaskRequestModel>> DeleteBulkTasks(List<Guid> ids);
    }
}