﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class MakePayment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //subscripe to events from user controls
            SavePurchase.SaveCompleted += new EventHandler(SavePurchaseCompleted);
            SavePaymentVoucher.SaveCompleted += new EventHandler(SavePaymentVoucherCompleted);
            ListSuppliers.RegisterPurchaseEvent += new EventHandler(RegisterPurchaseRaised);

            if (IsPostBack)
            {

            }
            else
            {
                LoadData();
            }
        }
        catch (Exception ex)
        {

        }
    }

    private void LoadData()
    {
        HighLightCorrectTab();
    }

    private void RegisterPurchaseRaised(object sender, EventArgs e)
    {
        MyEventArgs eventArgs = e as MyEventArgs;
        string Id = eventArgs.PegPayId;
        SavePurchase.LoadDataSpecificForSupplier(Id);
        MultiView.SetActiveView(SavePurchaseView);
        HighLightCorrectTab();
    }

    private void HighLightCorrectTab()
    {
        if (MultiView.GetActiveView() == ListSuppliersView)
        {
            SetActiveTab(ListSuppliersLink);
            return;
        }
        if (MultiView.GetActiveView() == SavePurchaseView)
        {
            SetActiveTab(SavePurchaseLink);
            return;
        }
        if (MultiView.GetActiveView() == SavePaymentVoucherView)
        {
            SetActiveTab(SavePaymentVoucherLink);
            return;
        }
        
    }

    private void SetActiveTab(HtmlGenericControl control)
    {
        ListSuppliersLink.Attributes["class"] = "";
        SavePurchaseLink.Attributes["class"] = "";
        SavePaymentVoucherLink.Attributes["class"] = "";
        control.Attributes["class"] = "active";
    }

    private void SavePurchaseCompleted(object sender, EventArgs e)
    {
        MyEventArgs eventArgs = e as MyEventArgs;
        MultiView.SetActiveView(SavePaymentVoucherView);
        SavePaymentVoucher.SetInvoiceSelected(eventArgs.ThirdPartyId);
        SavePaymentVoucher.ShowExternalMessage();
        HighLightCorrectTab();
    }

    private void SavePaymentVoucherCompleted(object sender, EventArgs e)
    {
        HighLightCorrectTab();
    }

    private void SaveRecieptCompleted(object sender, EventArgs e)
    {
        HighLightCorrectTab();

    }

    protected void btnTabPane_Click(object sender, EventArgs e)
    {
        try
        {
        }
        catch (Exception ex)
        {
            string msg = "FAILED: " + ex.Message;
        }
    }
}