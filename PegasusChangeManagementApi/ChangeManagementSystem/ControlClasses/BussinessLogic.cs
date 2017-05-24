using ChangeManagementSystem.EntityClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ChangeManagementSystem.ControlClasses
{
    public class BussinessLogic
    {
        DatabaseHandler dh = new DatabaseHandler();

        public DataSet ExecuteDataSet(string storedProcName, string[] parameters)
        {
            return dh.ExecuteDataSet(storedProcName, parameters);
        }

        public int ExecuteNonQuery(string storedProcName, string[] parameters)
        {
            return dh.ExecuteNonQuery(storedProcName, parameters);
        }

        public Entity GetById(string CompanyCode, string ObjectClassName, string ObjectId)
        {
            Entity result = new Entity();
            if (ObjectClassName.ToUpper() == "INVOICE")
            {
                Invoice invoice = GetInvoiceById(CompanyCode, ObjectId);
                return invoice;
            }
            if (ObjectClassName.ToUpper() == "RECIEPT")
            {
                Reciept reciept = GetRecieptById(CompanyCode, ObjectId);
                return reciept;
            }
            if (ObjectClassName.ToUpper() == "CLIENTORSUPPLIER")
            {
                Client client = GetClientOrSupplierById(CompanyCode, ObjectId);
                return client;
            }
            if (ObjectClassName.ToUpper() == "PURCHASE")
            {
                Purchase invoice = GetPurchaseById(CompanyCode, ObjectId);
                return invoice;
            }
            if (ObjectClassName.ToUpper() == "PAYMENTVOUCHER")
            {
                PaymentVoucher voucher = GetPaymentVoucherById(CompanyCode, ObjectId);
                return voucher;
            }
            if (ObjectClassName.ToUpper() == "SALE")
            {
                Sale sale = GetSaleById(CompanyCode, ObjectId);
                return sale;
            }
            if (ObjectClassName.ToUpper() == "SYSTEMSETTING")
            {
                SystemSetting setting = GetSettingById(CompanyCode, ObjectId);
                return setting;
            }

            result.StatusCode = Globals.FAILURE_STATUS_CODE;
            result.StatusDesc = "LOGIC TO FIND OBJECTS WITH NAME [" + ObjectClassName + "] NOT SET";
            return result;
        }

        private Client GetClientOrSupplierById(string companyCode, string objectId)
        {
            Client result = new Client();
            string[] param = { companyCode, objectId };
            DataTable dt = dh.ExecuteDataSet("GetClientOrSupplierById", param).Tables[0];
            if (dt.Rows.Count == 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "NOT FOUND";
                return result;
            }

            DataRow dr = dt.Rows[0];
            result.CompanyCode = companyCode;
            result.BankAccountName = dr["BankAccountName"].ToString();
            result.BankAccountNumber = dr["BankAccountNumber"].ToString();
            result.BankName = dr["BankName"].ToString();
            result.ClientAddress = dr["Address"].ToString();
            result.ClientCode = dr["Code"].ToString();
            result.ClientName = dr["Name"].ToString();
            result.ContactPersonName = dr["ContactPersonName"].ToString();
            result.Email = dr["Email"].ToString();
            result.MobileNumber = dr["MobileNumber"].ToString();
            result.TelephoneNumber = dr["TelephoneNumber"].ToString();
            result.ClientCategory = dr["Category"].ToString();
            result.CreatedBy = dr["CreatedBy"].ToString();
            result.CreatedOn = dr["CreatedOn"].ToString();
            result.ModifiedBy = dr["ModifiedBy"].ToString();
            result.ModifiedOn = dr["ModifiedOn"].ToString();
            result.RecordId = dr["RecordId"].ToString();

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            return result;
        }

        private Reciept GetRecieptById(string companyCode, string objectId)
        {
            Reciept result = new Reciept();
            string[] param = { companyCode, objectId };
            DataTable dt = dh.ExecuteDataSet("GetRecieptById", param).Tables[0];
            if (dt.Rows.Count == 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "NOT FOUND";
                return result;
            }

            DataRow dr = dt.Rows[0];
            result.CompanyCode = companyCode;
            //result.BankAccountName = dr["BankAccountName"].ToString();
            result.BankAccountNumber = dr["BankAccountNumber"].ToString();
            result.BankName = dr["BankName"].ToString();
            result.ChequeNumber = dr["ChequeNumber"].ToString();
            result.CurrencyCode = dr["CurrencyCode"].ToString();
            result.ImageOfReciept = dr["ImageOfReciept"].ToString();
            result.InvoiceNumber = dr["InvoiceNumber"].ToString();
            result.PaymentDate = dr["PaymentDate"].ToString();
            result.PaymentType = dr["PaymentType"].ToString();
            result.RecieptAmount = dr["RecieptAmount"].ToString();
            result.RecieptCategory = dr["RecieptCategory"].ToString();
            result.RecieptNumber = dr["RecieptNumber"].ToString();
            result.CreatedBy = dr["CreatedBy"].ToString();
            result.CreatedOn = dr["CreatedOn"].ToString();
            result.ModifiedBy = dr["ModifiedBy"].ToString();
            result.ModifiedOn = dr["ModifiedOn"].ToString();
            result.RecordId = dr["RecordId"].ToString();

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            return result;
        }

        private SystemSetting GetSettingById(string companyCode, string objectId)
        {
            SystemSetting result = new SystemSetting();
            string[] param = { companyCode, objectId };
            DataTable dt = dh.ExecuteDataSet("GetSystemSettingById", param).Tables[0];
            if (dt.Rows.Count == 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "NOT FOUND";
                return result;
            }

            DataRow dr = dt.Rows[0];
            result.CompanyCode = companyCode;
            result.SettingCode = dr["SettingCode"].ToString();
            result.SettingValue = dr["SettingValue"].ToString();
            result.CreatedBy = dr["CreatedBy"].ToString();
            result.CreatedOn = dr["CreatedOn"].ToString();
            result.ModifiedBy = dr["ModifiedBy"].ToString();
            result.ModifiedOn = dr["ModifiedOn"].ToString();
            result.RecordId = dr["RecordId"].ToString();

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            return result;
        }



        private Invoice GetInvoiceById(string companyCode, string objectId)
        {
            Invoice result = new Invoice();
            string[] param = { companyCode, objectId };
            DataTable dt = dh.ExecuteDataSet("GetInvoiceById", param).Tables[0];
            if (dt.Rows.Count == 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "NOT FOUND";
                return result;
            }

            DataRow dr = dt.Rows[0];
            result.AnyOtherTax = dr["AnyOtherTax"].ToString();
            result.CompanyCode = companyCode;
            result.CreatedBy = dr["CreatedBy"].ToString();
            result.CreatedOn = dr["CreatedOn"].ToString();
            result.CurrencyCode = dr["CurrencyCode"].ToString();
            result.ClientCode = dr["ClientCode"].ToString();
            result.InvoiceCategory = dr["InvoiceCategory"].ToString();
            result.ImageOfInvoice = dr["ImageOfInvoice"].ToString();
            result.DiscountAmount = dr["DiscountAmount"].ToString();
            result.InvoiceAmount = dr["InvoiceAmount"].ToString();
            result.InvoiceDate = dr["InvoiceDate"].ToString();
            result.InvoiceNumber = dr["InvoiceNumber"].ToString();
            result.ModifiedBy = dr["ModifiedBy"].ToString();
            result.ModifiedOn = dr["ModifiedOn"].ToString();
            result.Narration = dr["Narration"].ToString();
            result.TaxAmount = dr["TaxAmount"].ToString();
            result.RecordId = dr["RecordId"].ToString();
            result.TotalInvoiceAmount = dr["TotalInvoiceAmount"].ToString();

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            return result;
        }

        private Sale GetSaleById(string companyCode, string objectId)
        {
            Sale result = new Sale();
            string[] param = { companyCode, objectId };
            DataTable dt = dh.ExecuteDataSet("GetSaleById", param).Tables[0];
            if (dt.Rows.Count == 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "NOT FOUND";
                return result;
            }

            DataRow dr = dt.Rows[0];
            result.AnyOtherTaxAmount = dr["AnyOtherTaxAmount"].ToString();
            result.CompanyCode = companyCode;
            result.CreatedBy = dr["CreatedBy"].ToString();
            result.CreatedOn = dr["CreatedOn"].ToString();
            result.CurrencyCode = dr["CurrencyCode"].ToString();
            result.ClientCode = dr["ClientCode"].ToString();
            result.DiscountAmount = dr["DiscountAmount"].ToString();
            result.TotalSubTotalAmount = dr["TotalSubTotalAmount"].ToString();
            result.TotalSaleAmount = dr["TotalSaleAmount"].ToString();
            result.SaleID = objectId;
            result.ModifiedBy = dr["ModifiedBy"].ToString();
            result.ModifiedOn = dr["ModifiedOn"].ToString();
            result.TaxAmount = dr["TaxAmount"].ToString();
            result.RecordId = dr["RecordId"].ToString();

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            return result;
        }

        private Purchase GetPurchaseById(string companyCode, string objectId)
        {
            Purchase result = new Purchase();
            string[] param = { companyCode, objectId };
            DataTable dt = dh.ExecuteDataSet("GetPurchaseById", param).Tables[0];
            if (dt.Rows.Count == 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "NOT FOUND";
                return result;
            }

            DataRow dr = dt.Rows[0];
            result.AnyOtherTax = dr["AnyOtherTax"].ToString();
            result.CompanyCode = companyCode;
            result.CreatedBy = dr["CreatedBy"].ToString();
            result.CreatedOn = dr["CreatedOn"].ToString();
            result.CurrencyCode = dr["CurrencyCode"].ToString();
            result.SupplierCode = dr["CustomerCode"].ToString();
            result.SupplierName = dr["CustomerType"].ToString();
            result.DiscountAmount = dr["DiscountAmount"].ToString();
            result.InvoiceAmount = dr["InvoiceAmount"].ToString();
            result.InvoiceDate = dr["InvoiceDate"].ToString();
            result.InvoiceNumber = dr["InvoiceNumber"].ToString();
            result.ModifiedBy = dr["ModifiedBy"].ToString();
            result.ModifiedOn = dr["ModifiedOn"].ToString();
            result.TaxAmount = dr["TaxAmount"].ToString();
            result.RecordId = dr["RecordId"].ToString();
            result.TotalInvoiceAmount = dr["TotalInvoiceAmount"].ToString();

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            return result;
        }

        private PaymentVoucher GetPaymentVoucherById(string companyCode, string objectId)
        {
            PaymentVoucher result = new PaymentVoucher();
            string[] param = { companyCode, objectId };
            DataTable dt = dh.ExecuteDataSet("GetPaymentVoucherById", param).Tables[0];
            if (dt.Rows.Count == 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "NOT FOUND";
                return result;
            }

            DataRow dr = dt.Rows[0];
            result.CompanyCode = companyCode;
            result.CreatedBy = dr["CreatedBy"].ToString();
            result.CreatedOn = dr["CreatedOn"].ToString();
            result.IsUsed = dr["IsUsed"].ToString();
            result.Reason = dr["Reason"].ToString();
            result.VoucherAmount = dr["VoucherAmount"].ToString();
            result.VoucherCode = dr["VoucherCode"].ToString();
            result.InvoiceNumber = dr["InvoiceNumber"].ToString();
            result.ModifiedBy = dr["ModifiedBy"].ToString();
            result.ModifiedOn = dr["ModifiedOn"].ToString();
            result.RecordId = dr["RecordId"].ToString();

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            return result;
        }

        public SystemUser Login(string UserId, string Password)
        {
            SystemUser user = new SystemUser();
            DataTable dt = dh.ExecuteDataSet("GetSystemUserByUserId", new string[] { UserId }).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                user.StatusCode = Globals.FAILURE_STATUS_CODE;
                user.StatusDesc = "USER WITH ID [" + UserId + "] NOT FOUND";
                return user;
            }

            user.StatusCode = Globals.SUCCESS_STATUS_CODE;
            user.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            return user;
        }

        public Result LogOut(string UserId)
        {
            Result result = new Result();
            return result;
        }

        public Result SaveChangeRequest(ChangeRequest req)
        {
            Result result = new Result();
            return result;
        }

        public Result SaveInPurchaseLedger(Purchase req)
        {
            Result result = new Result();

            if (!req.IsValid())
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = req.StatusDesc;
                return result;
            }

            DataTable dt = dh.ExecuteDataSet("SavePurchase", new string[] { req.CompanyCode, req.SupplierCode, req.SupplierName, req.InvoiceNumber, req.InvoiceDate, req.CurrencyCode, req.InvoiceAmount, req.TaxAmount, req.AnyOtherTax, req.DiscountAmount, req.TotalInvoiceAmount, req.ModifiedBy, req.IsPaid }).Tables[0];

            if (dt.Rows.Count <= 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "FAILED: PURCHASE NOT SAVED";
                return result;
            }

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            result.PegPayID = dt.Rows[0][0].ToString();
            return result;
        }

        public Result SaveInSalesLedger(Sale req)
        {
            Result result = new Result();

            if (!req.IsValid())
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = req.StatusDesc;
                return result;
            }

            DataTable dt = dh.ExecuteDataSet("SaveSale", new string[] { req.CompanyCode, req.SaleID, req.ClientCode, req.DiscountAmount, req.CurrencyCode, req.ModifiedBy, req.AnyOtherTaxAmount }).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "FAILED: SALE NOT SAVED";
                return result;
            }

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = dt.Rows[0][1].ToString();
            result.PegPayID = dt.Rows[0][0].ToString();
            return result;
        }

        public Result LogError(string ErrorIdentifier, string StackTrace, string CompanyCode, string Message, string ErrorType)
        {
            Result result = new Result();
            try
            {
                int rowsAffected = dh.ExecuteNonQuery("LogInterfaceError", ErrorIdentifier, StackTrace, CompanyCode, Message, ErrorType);
            }
            catch (Exception ex)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "EXCEPTION: " + ex.Message;
            }
            return result;
        }

        public Result SaveClient(Client req)
        {
            Result result = new Result();

            if (!req.IsValid())
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = req.StatusDesc;
                return result;
            }

            DataTable dt = dh.ExecuteDataSet("SaveClient", new string[] { req.CompanyCode, req.ClientCode, req.ClientName, req.ClientAddress, req.TelephoneNumber, req.MobileNumber, req.ContactPersonName, req.Email, req.ModifiedBy, req.BankName, req.BankAccountNumber, req.BankAccountName }).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "FAILED: SALE NOT SAVED";
                return result;
            }

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            result.PegPayID = dt.Rows[0][0].ToString();
            return result;
        }


        public Result SaveSupplier(Supplier req)
        {
            Result result = new Result();

            if (!req.IsValid())
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = req.StatusDesc;
                return result;
            }

            DataTable dt = dh.ExecuteDataSet("SaveSupplier", new string[] { req.CompanyCode, req.SupplierCode, req.SupplierName, req.SupplierAddress, req.TelephoneNumber, req.MobileNumber, req.ContactPersonName, req.Email, req.ModifiedBy, req.BankName, req.BankAccountNumber, req.BankAccountName }).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "FAILED: SALE NOT SAVED";
                return result;
            }

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            result.PegPayID = dt.Rows[0][0].ToString();
            return result;
        }

        public Result SaveSystemSetting(SystemSetting req)
        {
            Result result = new Result();

            if (!req.IsValid())
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = req.StatusDesc;
                return result;
            }

            DataTable dt = dh.ExecuteDataSet("SaveSystemSetting", new string[] { req.CompanyCode, req.SettingCode, req.SettingValue, req.ModifiedBy }).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "FAILED: SALE NOT SAVED";
                return result;
            }

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            result.PegPayID = dt.Rows[0][0].ToString();
            return result;
        }


        public Result SaveSaleItem(SaleItem req)
        {
            Result result = new Result();

            if (!req.IsValid())
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = req.StatusDesc;
                return result;
            }

            DataTable dt = dh.ExecuteDataSet("SaveSaleItem", new string[] { req.SaleID, req.ItemDesc, req.ItemQuantity, req.UnitPrice, req.SubTotal, req.ModifiedBy, "false" }).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "FAILED: SALE NOT SAVED";
                return result;
            }

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            result.PegPayID = dt.Rows[0][0].ToString();
            return result;
        }

        public Result SaveInvoice(Invoice req)
        {
            Result result = new Result();

            if (!req.IsValid())
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = req.StatusDesc;
                return result;
            }

            DataTable dt = dh.ExecuteDataSet("SaveInvoice", new string[] { req.CompanyCode, req.InvoiceNumber, req.InvoiceDate, req.CurrencyCode, req.InvoiceAmount, req.TaxAmount, req.AnyOtherTax, req.DiscountAmount, req.Narration, req.TotalInvoiceAmount, req.ModifiedBy, req.IsPaid, req.ClientCode, req.InvoiceCategory, req.ImageOfInvoice }).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "FAILED: SALE NOT SAVED";
                return result;
            }

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            result.PegPayID = dt.Rows[0][0].ToString();
            return result;
        }

        public Result SaveContract(Contract req)
        {
            Result result = new Result();

            if (!req.IsValid())
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = req.StatusDesc;
                return result;
            }

            DataTable dt = dh.ExecuteDataSet("SaveContract", new string[] { req.CompanyCode, req.ClientCode, req.StartDate, req.DurationInDays, req.ContractCategory, req.ContractType, req.ModifiedBy, req.ContractType }).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "FAILED: SALE NOT SAVED";
                return result;
            }

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            result.PegPayID = dt.Rows[0][0].ToString();
            return result;
        }

        public Result SavePaymentVoucher(PaymentVoucher req)
        {
            Result result = new Result();

            if (!req.IsValid())
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = req.StatusDesc;
                return result;
            }

            DataTable dt = dh.ExecuteDataSet("SavePaymentVoucher", new string[] { req.VoucherCode, req.InvoiceNumber, req.CompanyCode, req.VoucherAmount, req.IsUsed, req.ModifiedBy, req.Reason }).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "FAILED: SALE NOT SAVED";
                return result;
            }

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            result.PegPayID = dt.Rows[0][0].ToString();
            return result;
        }

        public Result SaveReciept(Reciept req)
        {
            Result result = new Result();

            if (!req.IsValid())
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = req.StatusDesc;
                return result;
            }

            DataTable dt = dh.ExecuteDataSet("SaveReciept", new string[] { req.CompanyCode, req.RecieptNumber, req.InvoiceNumber, req.PaymentType, req.ChequeNumber, req.BankName, req.BankAccountNumber, req.PaymentDate, req.ModifiedBy, req.RecieptCategory, req.ImageOfReciept, req.CurrencyCode, req.RecieptAmount, req.ClientCode }).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "FAILED: SALE NOT SAVED";
                return result;
            }

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            result.PegPayID = dt.Rows[0][0].ToString();
            return result;
        }

        public Result SaveSystemUser(SystemUser req)
        {
            Result result = new Result();

            if (!req.IsValid())
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = req.StatusDesc;
                return result;
            }

            DataTable dt = dh.ExecuteDataSet("SaveSystemUser", new string[] { req.CompanyCode, req.UserId, req.Password, req.Name, req.UserType, req.ModifiedBy, req.IsActive, req.Email }).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "FAILED: SALE NOT SAVED";
                return result;
            }

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            result.PegPayID = dt.Rows[0][0].ToString();
            return result;
        }



        public Result SaveInGeneralLedger(GeneralLedgerItem req)
        {
            Result result = new Result();

            if (!req.IsValid())
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = req.StatusDesc;
                return result;
            }

            DataTable dt = dh.ExecuteDataSet("SaveGeneralLedgerItem", new string[] { req.CustomerCode, req.CustomerName, req.CustomerCategory, req.PaymentType, req.PaymentCategory, req.TranType, req.TranCategory, req.TranAmount, req.CurrencyCode, req.CompanyCode, req.PaymentDate, req.Narration, req.ModifiedBy, req.InvoiceNumber }).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "FAILED: SALE NOT SAVED";
                return result;
            }

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            result.PegPayID = dt.Rows[0][0].ToString();
            return result;

        }

        public Result SaveUserType(UserType req)
        {
            Result result = new Result();

            if (!req.IsValid())
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = req.StatusDesc;
                return result;
            }

            DataTable dt = dh.ExecuteDataSet("SaveUserType", new string[] { req.CompanyCode, req.UserTypeCode, req.UserTypeName, req.ModifiedBy, req.IsActive }).Tables[0];

            if (dt.Rows.Count <= 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "FAILED: USERTYPE NOT SAVED";
                return result;
            }

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            result.PegPayID = dt.Rows[0][0].ToString();
            return result;

        }

        public Result SaveCompany(Company req)
        {
            Result result = new Result();

            if (!req.IsValid())
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = req.StatusDesc;
                return result;
            }

            DataTable dt = dh.ExecuteDataSet("SaveCompany", new string[] { req.CompanyName, req.CompanyCode, req.CompanyContactEmail, req.ModifiedBy, req.PathToLogoImage, req.ThemeColor, req.NavBarTextColor, req.IsActive }).Tables[0];

            if (dt.Rows.Count <= 0)
            {
                result.StatusCode = Globals.FAILURE_STATUS_CODE;
                result.StatusDesc = "FAILED: COMPANY NOT SAVED";
                return result;
            }

            result.StatusCode = Globals.SUCCESS_STATUS_CODE;
            result.StatusDesc = Globals.SUCCESS_STATUS_TEXT;
            result.PegPayID = dt.Rows[0][0].ToString();
            return result;

        }

        public Result SaveUserAcceptanceTest(UAT Uat)
        {
            Result result = new Result();
            return result;
        }
    }
}
