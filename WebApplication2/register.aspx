﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebApplication2.WebForm2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
       body {
            background-color: #D2E9E9;
        }

        .registration-form {
            background-color: #5C8984;
            color: #FFFFFF;
            padding: 20px;
        }

        .registration-form td:first-child {
            color: #000000; /* Black text color for field titles */
        }

        .btn-register {
            background-color: #DDFFBB; /* Gold */
            color: #000000; /* Black text color */
        }

        .btn-reset {
            background-color: #C7E9B0; /* Gray */
            color: #000000; /* White text color */
        }

        .login-link {
            color: #03001C; /* Orange */
            text-decoration: none;
        }

        .login-link:hover {
            color: #FF8C00; /* Dark orange on hover */
        }
        .horizontal-list {
            display: inline-block;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <center><h1>Register Page</h1>
    <br />
    <table class="registration-form">
        <tr>
            <td>
               Name
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Autocomplete="off" PlaceHolder="Name" ></asp:TextBox>
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtName" FilterType="LowercaseLetters" />
            </td>
       
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Please enter your name"  Font-Size="Small" ForeColor="Red" ControlToValidate ="txtName"></asp:RequiredFieldValidator>
            </td>

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
               <asp:RadioButtonList ID="rblGgender" runat="server" CssClass="horizontal-list">
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
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="btn-register" />
     
            </td>
            <td>
                <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset"  CausesValidation="False" CssClass="btn-reset" />
     
            </td>
        </tr>
        
        
        <tr>
            <td>&nbsp;</td>
            <td>
                <br />
                To login &nbsp&nbsp;<a href="login.aspx" class="login-link">Click Here</a> </td>
        </tr>
    </table>
    </center>
    </form>


</body>
</html>


