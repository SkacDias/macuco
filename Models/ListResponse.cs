using System.Collections.Generic;

namespace MacucoApi.Models
{
    public class ListResponse : BaseResponse
    {
        public List<string> Erros { get; set; }
    }
}