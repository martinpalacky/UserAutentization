﻿namespace UserAutentization.Data
{
    public class UserInfoDto
    {
        //public ApplicationUser? UserInf {  get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } 
        public List<string>?  PersonRoles { get; set; }
    }
}
