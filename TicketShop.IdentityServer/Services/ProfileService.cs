using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TicketShop.IdentityServer.Data.Models;

namespace TicketShop.IdentityServer.Services
{
    public class ProfileService : IProfileService
    {
        private readonly RoleManager<IdentityRole<int>> _roleMgr;
        private readonly UserManager<User> _userMgr;
        private readonly IUserClaimsPrincipalFactory<User> _userClaimsPrincipalFactory;

        public ProfileService(RoleManager<IdentityRole<int>> roleMgr, UserManager<User> userMgr, IUserClaimsPrincipalFactory<User> userClaimsPrincipalFactory)
        {
            _roleMgr = roleMgr;
            _userMgr = userMgr;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            string subjectId = context.Subject.GetSubjectId();
            User user = await _userMgr.FindByIdAsync(subjectId);
            ClaimsPrincipal userClaims = await _userClaimsPrincipalFactory.CreateAsync(user);
            List<Claim> claims = userClaims.Claims.ToList();
            claims = claims.Where(claim=>context.RequestedClaimTypes.Contains(claim.Type)).ToList();
            IList<string> roles = await _userMgr.GetRolesAsync(user);
            foreach(var role in roles)
            {
                claims.Add(new Claim(JwtClaimTypes.Role, role));
                if(_roleMgr.SupportsRoleClaims)
                {
                    IdentityRole<int> rol = await _roleMgr.FindByNameAsync(role);
                    if(rol!=null)
                    {
                        claims.AddRange(await _roleMgr.GetClaimsAsync(rol));
                    }
                }
            }
            claims.Add(new Claim("nameUs",user.FirstName));
            context.IssuedClaims = claims;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}
