using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPUITests.Models.Config
{
    public class AutoConfig
    {
        public string Browser { get; set; }
        public string Environment { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PageTimeoutInSec { get; set; }
        public string AppURL { get; set; }
    }
}
