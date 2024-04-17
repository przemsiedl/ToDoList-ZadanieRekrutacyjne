using RKT.Dto;
using RKT.Model;

namespace RKT.Services
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> FromSingle<T>(this T item)
        {
            return (new[] { item }).AsQueryable();
        }

        public static IQueryable<ToDoItemDto> AsView(this IQueryable<ToDoItem> query)
        {
            return query.Select(a =>
                new ToDoItemDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Date = a.Date,
                    Priority = a.Priority,
                    Completed = a.Completed,
                });
        }
    }
}
