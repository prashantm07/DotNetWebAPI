using ASPCoreWebAPI.Models;

namespace ASPCoreWebAPI.Dto
{
    public class StudentDto
    {
        private readonly myDbContext dbContext;

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
