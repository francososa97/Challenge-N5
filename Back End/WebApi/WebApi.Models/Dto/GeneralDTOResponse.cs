using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models.Dto
{
    public class GeneralDTOResponse
    {
        public bool IsOk { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public List<PermisionsDTO> Results {get; set; }
        public PermisionsDTO Result {get; set;}
    }
}
