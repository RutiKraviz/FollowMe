﻿namespace MyProject.WebAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public int PassWord { get; set; }
        public string? Role { get; set; }
    }
}
