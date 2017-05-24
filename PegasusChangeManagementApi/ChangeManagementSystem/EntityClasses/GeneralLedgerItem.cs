using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeManagementSystem.EntityClasses
{
    public class GeneralLedgerItem:Entity
    {
        public string CustomerName = "";
        public string CustomerCode = "";
        public string CustomerCategory = "";
        public string PaymentType = "";
        public string PaymentCategory = "";
        public string TranType = "";
        public string TranCategory = "";
        public string TranAmount = "";
        public string InvoiceNumber = "";
        public string CurrencyCode = "";
        public string PaymentDate = "";
        public string Narration = "";

        public override bool IsValid()
        {
            string propertiesThatCanBeNull = "InvoiceNumber|PaymentCategory";
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
