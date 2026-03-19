using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndentityShared.Models
{
    public class InviteToken
    {
        public int Id { get; set; }
        public string Token { get; set; } = null!;

        public bool IsEnabled { get; set; } = true;
    }
}
