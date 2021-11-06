using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
    public class CreatePollModel
    {
        public string CreateTitle { get; set; }

        public string UpdateDescription { get; set; }

        public string OpinionOne { get; set; }

        public string OpinionTwo { get; set; }
    }
}
