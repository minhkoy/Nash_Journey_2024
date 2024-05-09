using Person.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Model.DTOs.Common
{
    public class BaseDTO<T> : IBaseDTO<T>
    {
        public T? Data { get; set; }
        public int PageIndex { get; set; }
        public int TotalCount { get; set; }
    }
}
