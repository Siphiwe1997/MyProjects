using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyJourney.Infrastructure
{
    [HtmlTargetElement("td", Attributes = "identity-role-id")]
    public class RoleUsersTagHelper : TagHelper
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleUsersTagHelper(UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HtmlAttributeName("identity-role-id")]
        public string RoleId { get; set; }

        public override async Task ProcessAsync(TagHelperContext context,
            TagHelperOutput output)
        {
            List<string> names = new();
            IdentityRole role = await _roleManager.FindByIdAsync(RoleId);
            if (role != null)
            {
                foreach (var user in _userManager.Users)
                {
                    if (user != null
                        && await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        names.Add(user.UserName);
                    }
                }
            }
            output.Content.SetContent(names.Count == 0 ?
                "No Users" : string.Join(", ", names));
        }
    }
}