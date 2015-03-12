<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UCtlTreeView.ascx.vb"
    Inherits="CMCFileManage.UCtlTreeView" %>

<table class="node" cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td>
            <div class="title" onclick="Expand('TreeView')">
                <img src="~/Image/TreeView/topopen.gif" runat="server" id="imgTitle"/><div>
                    操作列表</div>
            </div>
            <div id="TreeView" class="detailTv">
                <asp:TreeView ID="TreeView1" runat="server" CssClass="node">
                <SelectedNodeStyle ForeColor="Red"/>
                
                </asp:TreeView>
            </div>
        </td>
    </tr>
</table>
