using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Users_App.Validation_Attributes;
using Users_DataModels.DataModels;

namespace Users_App.Models
{
    public class UsersViewModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter a username")]
        [RegularExpression(@"\S+", ErrorMessage = "Username cannot contain spaces")]
        [Remote("UsernameRemoteCheck", "Users", ErrorMessage = "This username is unavailable")]
        [UsernameDatabaseCheck(ErrorMessage = "This username in unavailable")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your e-mail address")]
        [EmailAddress(ErrorMessage = "Invalid e-mail address")]
        [Remote("EmailRemoteCheck", "Users", ErrorMessage = "This e-mail already exists")]
        [EmailDatabaseCheck(ErrorMessage = "This e-mail already exists")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [RegularExpression(@"\S+", ErrorMessage = "Password cannot contain spaces")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please retype the password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Match not found")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please select your gender")]
        public int? GenderId { get; set; }

        [Required(ErrorMessage = "Please select a membership")]
        public int? MembershipId { get; set; }

        public DateTime DateCreated { get; set; }

        public Genders Genders { get; set; }

        public Memberships Memberships { get; set; }
    }
}
