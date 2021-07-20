using System.Collections.Generic;
using Media.Api.Core.ProjectAggregate;

namespace Media.Api.Web.Endpoints.ProjectEndpoints
{
    public class ProjectListResponse
    {
        public List<ProjectRecord> Projects { get; set; } = new();
    }
}
