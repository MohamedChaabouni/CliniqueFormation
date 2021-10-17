using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class BaseService
    {
        protected readonly IMapper Mapper;

        public BaseService(IMapper Mapper) 
        {
            this.Mapper = Mapper;
        }
    }
}
