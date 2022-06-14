using TodoService.Domain.Entities.Common;

namespace TodoService.Domain.Entities
{
    public class TodoItem:BaseEntity
    {
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string Secret { get; set; }
    }
}