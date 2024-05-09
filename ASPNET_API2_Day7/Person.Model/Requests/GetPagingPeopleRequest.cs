using Person.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Model.Requests
{
    public class GetPagingPeopleRequest
    {
        public string? Name { get; set; }
        public Gender? Gender { get; set; }
        public string? BirthPlace { get; set; }
        public int PageSize { get; set; } = Constants.DefaultPageSize;
        public int PageIndex { get; set; } = Constants.DefaultPage;
    }
}
