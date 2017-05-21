using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeManagementSystem.EntityClasses
{
    public class SaleItem : Entity
    {
        public string SaleID = "";
        public string ClientCode = "";
        public string ItemDesc = "";
        public string ItemQuantity = "";
        public string UnitPrice = "";
        public string SubTotal = ""; //Qty * UnitPrice

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

            ItemQuantity = SharedCommons.SharedCommons.SanitizeNumericInput(ItemQuantity);
            UnitPrice = ItemQuantity = SharedCommons.SharedCommons.SanitizeNumericInput(UnitPrice);
            SubTotal = ItemQuantity = SharedCommons.SharedCommons.SanitizeNumericInput(SubTotal);

            if (!SharedCommons.SharedCommons.IsNumericAndAboveZero(ItemQuantity))
            {
                StatusCode = Globals.FAILURE_STATUS_CODE;
                StatusDesc = "ITEM QUANTITY SHOULD BE NUMERIC AND ABOVE ZERO";
                return false;
            }
            if (!SharedCommons.SharedCommons.IsNumericAndAboveZero(ItemQuantity))
            {
                StatusCode = Globals.FAILURE_STATUS_CODE;
                StatusDesc = "UNIT PRICE SHOULD BE NUMERIC AND ABOVE ZERO";
                return false;
            }
            if (!SharedCommons.SharedCommons.IsNumericAndAboveZero(SubTotal))
            {
                StatusCode = Globals.FAILURE_STATUS_CODE;
                StatusDesc = "SUBTOTAL SHOULD BE NUMERIC AND ABOVE ZERO";
                return false;
            }
            return base.IsValid();
        }
    }
}
