﻿namespace API.Models.User
{
    public class UserResponseDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
