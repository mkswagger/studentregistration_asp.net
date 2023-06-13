<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebApplication2.WebForm2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <center><h1>Register Page</h1>
    <br />
    <table>
        <tr>
            <td>
               Name
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Autocomplete="off" PlaceHolder="Name"></asp:TextBox>
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
                <asp:TextBox ID="txtMobile" runat="server" MaxLength="10" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            
               <td>&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="rfMobile" runat="server" ErrorMessage="Please enter your Mobile no"  Font-Size="Small" ForeColor="Red" ControlToValidate ="txtMobile"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblMobile" runat="server" Font-Size="Small" Text="Label" Visible="false" ></asp:Label>
            </td>
         
        </tr>
        <tr>
            <td>
                Email
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            
               <td>&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Please enter your Email id"  Font-Size="Small" ForeColor="Red" ControlToValidate ="txtEmail"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblEmail" runat="server" Font-Size="Small" Text="Label" Visible="false" ></asp:Label>
            </td>
         
        </tr>
        <tr>
            <td>&nbsp;</td>
      
            <td>
                DOB
            </td>
            <td>
                 <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" />
            </td>
        </tr>
        <tr>
            
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
     
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Not Registered Yet?&nbsp&nbsp;<a href="#">Click Here</a> to Register</td>
        </tr>
    </table>
    </center>
    </form>


</body>
</html>
