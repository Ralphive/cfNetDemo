using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cfNetDemo.Pages
{
    public class IndexModel : PageModel
    {
        public string SL_SESSIONID { get; private set; }
        public string ENV_SERVER { get; private set; } = (Environment.GetEnvironmentVariable("INSTANCE_INDEX") + 1);
        public void OnGet()
        {

        }
    }
}
