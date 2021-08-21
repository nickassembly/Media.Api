﻿using AutoMapper;
using Media.Api.Core.BookAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.List
{
    public class BookListProfile : Profile
    {
        public BookListProfile()
        {
            CreateMap<Book, BookListApiModel>();
        }
    }
}