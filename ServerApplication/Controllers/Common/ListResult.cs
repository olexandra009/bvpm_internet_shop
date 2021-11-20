
using System.Collections.Generic;


namespace ServerApplication.Controllers.Common
{
    public class ListResult<T>
    {
        public List<T> Result { get; set; }
        public int Total { get; set; }
    }
}
