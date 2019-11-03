using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ticketswap.ViewModels
{
    public class eventViewModel
    {
        public int EVENT_ID { get; set; }

        public string EVENT_DATE { get; set; }

        public string EVENT_TIME { get; set; }

        public string EVENT_VENUE { get; set; }

        public string EVENT_ADDRESS { get; set; }

        public string EVENT_CITY { get; set; }

        public string EVENT_STATE { get; set; }

        public int? EVENT_ZIP { get; set; }

        public string EVENT_COUNTRY { get; set; }

        public string EVENT_ICON_LOCATION { get; set; }

        public string EVENT_DESCRIPTION { get; set; }

        public int? CATEGORY_ID { get; set; }

    }
}