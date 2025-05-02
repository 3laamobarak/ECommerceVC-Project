using Mapster;
using ECommerceDTOs;
using EcommercModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Mapping
{
    public class MapsterConfig
    {
        public void Configure()
        {
            // TypeAdapterConfig<Book, BookDTO>.NewConfig()
            //     .Map(dest => dest.AuthorName, src => src.Author.Name);
        }
    }
}
