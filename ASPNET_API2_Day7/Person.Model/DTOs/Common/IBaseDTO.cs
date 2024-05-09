using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Model.DTOs.Common
{
    public interface IBaseDTO<T>
    {
        T? Data { get; set; }
        int PageIndex { get; set; }
        int TotalCount { get; set; }

    }
}
