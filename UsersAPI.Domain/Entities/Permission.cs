namespace UsersAPI.Domain.Entities
{
    public class Permission
    {
        public Guid RoleId { get; set; }
        public Guid SubModuleId { get; set; }
        public bool? Create { get; set; }
        public bool? Update { get; set; }
        public bool? Delete { get; set; }
        public bool? Read { get; set; }
        public DateTime? CreatedAt { get; set; }


        /// <summary>
        /// Relacionamentos entre Entidades
        /// </summary>
        public List<Role>? Roles { get; set; }
        public List<SubModule>? SubModules { get; set; }
    }
}
