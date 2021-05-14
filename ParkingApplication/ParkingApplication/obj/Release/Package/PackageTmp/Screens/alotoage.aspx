<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="alotoage.aspx.cs" Inherits="ParkingApplication.Screens.alotoage" %>

<%@ Register src="UserControl.ascx" tagname="UserControl" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        
        .auto-style1 {}
        
    </style>
</head>
<body style="color:azure;">
    <form id="form1" runat="server">
        <div style="height:80px;"></div>
        <div style="background-color:bisque;width:100%;height:100px;">
        <table>
            <tr>
                <td style="text-align:center;width:400px;">
                    <asp:DropDownList ID="DDlistLevel" Width="250px" Font-Bold="true" AutoPostBack="true" OnSelectedIndexChanged="DDlistLevel_SelectedIndexChanged" BackColor="#66ff33" ForeColor="#ff0066" runat="server">
                          <asp:ListItem Text="Select Level" Value="0"></asp:ListItem>
                        <asp:ListItem Text="LEVEL 1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="LEVEL 2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="LEVEL 3" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                
                </td>     
                <td>
                      <div style="color:bisque;width:1000px;">
            <asp:GridView ID="gridViewLevelInfo" DataKeyNames="LID" Width="800px"  AutoGenerateColumns="false" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" HorizontalAlign="Center">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
                <Columns>                                       
                    <asp:BoundField DataField="LNAME" HeaderText="Level Name" />
                    <asp:BoundField DataField="TOTAL" HeaderText="Total Space" />
                    <asp:BoundField DataField="ALOT" HeaderText="Alloted Space" />
                    <asp:BoundField DataField="FREE" HeaderText="Free Space" />
                     <asp:BoundField DataField="NOOF2W" HeaderText="Total No. Of 2 Wheeler" />
                     <asp:BoundField DataField="NOOFCAR" HeaderText="Total No. Of Car" />
                     <asp:BoundField DataField="NOOFBUS" HeaderText="Total No. Of Bus" />
                </Columns>
            </asp:GridView>
        </div> 
                </td>
            </tr>
        </table>     
        </div>
        <div style="height:40px;"></div>
        
        <div id="divUserInfo" runat="server" style="text-align:center;width:100%;background-color:lavender;height:200px;">
            <table  style="text-align:center;">
                <tr>
                    <td style="text-align:right;width:500px;">
                        <asp:Label ID="lblUserName" Font-Bold="True" Width="70%"  runat="server" ForeColor="#FF0066" Text="User Name"></asp:Label>
                    </td>
                    <td style="text-align:center;width:500px;">
                        <asp:TextBox ID="txtUserName" Font-Bold="true"  Width="70%" ForeColor="#ff0066" runat="server"></asp:TextBox>

                    </td>
                   
                </tr>
                 <tr>
                    <td style="text-align:right;width:500px;">
                        <asp:Label ID="lblMobileNo" Font-Bold="True" Width="70%"  runat="server" ForeColor="#FF0066" Text="Mobile No." ></asp:Label>
                    </td>
                    <td style="text-align:center;width:500px;">
                        <asp:TextBox ID="txtMobile" Font-Bold="true"  Width="70%" ForeColor="#ff0066" runat="server"></asp:TextBox>

                    </td>
                   
                </tr>
               
                <tr>
                    <td style="text-align:right;width:500px;">
                       <asp:Label ID="lblVehicleName" runat="server" Width="70%" Font-Bold="true" ForeColor="#ff0066" Text="Vehicle Name"></asp:Label>
                    </td>
                    <td style="text-align:center;width:500px;">
                        <asp:TextBox ID="txtVehicleName"   Width="70%" ForeColor="#ff0066" Font-Bold="true" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td style="text-align:right;width:500px;">
                    <asp:Label ID="lblVehicleType" runat="server" Width="70%" Font-Bold="true" ForeColor="#ff0066" Text="Vehicle Type"></asp:Label>
                    </td>
                    <td style="text-align:center;width:500px;"  >
                        <asp:DropDownList ID="DDlistVehicleType" OnSelectedIndexChanged="DDlistVehicleType_SelectedIndexChanged" Width="70%" Font-Bold="true" runat="server">
                            <asp:ListItem Text="Select Vehicle" Value="0" ></asp:ListItem>
                            <asp:ListItem Text="2 wheeler" Value="T" ></asp:ListItem>
                            <asp:ListItem Text="Car" Value="C"></asp:ListItem>
                            <asp:ListItem Text="Bus" Value="B"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                  <tr>
                    <td style="text-align:right;width:500px;">
                    <asp:Label ID="lblVehicleDesc" runat="server" Width="70%" Font-Bold="true" ForeColor="#ff0066" Text="Vehicle Description"></asp:Label>
                    </td>
                    <td style="text-align:center;width:500px;"  >
                        <asp:TextBox ID="txtDescr" TextMode="MultiLine" Rows="4" Width="70%" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div style="height:40px;"></div>
     <div id="divButtonPart" runat="server" style="text-align:center;border-style:ridge;border-width:0px;  width:100%;background-color:cornsilk;">
         
       
         <asp:GridView  ID="gridAlot" runat="server" OnRowDataBound="gridAlot_RowDataBound"  BackColor="White" HorizontalAlign="Center" BorderColor="#3366CC" AutoGenerateColumns="false" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="auto-style1" Width="500px">
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
                 <asp:TemplateField>
                     <ItemTemplate>
                         <uc1:UserControl ID="UserCtr1"  runat="server"/>     
                     </ItemTemplate>
                 </asp:TemplateField>
           <asp:TemplateField>
                     <ItemTemplate>
                         <uc1:UserControl ID="UserCtr2" runat="server"  />     
                     </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField>
                     <ItemTemplate>
                         <uc1:UserControl ID="UserCtr3" runat="server"/>     
                     </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField>
                     <ItemTemplate>
                         <uc1:UserControl ID="UserCtr4" runat="server"/>     
                     </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField>
                     <ItemTemplate>
                         <uc1:UserControl ID="UserCtr5" runat="server" />     
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <uc1:UserControl ID="UserCtr6" runat="server" />     
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <uc1:UserControl ID="UserCtr7" runat="server" />     
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <uc1:UserControl ID="UserCtr8" runat="server" />     
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <uc1:UserControl ID="UserCtr9"  runat="server" />     
                     </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField>
                     <ItemTemplate>
                         <uc1:UserControl ID="UserCtr10" runat="server" />     
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
         </asp:GridView>
         
     </div>
    </form>
</body>
</html>
