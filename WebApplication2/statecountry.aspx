<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StateCountry.aspx.cs" Inherits="WebApplication2.StateCountry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<asp:Panel ID="pnlShow" runat="server"> 
    <table>
                <tr>
                     <td style="width: 279px">
                           Country:
                          <asp:DropDownList ID="ddlSearchCountry" runat="server" >
                       </asp:DropDownList>
                 </td>
                    <td>
                        
                         &nbsp;</td>
                    
                    <td>State:
                       <asp:DropDownList ID="ddlSearchState" runat="server"> 
                       </asp:DropDownList>
                    </td>

                    

       
                     <td>
                         <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                         &nbsp;&nbsp;&nbsp;
                         <asp:Button ID="btnAddNew" runat="server" OnClick="btnAddnew_Click" Text="Addnew" />
                     </td>

                    

       
          </tr>
            </table>
    <div>
        <asp:GridView ID="gvStateCountry" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="State" DataField="StateName" />
                <asp:BoundField HeaderText="Country" DataField="CountryName" />
                <asp:ButtonField ButtonType="Button" CommandName="upd" Text="Edit" />
                <asp:ButtonField ButtonType="Button" CommandName="dlt" Text="Delete" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
     </asp:Panel>
    <asp:Panel ID="pnlAdd" runat="server" Visible="false">
        <table>
        <tr>
                    <td style="height: 35px">Country</td>
                    <td style="height: 35px">
                        <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="height: 35px">State</td>
                    <td style="height: 35px">
                        <asp:DropDownList ID="ddlState" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            <tr>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </asp:Panel >
</asp:Content>
