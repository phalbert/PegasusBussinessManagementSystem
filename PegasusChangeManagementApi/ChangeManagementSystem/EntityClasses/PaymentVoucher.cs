using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeManagementSystem.EntityClasses
{
    public class PaymentVoucher : Entity
    {
        public string VoucherCode = "";
        public string InvoiceNumber = "";
        public string VoucherAmount = "";
        public string IsUsed = "";
        public string Reason = "";

        public override bool IsValid()
        {
            string propertiesThatCanBeNull = "IsUsed|Reason";
            string nullCheckResult = SharedCommons.SharedCommons.CheckForNulls(this, propertiesThatCanBeNull);
            if (nullCheckResult != Globals.SUCCESS_STATUS_TEXT)
            {
                StatusCode = Globals.FAILURE_STATUS_CODE;
                StatusDesc = nullCheckResult;
                return false;
            }

            if (string.IsNullOrEmpty(IsUsed))
            {
                IsUsed = "False";
            }

            VoucherAmount = SharedCommons.SharedCommons.SanitizeNumericInput(VoucherAmount);

            if (!SharedCommons.SharedCommons.IsValidBoolean(IsUsed))
            {
                StatusCode = Globals.FAILURE_STATUS_CODE;
                StatusDesc = "IS PAID SHOULD BE A BOOLEAN";
                return false;
            }
            if (!SharedCommons.SharedCommons.IsNumericAndAboveZero(VoucherAmount))
            {
                StatusCode = Globals.FAILURE_STATUS_CODE;
                StatusDesc = "VOUCHER AMOUNT SHOULD BE NUMERIC AND ABOVE ZERO";
                return false;
            }
            return base.IsValid();
        }
    }
}
