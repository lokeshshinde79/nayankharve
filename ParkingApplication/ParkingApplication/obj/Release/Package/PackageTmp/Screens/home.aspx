<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="ParkingApplication.Screens.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:antiquewhite;">
    <form id="form1" runat="server">
        <div style="height:270px;"></div>
        <div style="text-align:center;vertical-align:central;">
            <asp:GridView OnRowDataBound="GridView1_RowDataBound" Font-Size="Larger" ID="GridView1" Width="800px" AutoGenerateColumns="False" HorizontalAlign="Center"  runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
                <Columns >                   
                    <asp:BoundField DataField="LNAME" HeaderText="Level Name"  />
                    <asp:BoundField DataField="TOTAL"  HeaderText="Total Space" />
                    <asp:BoundField DataField="ALOT"  HeaderText="Alotted Space" />
                    <asp:BoundField DataField="FREE"  HeaderText="Free Space" />
                  
        <asp:TemplateField  HeaderText="No. Of Bike" >
            <ItemTemplate  >
                <asp:LinkButton  ID="Link2WVehicle" onClick="Link2WVehicle_Click" runat="server"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField  HeaderText="No. Of Car">
            <ItemTemplate>
              <asp:LinkButton  ID="LinkCar" OnClick="LinkCar_Click" runat="server"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
          <asp:TemplateField  HeaderText="No. Of Bus" >
            <ItemTemplate  >
              <asp:LinkButton ID="LinkBus" onClick="LinkBus_Click"  runat="server"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
        </div>
        <div style="height:50px;" ></div>
        <div style="text-align:center;vertical-align:bottom;">
            <table style="text-align:center;">
                <tr>
                    <td style="width:900px;text-align:right;border-style:ridge;border-width:0px;">
                        <asp:Button ID="btnAlot" BackColor="#ff33cc" Font-Bold="true" OnClick="btnAlot_Click" Font-Size="Large" runat="server" Text="Alot Space" />
                    </td>
                    <td style="width:400px;text-align:center; border-style:ridge;border-width:0px;">
                        <asp:Button ID="btnRelese" BackColor="#ff33cc" Font-Bold="true" Font-Size="Large" OnClick="btnRelese_Click" runat="server" Text="Relese Space" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
