﻿    namespace UsersAPI.Infra.Messages.Models
{
    public class MessagesRequestModel
    {
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}
