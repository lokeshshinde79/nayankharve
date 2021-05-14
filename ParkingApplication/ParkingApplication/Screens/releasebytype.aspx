<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="releasebytype.aspx.cs" Inherits="ParkingApplication.Screens.releasebytype" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:seashell;">
    <form id="form1" runat="server">
        <div style="height:50px;"></div>
        <div style="text-align:center;">

            <asp:GridView ID="gridUserInfo" AutoGenerateColumns="false" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Font-Bold="True" HorizontalAlign="Center" Width="900px">
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            <Columns>
                <asp:BoundField DataField="SNO" HeaderText="S.NO." />
                <asp:BoundField DataField="Level" HeaderText="Level" />
                <asp:BoundField DataField="VType" HeaderText="Vehicle Type" />
                <asp:BoundField DataField="UserName" HeaderText="User Name" />
                <asp:BoundField DataField="Usermob" HeaderText="User Mobile" />
                <asp:BoundField DataField="VName" HeaderText="Vehicle Name" />
                <asp:BoundField DataField="VDesc" HeaderText="Vehicle Description" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="linkRelease" OnClick="linkRelease_Click" runat="server">Release</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
            
        </div>
    </form>
</body>
</html>
