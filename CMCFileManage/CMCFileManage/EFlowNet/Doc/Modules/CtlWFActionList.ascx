<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlWFActionList.ascx.vb"
    Inherits="eWorkFlow.eFlowDoc.CtlWFActionList" %>
<div id="HiddenInfo" style="display: none">
    <asp:HiddenField ID="HidNextStateName" Value="" runat="server" />
    <asp:HiddenField ID="HidNextStateID" Value="0" runat="server" />
    <asp:HiddenField ID="HidProcessState" runat="server" Value="0" />
    <asp:HiddenField ID="HidSubmitResult" runat="server" Value="" />
    <asp:HiddenField ID="HidNextUser" runat="server" />
    <asp:HiddenField ID="HidFileList" runat="server" />
    <asp:HiddenField ID="HidTranUserDate" runat="server" />
    <asp:HiddenField ID="HidDisUser" runat="server" />
    <asp:HiddenField ID="HidIsAduit" runat="server" />
    <asp:HiddenField ID="HidGenerationType" runat="server" />
    <asp:HiddenField ID="HidSepInfo" runat="server" />
    <asp:HiddenField ID="HidDataMsg" runat="server" />
    <asp:HiddenField ID="HidActionInfo" runat="server" />
    <asp:HiddenField ID="HidSignInfo" runat="server" />
    <asp:HiddenField ID="HidIsAuto" Value="false" runat="server" />
    <asp:HiddenField ID="HidHuiqian" Value="1" runat="server" />
    <asp:HiddenField ID="HidSignField" Value="" runat="server" />
    <asp:HiddenField ID="HidFileDic" Value="" runat="server" />
    <asp:HiddenField ID="HidIsEndState" Value="false" runat="server" />
</div>
<div style="float: left; width: 40%; text-align: left;">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</div>
<div style="float: right; width: 50%; text-align: right;">
    <div style="float: left; width: 25%; text-align: right; font-size: 10pt">
        <asp:Label ID="lblProprity" Visible="false" Style="_vertical-align: bottom;" runat="server"></asp:Label>
    </div>
    <div style="float: left; width: 20%; text-align: left; font-size: 10pt">
        <asp:RadioButtonList ID="ChkPrority" Visible="false" Style="_vertical-align: top;"
            RepeatDirection="Horizontal" runat="server" RepeatLayout="Flow">
        </asp:RadioButtonList>
    </div>
    <div style="float: left; width: 50%; text-align: right;">
        <asp:LinkButton ID="LinkManage" Visible="false" Text ="重新指派" class="easyui-linkbutton" iconCls="icon-Manage"
            runat="server"></asp:LinkButton>
        <asp:LinkButton ID="LinkSave" Visible="false" class="easyui-linkbutton" iconCls="icon-save"
            runat="server"></asp:LinkButton>
        <asp:LinkButton ID="LinkDelete" Visible="false" class="easyui-linkbutton" iconCls="icon-no"
            runat="server"></asp:LinkButton>
        <asp:LinkButton ID="linkLeave" Visibl="false" class="easyui-linkbutton" iconCls="icon-back"
            runat="server"></asp:LinkButton>
    </div>
</div>
<div id="SelectUserDialog" closed="true"  closable='false' buttons="#dlg-flowbuttons" icon="icon-save">
    <div id="FlowUserInfo" class="easyui-panel" closed="false">
    </div>
    <div id="DlgAdvice" style="display: none;">
        <br />
        <asp:Label ID="LblTitle" runat="server"></asp:Label>
        <asp:TextBox ID="TxtAdvice" Width="200px" TextMode="MultiLine" runat="server"></asp:TextBox>
    </div>
</div>
<div id="dlg-flowbuttons" style="display: none;">
    <asp:LinkButton ID="BtnAduit" class="easyui-linkbutton" plain="true" iconCls="icon-add"
        runat="server"></asp:LinkButton>
    <asp:LinkButton ID="linkCancel" class="easyui-linkbutton" plain="true" iconCls="icon-no" runat="server"></asp:LinkButton>
</div>
