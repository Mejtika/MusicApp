﻿namespace MusicApp.Users
{
    public class UpdateUserRequest
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string Password { get; set; }
    }
}
