using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeManagementSystem.EntityClasses
{
    public class Contract:Entity
    {
        public string ClientCode = "";
        public string StartDate = "";
        public string DurationInDays = "";
        public string ContractCategory = "";
        public string ContractId = "";
        public string ContractType = "";

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
