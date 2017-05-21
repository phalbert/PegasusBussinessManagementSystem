using ChangeManagementSystem.ControlClasses;
using ChangeManagementSystem.EntityClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ChangeManagementSystem.Main
{
    public class MSystemInterface
    {
        BussinessLogic bll = new BussinessLogic();
        public DataSet ExecuteDataSet(string storedProcName, string[] parameters)
        {
            return bll.ExecuteDataSet(storedProcName, parameters);
        }

        public int ExecuteNonQuery(string storedProcName, string[] parameters)
        {
            return bll.ExecuteNonQuery(storedProcName, parameters);
        }

        public Entity GetById(string CompanyCode, string ObjectClassName, string ObjectId)
        {
            return bll.GetById(CompanyCode,ObjectClassName, ObjectId);
        }

        public SystemUser Login(string UserId, string Password)
        {
            return bll.Login(UserId, Password);
        }

        public Result LogError(string ErrorIdentifier, string StackTrace, string CompanyCode, string Message, string ErrorType)
        {
            return bll.LogError(ErrorIdentifier, StackTrace, CompanyCode, Message, ErrorType);
        }

        public Result LogOut(string UserId)
        {
            return bll.LogOut(UserId);
        }

        public Result SaveChangeRequest(ChangeRequest req)
        {
            return bll.SaveChangeRequest(req);
        }

        public Result SaveSupplier(Supplier req)
        {
            return bll.SaveSupplier(req);
        }

        public Result SaveInvoice(Invoice req)
        {
            return bll.SaveInvoice(req);
        }

        public Result SaveContract(Contract req)
        {
            return bll.SaveContract(req);
        }

        public Result SaveCompany(Company req)
        {
            return bll.SaveCompany(req);
        }

        public Result SaveUserType(UserType req)
        {
            return bll.SaveUserType(req);
        }

        public Result SaveGeneralLedgerItem(GeneralLedgerItem req)
        {
            return bll.SaveInGeneralLedger(req);
        }

        public Result SaveClient(Client req)
        {
            return bll.SaveClient(req);
        }

        public Result SaveSystemSetting(SystemSetting req)
        {
            return bll.SaveSystemSetting(req);
        }

        public Result SavePaymentVoucher(PaymentVoucher req)
        {
            return bll.SavePaymentVoucher(req);
        }

        public Result SaveReciept(Reciept req)
        {
            return bll.SaveReciept(req);
        }

        public Result SaveInPurchasesLedger(Purchase req)
        {
            return bll.SaveInPurchaseLedger(req);
        }

        public Result SaveSystemUser(SystemUser req)
        {
            return bll.SaveSystemUser(req);
        }

        public Result SaveInSalesLedger(Sale req)
        {
            return bll.SaveInSalesLedger(req);
        }

        public Result SaveSaleItem(SaleItem req)
        {
            return bll.SaveSaleItem(req);
        }

        public Result SaveUserAcceptanceTest(UAT Uat)
        {
            return bll.SaveUserAcceptanceTest(Uat);
        }
    }
}
