using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeManagementSystem.EntityClasses
{
    public class UserType:Entity
    {
        public string UserTypeCode = "";
        public string UserTypeName = "";
        public string IsActive = "";

        public override bool IsValid()
        {
            string propertiesThatCanBeNull = "IsActive";
            string nullCheckResult = SharedCommons.SharedCommons.CheckForNulls(this, propertiesThatCanBeNull);
            if (nullCheckResult != Globals.SUCCESS_STATUS_TEXT)
            {
                StatusCode = Globals.FAILURE_STATUS_CODE;
                StatusDesc = nullCheckResult;
                return false;
            }

            if (string.IsNullOrEmpty(IsActive))
            {
                IsActive = "False";
            }
            return base.IsValid();
        }
    }
}
