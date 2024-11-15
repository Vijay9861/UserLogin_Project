using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserLogin_Project.Models;

public partial class UserLogin
{
    [Key]
    public int UserId { get; set; }
    [Required(ErrorMessage = "Email Id is required")]
    [Display(Name ="User ID")]
    public string MailId { get; set; }= null;
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]
    [Display(Name ="Password")]
    public string? UPassword { get; set; }
}
