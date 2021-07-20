﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Result;
using Media.Api.Core.ProjectAggregate;

namespace Media.Api.Core.Interfaces
{
    public interface IToDoItemSearchService
    {
        Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
        Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
    }
}
