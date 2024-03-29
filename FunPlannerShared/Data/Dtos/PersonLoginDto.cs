﻿using FunPlannerShared.Data.Enums;

namespace FunPlannerShared.Data.Dtos
{
    public class PersonLoginDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
    }
}
