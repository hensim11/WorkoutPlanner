﻿using WorkoutPlanner.Model;

namespace WorkoutPlanner.Context
{
    public class UserProvider
    {
        private User user;

        private readonly DatabaseContext context;
        
        public UserProvider(DatabaseContext context)
        {
            _context = context;
        }

        public User? GetUserByName(string? name)
        {
            return _context.Users.FirstOrDefault(x => user.Name == name);
        }
    }
}