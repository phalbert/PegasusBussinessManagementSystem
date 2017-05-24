using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChangeManagementSystem.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeManagementSystem.EntityClasses;
using System.Data;

namespace ChangeManagementSystem.Main.Tests
{
    [TestClass()]
    public class MSystemInterfaceTests
    {
        [TestMethod()]
        public void ExecuteDataSetTest()
        {
            MSystemInterface MSystem = new MSystemInterface();
            DataTable dt = MSystem.ExecuteDataSet("GetSystemUserByUserId", new string[] { "Nsubugak" }).Tables[0];
            if (dt.Rows.Count > 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }

        }

        [TestMethod()]
        public void SaveRecieptTest()
        {
            MSystemInterface MSystem = new MSystemInterface();
            Reciept req = new Reciept();
            req.BankAccountName = "Nsubuga Kasozi";
            req.BankAccountNumber = "0140586848601";
            req.BankName = "Stanbic";
            req.ChequeNumber = "";
            req.InvoiceNumber = "Invoice-001";
            req.ModifiedBy = "Nsubuga Kasozi";
            req.PaymentDate = "2017-04-17";
            req.CompanyCode = "PEGASUS";
            req.CreatedBy = "Nsubuga Kasozi";
            req.ModifiedBy = "Nsubuga Kasozi";
            req.RecieptCategory = "CLIENT_RECIEPT";
            req.ImageOfReciept = null;
            Result result = MSystem.SaveReciept(req);
            Assert.AreEqual(result.StatusCode, Globals.SUCCESS_STATUS_CODE);
        }

        [TestMethod()]
        public void SaveReciept_MissingParameterTest()
        {
            MSystemInterface MSystem = new MSystemInterface();
            Reciept req = new Reciept();
            req.BankAccountName = "Nsubuga Kasozi";
            req.BankAccountNumber = "0140586848601";
            req.BankName = "Stanbic";
            req.ChequeNumber = "";
            req.InvoiceNumber = "";
            req.ModifiedBy = "Nsubuga Kasozi";
            req.PaymentDate = "2017-04-17";
            req.CompanyCode = "PEGASUS";
            req.CreatedBy = "Nsubuga Kasozi";
            req.ModifiedBy = "Nsubuga Kasozi";
            req.RecieptCategory = "CLIENT_RECIEPT";
            req.ImageOfReciept = null;
            Result result = MSystem.SaveReciept(req);
            Assert.AreNotEqual(result.StatusCode, Globals.SUCCESS_STATUS_CODE);
        }

        [TestMethod()]
        public void SaveSystemUserTest()
        {
            MSystemInterface MSystem = new MSystemInterface();
            SystemUser req = new SystemUser();
            req.Name = "Nsubuga Kasozi";
            req.Password = SharedCommons.SharedCommons.GeneratePassword("Pegasus");
            req.UserId = "Nsubugak";
            req.UserType = "ADMIN";
            req.IsActive = "true";
            Result result = MSystem.SaveSystemUser(req);
            Assert.AreEqual(result.StatusCode, Globals.SUCCESS_STATUS_CODE);
        }

        [TestMethod()]
        public void SaveUserAcceptanceTestTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveClientTest()
        {
            MSystemInterface MSystem = new MSystemInterface();
            Client req = new Client();
            req.BankAccountName = "Nsubuga Kasozi";
            req.BankAccountNumber = "0140586848601";
            req.BankName = "STANBIC";
            req.ClientAddress = "3rd Floor";
            req.ClientCode = "PEGASUS-001";
            req.ClientName = "Soma Limited";
            req.CompanyCode = "PEGASUS";
            req.ContactPersonName = "Nsubuga Kasozi";
            req.CreatedBy = "Nsubuga Kasozi";
            req.Email = "nkasozi@gmail.com";
            req.ModifiedBy = "Nsubuga Kasozi";
            req.TelephoneNumber = "0785975800";
            req.MobileNumber = "0785975800";
            Result result = MSystem.SaveClient(req);
            Assert.AreEqual(result.StatusCode, Globals.SUCCESS_STATUS_CODE);
        }

        [TestMethod()]
        public void SaveSupplierTest()
        {
            MSystemInterface MSystem = new MSystemInterface();
            Supplier req = new Supplier();
            req.BankAccountName = "Nsubuga Kasozi";
            req.BankAccountNumber = "0140586848601";
            req.BankName = "STANBIC";
            req.SupplierAddress = "3rd Floor";
            req.SupplierCode = "SUPPLIER-001";
            req.SupplierName = "Soma Limited";
            req.CompanyCode = "PEGASUS";
            req.ContactPersonName = "Nsubuga Kasozi";
            req.CreatedBy = "Nsubuga Kasozi";
            req.Email = "nkasozi@gmail.com";
            req.ModifiedBy = "Nsubuga Kasozi";
            req.TelephoneNumber = "0785975800";
            req.MobileNumber = "0785975800";
            Result result = MSystem.SaveSupplier(req);
            Assert.AreEqual(result.StatusCode, Globals.SUCCESS_STATUS_CODE);
        }

        [TestMethod()]
        public void SaveSaleItemTest()
        {
            MSystemInterface MSystem = new MSystemInterface();
            SaleItem req = new SaleItem();
            req.SaleID = "Sale-001";
            req.ItemDesc = "InterOperability System";
            req.ItemQuantity = "1";
            req.UnitPrice = "1000";
            req.ModifiedBy = "Nsubuga Kasozi";
            req.SubTotal = "1000";
            req.CompanyCode = "PEGASUS";
            req.CreatedBy = "Nsubuga Kasozi";
            req.ModifiedBy = "Nsubuga Kasozi";
            Result result = MSystem.SaveSaleItem(req);
            Assert.AreEqual(result.StatusCode, Globals.SUCCESS_STATUS_CODE);
        }

        [TestMethod()]
        public void SaveSaleTest()
        {
            MSystemInterface MSystem = new MSystemInterface();
            Sale req = new Sale();
            req.SaleID = "Sale-001";
            req.ClientCode = "SOMA";
            req.CurrencyCode = "UGX";
            req.DiscountAmount = "300";
            req.ModifiedBy = "Nsubuga Kasozi";
            req.AnyOtherTaxAmount = "100";
            req.CompanyCode = "PEGASUS";
            req.CreatedBy = "Nsubuga Kasozi";
            req.ModifiedBy = "Nsubuga Kasozi";
            Result result = MSystem.SaveInSalesLedger(req);
            Assert.AreEqual(result.StatusCode, Globals.SUCCESS_STATUS_CODE);
        }

        [TestMethod()]
        public void SavePurchaseTest()
        {
            MSystemInterface MSystem = new MSystemInterface();
            Purchase req = new Purchase();
            req.InvoiceNumber = "Invoice-001";
            req.InvoiceDate = "2017-04-14";
            req.InvoiceAmount = "1000";
            req.AnyOtherTax = "0";
            req.CurrencyCode = "UGX";
            req.DiscountAmount = "300";
            req.ModifiedBy = "Nsubuga Kasozi";
            req.IsPaid = "false";
            req.SupplierCode = "SUPPLIER-001";
            req.SupplierName = "SOMA";
            req.TaxAmount = "200";
            req.TotalInvoiceAmount = "1200";
            req.CompanyCode = "PEGASUS";
            req.CreatedBy = "Nsubuga Kasozi";
            req.ModifiedBy = "Nsubuga Kasozi";
            Result result = MSystem.SaveInPurchasesLedger(req);
            Assert.AreEqual(result.StatusCode, Globals.SUCCESS_STATUS_CODE);
        }


        [TestMethod()]
        public void SavePaymentVoucherTest()
        {
            MSystemInterface MSystem = new MSystemInterface();
            PaymentVoucher req = new PaymentVoucher();
            req.InvoiceNumber = "Invoice-001";
            req.IsUsed = "false";
            req.Reason = "Over due payment";
            req.VoucherAmount = "1000";
            req.VoucherCode = "Voucher-001";

            req.ModifiedBy = "Nsubuga Kasozi";

            req.CompanyCode = "PEGASUS";
            req.CreatedBy = "Nsubuga Kasozi";
            req.ModifiedBy = "Nsubuga Kasozi";
            Result result = MSystem.SavePaymentVoucher(req);
            Assert.AreEqual(result.StatusCode, Globals.SUCCESS_STATUS_CODE);
        }

        [TestMethod()]
        public void SaveInvoiceTest()
        {
            MSystemInterface MSystem = new MSystemInterface();
            Invoice req = new Invoice();
            req.InvoiceNumber = "Invoice-001";
            req.AnyOtherTax = "0";
            req.CurrencyCode = "UGX";
            req.DiscountAmount = "100";
            req.InvoiceAmount = "1000";
            req.InvoiceDate = "2017-04-14";
            req.Narration = "Purchase of Food";
            req.TaxAmount = "200";
            req.ModifiedBy = "Nsubuga Kasozi";
            req.CompanyCode = "PEGASUS";
            req.CreatedBy = "Nsubuga Kasozi";
            req.ModifiedBy = "Nsubuga Kasozi";
            req.IsPaid = "FALSE";
            req.ClientCode = "CLIENT-001";
            req.InvoiceCategory = "CLIENT_INVOICE";
            req.ImageOfInvoice = null;
            Result result = MSystem.SaveInvoice(req);
            Assert.AreEqual(result.StatusCode, Globals.SUCCESS_STATUS_CODE);
        }

        [TestMethod()]
        public void SaveGeneralLedgerTest()
        {
            MSystemInterface MSystem = new MSystemInterface();
            GeneralLedgerItem req = new GeneralLedgerItem();
            req.InvoiceNumber = "Invoice-001";
            req.CustomerCategory = "SUPPLIER";
            req.CustomerCode = "SUPPLIER-001";
            req.CustomerName = "SOMA";
            req.Narration = "Payment for Food";
            req.PaymentCategory = "INVOICE";
            req.PaymentDate = "2017-04-17";
            req.PaymentType = "CASH";
            req.TranAmount = "1000";
            req.TranCategory = "SUPPLIER-PAYMENT";
            req.TranType = "Debit";
            req.CurrencyCode = "UGX";
            req.Narration = "Purchase of Food";

            req.ModifiedBy = "Nsubuga Kasozi";

            req.CompanyCode = "PEGASUS";
            req.CreatedBy = "Nsubuga Kasozi";
            req.ModifiedBy = "Nsubuga Kasozi";
            Result result = MSystem.SaveGeneralLedgerItem(req);
            Assert.AreEqual(result.StatusCode, Globals.SUCCESS_STATUS_CODE);
        }

        [TestMethod()]
        public void SaveContractTest()
        {
            MSystemInterface MSystem = new MSystemInterface();
            Contract req = new Contract();
            req.ClientCode = "CLIENT-001";
            req.ContractCategory = "CLIENT-CONTRACT";
            req.ContractId = "CONTRACT-001";
            req.ContractType = "ROLLING";
            req.DurationInDays = "365";
                     req.StartDate = "2017-04-17";

            req.ModifiedBy = "Nsubuga Kasozi";

            req.CompanyCode = "PEGASUS";
            req.CreatedBy = "Nsubuga Kasozi";
            req.ModifiedBy = "Nsubuga Kasozi";
            Result result = MSystem.SaveContract(req);
            Assert.AreEqual(result.StatusCode, Globals.SUCCESS_STATUS_CODE);
        }
    }
}