﻿using System.ComponentModel.DataAnnotations;
using Identity.BusinessLogic.Identity.Dtos.Identity.Base;
using Identity.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace Identity.BusinessLogic.Identity.Dtos.Identity
{
    public class UserChangePasswordDto<TKey> : BaseUserChangePasswordDto<TKey>, IUserChangePasswordDto
    {
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
