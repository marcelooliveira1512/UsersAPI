namespace UsersAPI.Application.Dtos.Responses
{
    public class PermissionResponseDto
    {
        public Guid RoleId { get; set; }
        public Guid SubModuleId { get; set; }
        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Read { get; set; }
    }
}
