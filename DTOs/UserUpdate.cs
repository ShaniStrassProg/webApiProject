﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO;

internal class UserUpdate
{
    public int UserId { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    [MaxLength(20)]
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Password { get; set; }

}
