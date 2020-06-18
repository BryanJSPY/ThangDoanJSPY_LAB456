using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace doanchithang_lab456_1711061719.ViewModels
{
    public class FollowingViewModel
    {
        public IEnumerable<ApplicationUser> Followings { get; set; }
        public bool ShowAction { get; set; }
    }
}