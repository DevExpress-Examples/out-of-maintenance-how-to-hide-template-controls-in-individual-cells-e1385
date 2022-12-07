<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DynamicShowHideTemplate._Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxwgv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                    <dxwgv:ASPxGridView ID="gvTrackingNumbers" runat="server" AutoGenerateColumns="False" KeyFieldName="id" ClientInstanceName="gvTrackingNumbers" EnableCallBacks="False" OnHtmlCommandCellPrepared="gvTrackingNumbers_HtmlCommandCellPrepared"   >
                        <Columns>
                            <dxwgv:GridViewDataTextColumn FieldName="Status" VisibleIndex="3" Width="100px" Name="Status">
                                <CellStyle Wrap="False">
                                </CellStyle>
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Name="colIssues" Caption="  " ReadOnly="True" VisibleIndex="5">
                                <DataItemTemplate>
                                    <a href="javascript:void(0);" onclick="OnIssuesClick(this, '<%# Container.KeyValue %>')" runat="server" visible="<%# GetIssueLinkVisible(Container.VisibleIndex) %>">
                                        Issues </a>
                                </DataItemTemplate>
                                <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowHeaderFilter="False"
                                    ShowFilterRowMenu="False" />
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="  " VisibleIndex="7">
                                <DataItemTemplate>
                                    <a href="javascript:void(0);" onclick="OnReturnsClick(this, '<%# Container.KeyValue %>')" runat="server"  visible="<%# GetReturnLinkVisible(Container.VisibleIndex) %>">
                                        Returns </a>
                                </DataItemTemplate>
                                <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowHeaderFilter="False"
                                    ShowFilterRowMenu="False" />
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewCommandColumn Name="colManage" Caption=" " VisibleIndex="8">
                                <ClearFilterButton Visible="True">
                                </ClearFilterButton>
                                <CustomButtons>
                                    <dxwgv:GridViewCommandColumnCustomButton ID="Manage" Text="Manage">
                                    </dxwgv:GridViewCommandColumnCustomButton>
                                </CustomButtons>
                            </dxwgv:GridViewCommandColumn>
                            <dxwgv:GridViewDataTextColumn FieldName="ParentID" Visible="False" VisibleIndex="9">
                            </dxwgv:GridViewDataTextColumn>
                        </Columns>
                    </dxwgv:ASPxGridView>
    </div>
    </form>
</body>
</html>
