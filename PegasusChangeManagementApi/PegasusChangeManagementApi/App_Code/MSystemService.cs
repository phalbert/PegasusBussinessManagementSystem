using ChangeManagementSystem.EntityClasses;
using ChangeManagementSystem.Main;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService(Namespace = "http://pegasus.co.ug/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class MSystemService : System.Web.Services.WebService
{
    MSystemInterface MSystem = new MSystemInterface();
    public MSystemService()
    {

    }

    [WebMethod]
    public DataSet ExecuteDataSet(string storedProcName, string[] parameters)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = MSystem.ExecuteDataSet(storedProcName, parameters);
            return ds;
        }
        catch (Exception ex)
        {
            MSystem.LogError(storedProcName, ex.StackTrace, "", ex.Message, "EXCEPTION");
            throw new SoapException(ex.Message, new System.Xml.XmlQualifiedName(ex.Message), ex);
        }
    }

    [WebMethod]
    public int ExecuteNonQuery(string storedProcName, string[] parameters)
    {
        int rowsAffected = 0;
        try
        {
            rowsAffected= MSystem.ExecuteNonQuery(storedProcName, parameters);
            return rowsAffected;
        }
        catch (Exception ex)
        {
            MSystem.LogError(storedProcName, ex.StackTrace, "", ex.Message, "EXCEPTION");
            throw new SoapException(ex.Message, new System.Xml.XmlQualifiedName(ex.Message), ex);
        }
    }

    [WebMethod]
    public Entity GetById(string CompanyCode, string ObjectClassName, string ObjectId)
    {
        Entity result = new Entity();
        try
        {
            result = MSystem.GetById(CompanyCode, ObjectClassName, ObjectId);
        }
        catch (Exception ex)
        {
            MSystem.LogError(ObjectClassName + "-" + ObjectId, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }
        return result;
    }


    [WebMethod]
    public SystemUser Login(string UserId, string Password)
    {
        SystemUser result = new SystemUser();
        try
        {
            result = MSystem.Login(UserId, Password);
        }
        catch (Exception ex)
        {
            MSystem.LogError(UserId + "-" + Password, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }
        return result;
    }

    [WebMethod]
    public Result LogOut(string UserId)
    {
        Result result = new Result();
        try
        {
            result = MSystem.LogOut(UserId);
        }
        catch (Exception ex)
        {
            MSystem.LogError(UserId, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }
        return result;
    }

    [WebMethod]
    public Result SaveChangeRequest(ChangeRequest req)
    {
        Result result = new Result();
        try
        {
            result = MSystem.SaveChangeRequest(req);
        }
        catch (Exception ex)
        {
            MSystem.LogError(result.RequestID, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }
        return result;
    }

    [WebMethod]
    public Result SaveSupplier(Supplier req)
    {
        Result result = new Result();
        try
        {
            result = MSystem.SaveSupplier(req);
        }
        catch (Exception ex)
        {
            MSystem.LogError(req.SupplierCode, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }
        return result;
    }

    [WebMethod]
    public Result SaveCompany(Company req)
    {
        Result result = new Result();
        try
        {
            result = MSystem.SaveCompany(req);
        }
        catch (Exception ex)
        {
            MSystem.LogError(req.CompanyCode, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }
        return result;
    }

    [WebMethod]
    public Result SaveUserType(UserType req)
    {
        Result result = new Result();
        try
        {
            result = MSystem.SaveUserType(req);
        }
        catch (Exception ex)
        {
            MSystem.LogError(req.CompanyCode, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }
        return result;
    }


    [WebMethod]
    public Result SaveInvoice(Invoice req)
    {
        Result result = new Result();
        try
        {
            result = MSystem.SaveInvoice(req);
        }
        catch (Exception ex)
        {
            MSystem.LogError(req.InvoiceNumber, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }
        return result;
    }

    [WebMethod]
    public Result SaveContract(Contract req)
    {
        Result result = new Result();
        try
        {
            result = MSystem.SaveContract(req);
        }
        catch (Exception ex)
        {
            MSystem.LogError(req.ContractId, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }
        return result;
    }

    [WebMethod]
    public Result SaveGeneralLedgerItem(GeneralLedgerItem req)
    {
        Result result = new Result();
        try
        {
            result = MSystem.SaveGeneralLedgerItem(req);
        }
        catch (Exception ex)
        {
            MSystem.LogError(req.CustomerCode, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }
        return result;
    }

    [WebMethod]
    public Result SaveClient(Client req)
    {
        Result result = new Result();
        try
        {
            result = MSystem.SaveClient(req);
        }
        catch (Exception ex)
        {
            MSystem.LogError(req.ClientCode, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }
        return result;
    }

    [WebMethod]
    public Result SavePaymentVoucher(PaymentVoucher req)
    {
        Result result = new Result();
        try
        {
            result = MSystem.SavePaymentVoucher(req);
        }
        catch (Exception ex)
        {
            MSystem.LogError(req.VoucherCode, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }
        return result;
    }

    [WebMethod]
    public Result SaveReciept(Reciept req)
    {
        Result result = new Result();
        try
        {
            result = MSystem.SaveReciept(req);
        }
        catch (Exception ex)
        {
            MSystem.LogError(req.RecieptNumber, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }
        return result;
    }

    [WebMethod]
    public Result SaveInPurchasesLedger(Purchase req)
    {
        Result result = new Result();
        try
        {
            result = MSystem.SaveInPurchasesLedger(req);
        }
        catch (Exception ex)
        {
            MSystem.LogError(req.InvoiceNumber + "-" + req.SupplierCode, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }
        return result;
    }

    [WebMethod]
    public Result SaveInSalesLedger(Sale req)
    {
        Result result = new Result();
        try
        {
            result = MSystem.SaveInSalesLedger(req);
        }
        catch (Exception ex)
        {
            MSystem.LogError(req.SaleID, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }
        return result;
    }

    [WebMethod]
    public Result SaveSystemSetting(SystemSetting req)
    {
        Result result = new Result();
        try
        {
            result = MSystem.SaveSystemSetting(req);
        }
        catch (Exception ex)
        {
            MSystem.LogError(req.SettingCode, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }
        return result;
    }

    [WebMethod]
    public Result SaveSaleItem(SaleItem req)
    {
        Result result = new Result();
        try
        {
            result = MSystem.SaveSaleItem(req);
        }
        catch (Exception ex)
        {
            MSystem.LogError(req.SaleID, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }
        return result;
    }

    [WebMethod]
    public Result LogError(string Identifier,string StackTrace, string CompanyCode,string Message,string ErrorType)
    {
        Result result = new Result();
        try
        {
            result = MSystem.LogError(Identifier,StackTrace,CompanyCode,Message,ErrorType);
        }
        catch (Exception ex)
        {
            MSystem.LogError(result.RequestID, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }
        return result;
    }

    [WebMethod]
    public Result SaveUserAcceptanceTest(UAT Uat)
    {
        Result result = new Result();
        try
        {
            result = MSystem.SaveUserAcceptanceTest(Uat);
        }
        catch (Exception ex)
        {
            MSystem.LogError(result.RequestID, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }

        return result;
    }

    [WebMethod]
    public Result SaveSystemUser(SystemUser req)
    {
        Result result = new Result();
        try
        {
            result = MSystem.SaveSystemUser(req);
        }
        catch (Exception ex)
        {
            MSystem.LogError(result.RequestID, ex.StackTrace, "", ex.Message, "EXCEPTION");
            result.StatusCode = Globals.HIDE_FAILURE_STATUS_CODE;
            result.StatusDesc = "EXCEPTION: " + ex.Message;
        }
        return result;
    }

}