using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserLogin
    {
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(20)]
        public string? Password { get; set; }
    }
}
