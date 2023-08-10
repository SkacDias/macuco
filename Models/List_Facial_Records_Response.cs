using MacucoApi.Domains;
using System.Collections.Generic;

namespace MacucoApi.Models
{
    public class List_Facial_Records_Response : BaseResponse
    {
        public List<Facial_Records> Facial_Records_List { get; set; }
    }
}