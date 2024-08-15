using ExploreThrill.Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace ExploreThrill.MVC.Areas.Account.Models
{
    public class UserListViewModel
    {
        public IEnumerable<MyUser> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
        public IEnumerable<string> SelectedRoles { get; set; }
        public Dictionary<string, List<string>> UserRoles { get; set; }
    }

}
