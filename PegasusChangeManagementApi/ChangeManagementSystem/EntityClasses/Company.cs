using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeManagementSystem.EntityClasses
{
    public class Company : Entity
    {
        public string CompanyName = "";
        public string CompanyContactEmail = "";
        public string IsActive = "";
        public string PathToLogoImage = "";
        public string ThemeColor = "";
        public string NavBarTextColor = "";

        public override bool IsValid()
        {
            string propertiesThatCanBeNull = "PathToLogoImage|ThemeColor|NavBarTextColor";
            string nullCheckResult = SharedCommons.SharedCommons.CheckForNulls(this, propertiesThatCanBeNull);
            if (nullCheckResult != Globals.SUCCESS_STATUS_TEXT)
            {
                StatusCode = Globals.FAILURE_STATUS_CODE;
                StatusDesc = nullCheckResult;
                return false;
            }
            return base.IsValid();
        }
    }
}
