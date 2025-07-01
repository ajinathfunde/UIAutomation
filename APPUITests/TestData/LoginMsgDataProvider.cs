using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPUITests.TestData
{
    public class LoginMsgDataProvider
    {
        public static IEnumerable<TestCaseData> SuccessMgs => new List<TestCaseData>
        {
            new TestCaseData("Test Login | Practice Test Automation", "Logged In Successfully | Practice Test Automation")              
        };

        public static IEnumerable<TestCaseData> FailureMgs => new List<TestCaseData>
        {
            new TestCaseData("Your password is invalid!")
        };
    }
}
