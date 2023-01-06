using AutoMapper;
using TodoApi.Core.Domain;
using TodoApi.Core.Dtos;
using TodoApi.Core.IRepository;
using TodoApi.Core.IService;
using TodoApiWithAuth.Data;
using TodoApiWithAuth.Utilities;

namespace TodoApiWithAuthServices
{
    internal class TodoService : ITodoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;



        public TodoService(IUnitOfWork unitOfWork, ToDoAuthContext context, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /// <summary>
        /// 
        /// This method creates and return a new response containing the Object if successful
        /// </summary>
        /// <param name="addTodo"></param>
        /// <returns></returns>
        public async Task<Response<Todo>> CreateTodo(AddTodoDto addTodo)
        {
            var mappedTodo = _mapper.Map<Todo>(addTodo);
            await _unitOfWork.todoRepository.CreateAsync(mappedTodo);
            await _unitOfWork.SaveChanges();
            return Response<Todo>.Successful("Added Successfully", true, mappedTodo, 201);
        }

        /// <summary>
        /// This method deletes an object with the Id provided, if the Id is not null it
        /// will return response containing the information about the deleted Item.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        public async Task<Response<Todo>> DeleteTodo(string Id)
        {
            var todo = await _unitOfWork.todoRepository.DeleteAsync(Id);
            if (todo == null)
            {
                return Response<Todo>.Fail(404, "Todo does not exist");
            }
            await _unitOfWork.SaveChanges();
            return Response<Todo>.Successful("Successfully deleted", true, todo, 202);
        }

        /// <summary>
        /// This method return a list of items 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Response<Todo>> GetTodoById(string Id)
        {
            var todo = await _unitOfWork.todoRepository.GetByIdAsync(Id);
            if (todo == null)
            {
                return Response<Todo>.Fail(404, $"Item with ID {Id} does not exist");
            }
            return Response<Todo>.Successful($"Item with ID {Id} is successfully deleted", true, todo, 200);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<Response<Todo>> GetTodoByTitle(string title)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Todo>> GetTodos()
        {
            var todos = await _unitOfWork.todoRepository.GetAllAsync();
            return todos;
        }

        public async Task<Response<Todo>> UpdateTodo(UpdateTodoDto updateTodo, string Id)
        {
            var todo = await _unitOfWork.todoRepository.GetByIdAsync(Id);
            if (todo == null)
            {
                return Response<Todo>.Fail(404, $"Item with ID {Id} does not exist");
            }
            var mappedTodo = _mapper.Map<Todo>(updateTodo);
            await _unitOfWork.SaveChanges();
            return Response<Todo>.Successful($"Item with {Id} is successfully updated", true, mappedTodo);
        }
    }
}
