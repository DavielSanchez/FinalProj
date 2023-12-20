using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProj.Application.DTO_s.Base
{
    public abstract class DTOBase
    {
        [JsonProperty("changeUser")]
        public int ChangeUser { get; set; }

        [JsonProperty("changeDate")]
        public DateTime ChangeDate { get; set; }
    }
}
