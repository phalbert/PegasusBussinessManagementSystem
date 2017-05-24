using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeManagementSystem.EntityClasses
{
    public class SystemUser : Entity
    {
        public string UserId = "";
        public string Password = "";
        public string Name = "";
        public string UserType = "";
        public string IsActive = "";
        public string Email = "";

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

            if (string.IsNullOrEmpty(IsActive))
            {
                IsActive = "False";
            }

            return base.IsValid();
        }
    }
}
