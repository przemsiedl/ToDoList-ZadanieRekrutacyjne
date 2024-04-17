using RKT.Dto;

namespace RKT.Services.Interfaces;

public interface IToDoItemService
{
    Task<ToDoItemDto> AddNew(ToDoItemDto toDoItemDto);
    Task<ToDoItemDto?> Get(long id);
    Task<List<ToDoItemDto>> GetAll(DateTime? day = null);
    void Remove(long id);
    Task<ToDoItemDto> Update(long id, ToDoItemDto toDoItemDto);
}