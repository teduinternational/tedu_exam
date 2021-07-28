﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Identity.Admin.BusinessLogic.Dtos.Log
{
    public class LogsDto
    {
        public LogsDto()
        {
            Logs = new List<LogDto>();
        }

        [Required]
        public DateTime? DeleteOlderThan { get; set; }

        public List<LogDto> Logs { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }
}
