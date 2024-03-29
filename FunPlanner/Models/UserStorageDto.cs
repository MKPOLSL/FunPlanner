﻿using FunPlannerShared.Data.Enums;

namespace FunPlanner.Models
{
    public class UserStorageDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
