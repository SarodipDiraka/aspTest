using asp.Models;
using asp.Data;
using asp.Repositories.Interfaces;

namespace asp.Repositories.Concrete
{
    public class ToDoElementsRepository(ToDoElementsContext _context, IConfiguration _configuration) : 
    GenericRepository<ToDoElement>( _context,  _configuration), IToDoElementsRepository
    {

    }
}