using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeManagementSystem.EntityClasses
{
    public class SystemSetting:Entity
    {
        public string SettingCode = "";
        public string SettingValue = "";

        public override bool IsValid()
        {
            string propertiesThatCanBeNull = "N/A";
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
