using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeManagementSystem.EntityClasses
{
    public class Sale : Entity
    {
        public string SaleID = "";
        public string ClientCode = "";
        public string AnyOtherTaxAmount = "";
        public string DiscountAmount = "";
        public string TotalSubTotalAmount = "";
        public string TotalSaleAmount = "";
        public string CurrencyCode = "";
        public string TaxAmount = "";

        public override bool IsValid()
        {
            string propertiesThatCanBeNull = "AnyOtherTaxAmount|DiscountAmount|TotalSubTotalAmount|TotalSaleAmount|TaxAmount";
            string nullCheckResult = SharedCommons.SharedCommons.CheckForNulls(this, propertiesThatCanBeNull);
            if (nullCheckResult != Globals.SUCCESS_STATUS_TEXT)
            {
                StatusCode = Globals.FAILURE_STATUS_CODE;
                StatusDesc = nullCheckResult;
                return false;
            }



            TotalSaleAmount = SharedCommons.SharedCommons.SanitizeNumericInput(TotalSaleAmount);
            TaxAmount = SharedCommons.SharedCommons.SanitizeNumericInput(TaxAmount);
            TotalSubTotalAmount = SharedCommons.SharedCommons.SanitizeNumericInput(TotalSubTotalAmount);
            AnyOtherTaxAmount = SharedCommons.SharedCommons.SanitizeNumericInput(AnyOtherTaxAmount);
            DiscountAmount = SharedCommons.SharedCommons.SanitizeNumericInput(DiscountAmount);

            if (!SharedCommons.SharedCommons.IsNumeric(TaxAmount))
            {
                StatusCode = Globals.FAILURE_STATUS_CODE;
                StatusDesc = "TAX AMOUNT SHOULD BE NUMERIC";
                return false;
            }
            if (!SharedCommons.SharedCommons.IsNumeric(DiscountAmount))
            {
                StatusCode = Globals.FAILURE_STATUS_CODE;
                StatusDesc = "DISCOUNT AMOUNT SHOULD BE NUMERIC";
                return false;
            }
            if (!SharedCommons.SharedCommons.IsNumeric(TotalSaleAmount))
            {
                StatusCode = Globals.FAILURE_STATUS_CODE;
                StatusDesc = "TOTAL INVOICE AMOUNT SHOULD BE NUMERIC";
                return false;
            }
            return base.IsValid();
        }
    }
}
