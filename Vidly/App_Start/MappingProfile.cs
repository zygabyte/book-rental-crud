using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // mapping between two types.. 
            // uses reflection to do the mapping
            Mapper.CreateMap<Customer, CustomerDTO>(); // map Customer (source) to CustomerDTO (target)
            Mapper.CreateMap<CustomerDTO, Customer>(); // map CustomerDTO (source) to Customer (target)

            Mapper.CreateMap<Movie, MovieDTO>(); // map Book (source) to MovieDTO (target)
            Mapper.CreateMap<MovieDTO, Movie>(); // map MovieDTO (source) to Book (target)

            Mapper.CreateMap<Category, CategoryDTO>(); // map Category (source) to CategoryDTO (target)
            Mapper.CreateMap<CategoryDTO, Category>(); // map CategoryDTO (source) to Category (target)

            Mapper.CreateMap<Book, BookDTO>(); // map Book (source) to BookDTO (target)
            Mapper.CreateMap<BookDTO, Book>(); // map BookDTO (source) to Book (target)


            Mapper.CreateMap<MembershipType, MembershipTypeDTO>(); // map MembershipType (source) to MembershipTypeDTO (target)
            Mapper.CreateMap<Genre, GenreDTO>(); // map Genre (source) to GenreDTO (target)
            Mapper.CreateMap<Category, CategoryDTO>(); // map Category (source) to CategoryDTO (target)

            // need to load this mapper when the application is started... in gloabal.asax


        }
    }
}