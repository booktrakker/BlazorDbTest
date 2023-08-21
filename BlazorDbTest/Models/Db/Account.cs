using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BlazorDbTest.Models;

[Keyless]
[Table("Accounts", Schema = "dbo")]
public partial class Account
{
    [Column("Account_ID")]
    public int? AccountId { get; set; }

    [Column("Email")]
    public string Email { get; set; }
}
