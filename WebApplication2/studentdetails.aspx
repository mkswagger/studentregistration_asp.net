<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="studentdetails.aspx.cs" Inherits="WebApplication2.WebForm3" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <br />
        <h1>Student Details</h1>
        <br />
        <asp:Panel ID="pnlAdd" runat="server" Visible="false">
            <table class="registration-form">
                <tr>
                    <td>
                        Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" Autocomplete="off" Placeholder="Name"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtName" FilterType="LowercaseLetters" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Please enter your name" Font-Size="Small" ForeColor="Red" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>

        </tr>
        <tr>
            <td>
                Mobile
            </td>
            <td>
                <asp:TextBox ID="txtMobile" runat="server" MaxLength="10"  Autocomplete="off"></asp:TextBox>
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtMobile" Filtertype="Numbers"/>
            </td>
        </tr>
        <tr>
            
               <td>&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="rfMobile" runat="server" ErrorMessage="Please enter your Mobile no"  Font-Size="Small" ForeColor="Red" ControlToValidate ="txtMobile"></asp:RequiredFieldValidator>
                <br />
            </td>
         
        </tr>
        <tr>
            <td>
                Email
                </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" Autocomplete="off" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            
               <td>&nbsp;</td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="invalid email" Font-Size="Small" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Please enter your Email id"  Font-Size="Small" ForeColor="Red" ControlToValidate ="txtEmail"></asp:RequiredFieldValidator>
                </td>
         
        </tr>
        <tr>
            
               <td>Password</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" Placeholder="Password" Autocomplete="off" TextMode="Password" ></asp:TextBox>
            </td>
         
        </tr>
        <tr>
            
               <td>&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="rfPassword" runat="server" ErrorMessage="Please enter your Password"  Font-Size="Small" ForeColor="Red" ControlToValidate ="txtPassword"></asp:RequiredFieldValidator>
                </td>
         
        </tr>
        <tr>
            
               <td>Confirm Password</td>
            <td>
                <asp:TextBox ID="txtCpassword" runat="server" Placeholder="Password" Autocomplete="off" TextMode="Password" ></asp:TextBox>
               </td>
         
        </tr>
        <tr>
         <td>&nbsp;</td>
         <td>
              <asp:CompareValidator ID="cvPassword" runat="server" ErrorMessage="Passwords do not match" Font-Size="Small" ForeColor="Red" ControlToValidate="txtCpassword" Operator="Equal" Type="String" ValidationGroup="registration" ValueToCompare="#txtPassword"></asp:CompareValidator>
              <asp:RequiredFieldValidator ID="rfvCPassword" runat="server" ErrorMessage="Please confirm your Password" Font-Size="Small" ForeColor="Red" ControlToValidate="txtCpassword"></asp:RequiredFieldValidator>
        </td>
       </tr>
        <tr>
            <td>
                DOB
            </td>
            <td>
                 <asp:TextBox ID="txtDOB" runat="server" Placeholder="DOB" AutoComplete="off" ></asp:TextBox>
                 <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDOB" />
            </td>
        </tr>
        <tr>
            <td>
                Course
            </td>
            <td>
                
               <asp:DropDownList ID="ddlCourse" runat="server">
     
        
            </asp:DropDownList>
            </td>
            
        </tr>
        <tr>
          <td>
             Gender
          </td>  
           <td>
               <asp:RadioButtonList ID="rblGgender" runat="server" RepeatDirection="Horizontal">
                      <asp:ListItem Value="1">Male</asp:ListItem>
                      <asp:ListItem Value="2">Female</asp:ListItem>
               </asp:RadioButtonList>
           </td>

        </tr>
        <tr>
            <td>Image</td>
            <td>
                <asp:FileUpload ID="ImgUpload" runat="server" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
       
            
            
                
          <tr>
                    <td>
                        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlShow" runat="server">
            <table>
                <tr>
                     <td style="width: 279px">
                           Name:
                           <asp:TextBox ID="txtSearchName" runat="server" Autocomplete="off" PlaceHolder="Name" ></asp:TextBox>
                 </td>
                    <td>
                        
                         &nbsp;</td>
                    

       
                     <td>Gender:
                         <asp:RadioButtonList ID="rblSearchGender" runat="server" RepeatDirection="Horizontal">
                             <asp:ListItem Value="-1">All</asp:ListItem>
                             <asp:ListItem Value="1">Male</asp:ListItem>
                             <asp:ListItem Value="2">Female</asp:ListItem>
                         </asp:RadioButtonList>
                     </td>
                     <td>&nbsp;</td>
                    <td>Course:
                        <asp:DropDownList ID="ddlSearchCourse" runat="server">
                       </asp:DropDownList>
                    </td>

                    

       
                     <td>
                         <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                         &nbsp;&nbsp;&nbsp;
                         <asp:Button ID="btnAddNew" runat="server" OnClick="btnAddnew_Click" Text="Addnew" />
                     </td>

                    

       
          </tr>
            </table>
            
            <asp:GridView ID="gvStudentDetails" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:BoundField DataField="DOB" HeaderText="DOB" />
                    <asp:BoundField DataField="Course" HeaderText="Course" />
                    <asp:BoundField DataField="Image" HeaderText="Image" />
                    <asp:BoundField DataField="Password" HeaderText="Password" />
                    <asp:ButtonField ButtonType="Button" CausesValidation="True" CommandName="upd" Text="Edit" />
                </Columns>
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F77"/>
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>
        </asp:Panel>

        <br />
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </center>

    <script type="text/javascript">
        function showMessage(message) {
            alert(message);
        }
    </script>
</asp:Content>

