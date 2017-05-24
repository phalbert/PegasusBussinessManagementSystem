using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeManagementSystem.EntityClasses
{
    public class Reciept:Entity
    {
        public string RecieptNumber = "";
        public string InvoiceNumber = "";
        public string ClientCode = "";
        public string PaymentType = "";
        public string ChequeNumber = "";
        public string BankName = "";
        public string BankAccountName = "";
        public string BankAccountNumber = "";
        public string PaymentDate = "";
        public string RecieptCategory = "";
        public string ImageOfReciept = null;
        public string CurrencyCode = "";
        public string RecieptAmount = "";

        public override bool IsValid()
        {
            string propertiesThatCanBeNull = "ChequeNumber|BankName|BankAccountName|BankAccountNumber|ImageOfReciept";
            string nullCheckResult = SharedCommons.SharedCommons.CheckForNulls(this, propertiesThatCanBeNull);
            if (nullCheckResult != Globals.SUCCESS_STATUS_TEXT)
            {
                StatusCode = Globals.FAILURE_STATUS_CODE;
                StatusDesc = nullCheckResult;
                return false;
            }



            RecieptAmount = SharedCommons.SharedCommons.SanitizeNumericInput(RecieptAmount);

            return base.IsValid();
        }
    }
}
