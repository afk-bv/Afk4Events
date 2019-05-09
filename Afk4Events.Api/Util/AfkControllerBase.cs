using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Afk4Events.Api.Util
{
    public class AfkControllerBase : Controller
    {
        public Guid UserId => Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
        public Guid GroupId => Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.PrimaryGroupSid).Value);
    }
}
