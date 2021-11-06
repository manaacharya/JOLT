using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
    public class CreatePollModel
    {
        public string CreateTitle { get; set; }

        public string CreateDescription { get; set; }

        public string CreateOpinionOne { get; set; }

        public string CreateOpinionTwo { get; set; }
    }
}
