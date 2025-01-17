﻿using System.Collections.Generic;

namespace Shrooms.Premium.DataTransferObjects.Models
{
    public class MobileBookOfficeLogsDto
    {
        public int BookOfficeId { get; set; }

        public int Quantity { get; set; }

        public IEnumerable<string> LogsUserIDs { get; set; }

        public int BookId { get; set; }

        public int OfficeId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }
    }
}
