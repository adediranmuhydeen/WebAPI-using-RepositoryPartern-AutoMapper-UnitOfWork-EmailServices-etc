using AutoMapper;
using TodoApi.Core.Domain;
using TodoApi.Core.Dtos;

namespace TodoWithAuth.Application
{
    public class MapInitializer : Profile
    {
        public MapInitializer()
        {
            CreateMap<Todo, AddTodoDto>().ReverseMap();
            CreateMap<Todo, UpdateTodoDto>().ReverseMap();
        }

    }
}