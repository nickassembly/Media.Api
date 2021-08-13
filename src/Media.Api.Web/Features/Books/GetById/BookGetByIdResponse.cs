﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.GetById
{
    public class BookGetByIdResponse
    {
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public object Result { get; set; } // TODO: What does result object look like?
        public string ToastMessage { get; set; }
        public string ErrorMessage { get; set; }

    }
}