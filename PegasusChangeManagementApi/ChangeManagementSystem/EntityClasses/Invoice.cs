﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeManagementSystem.EntityClasses
{
    public class Invoice:Entity
    {
        public string InvoiceDate = "";
        public string InvoiceNumber = "";
        public string Narration = "";
        public string InvoiceAmount = "";
        public string TaxAmount = "";
        public string TotalInvoiceAmount = "";
        public string AnyOtherTax = "";
        public string DiscountAmount = "";
        public string CurrencyCode = "";
        public string ClientCode = "";
        public string InvoiceCategory = "";
        public string ImageOfInvoice = null;
        public string IsPaid = "";

        public override bool IsValid()
        {
          
            string propertiesThatCanBeNull = "AnyOtherTax|DiscountAmount|TaxAmount|ImageOfInvoice|IsPaid";
            string nullCheckResult = SharedCommons.SharedCommons.CheckForNulls(this, propertiesThatCanBeNull);
            if (nullCheckResult != Globals.SUCCESS_STATUS_TEXT)
            {
                StatusCode = Globals.FAILURE_STATUS_CODE;
                StatusDesc = nullCheckResult;
                return false;
            }

            InvoiceAmount = SharedCommons.SharedCommons.SanitizeNumericInput(InvoiceAmount);
            TaxAmount = SharedCommons.SharedCommons.SanitizeNumericInput(TaxAmount);
            TotalInvoiceAmount = SharedCommons.SharedCommons.SanitizeNumericInput(TotalInvoiceAmount);
            AnyOtherTax = SharedCommons.SharedCommons.SanitizeNumericInput(AnyOtherTax);
            DiscountAmount = SharedCommons.SharedCommons.SanitizeNumericInput(DiscountAmount);

            if (string.IsNullOrEmpty(IsPaid))
            {
                IsPaid="False";
            }
            if (!SharedCommons.SharedCommons.IsValidBoolean(IsPaid))
            {
                StatusCode = Globals.FAILURE_STATUS_CODE;
                StatusDesc = "IS PAID SHOULD BE A BOOLEAN";
                return false;
            }
            if (!SharedCommons.SharedCommons.IsNumericAndAboveZero(InvoiceAmount))
            {
                StatusCode = Globals.FAILURE_STATUS_CODE;
                StatusDesc = "INVOICE AMOUNT SHOULD BE NUMERIC AND ABOVE ZERO";
                return false;
            }
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
            if (!SharedCommons.SharedCommons.IsNumericAndAboveZero(TotalInvoiceAmount))
            {
                StatusCode = Globals.FAILURE_STATUS_CODE;
                StatusDesc = "TOTAL INVOICE AMOUNT SHOULD BE NUMERIC AND ABOVE ZERO";
                return false;
            }
            return base.IsValid();
        }
    }
}
