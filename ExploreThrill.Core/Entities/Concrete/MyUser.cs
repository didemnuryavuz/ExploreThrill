using Microsoft.AspNetCore.Identity;

namespace ExploreThrill.Core.Entities.Concrete
{
    public class MyUser : IdentityUser
    {
        public string TcNo { get; set; }
        public bool? Gender { get; set; }

    }
}
