using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeManagementSystem.EntityClasses
{
    public class Client : Entity
    {
        public string ClientCode = "";
        public string ClientName = "";
        public string ClientAddress = "";
        public string TelephoneNumber = "";
        public string MobileNumber = "";
        public string ContactPersonName = "";
        public string Email = "";
        public string ClientCategory = "N/A";
        public string BankName = "";
        public string BankAccountName = "";
        public string BankAccountNumber = "";

        public override bool IsValid()
        {
            string propertiesThatCanBeNull = "TelephoneNumber|MobileNumber|Email|ClientCategory";
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
