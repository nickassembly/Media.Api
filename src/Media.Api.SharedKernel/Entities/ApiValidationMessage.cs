﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.SharedKernel.Entities
{
    public class ApiValidationMessage
    {
        public int? EntityId { get; set; }
        public string Message { get; set; }

    }
}
