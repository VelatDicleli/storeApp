using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Entities.Dtos
{
    public record class UserDtoForUpdate:UserDto
    {
        public HashSet<string> UserRoles { get; set; } = new HashSet<string>();
    }
}
