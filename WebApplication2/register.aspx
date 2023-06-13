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
            <td>
                DOB
            </td>
            <td>
                 <asp:TextBox ID="Calender" runat="server" Placeholder="DOB" ></asp:TextBox>
                 <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="Calender" />
            </td>
        </tr>
        <tr>
            <td>
                Course
            </td>
            <td>
                
               <asp:DropDownList ID="ddlCourse" runat="server">
                   <asp:ListItem Text="B Tech" Value="1"></asp:ListItem>
                   <asp:ListItem Text="BBA" Value="2"></asp:ListItem>
                   <asp:ListItem Text="MBBS" Value="3"></asp:ListItem>
        
            </asp:DropDownList>
            </td>
            
        </tr>
        <tr>
            <td>Gender</td>
            <td>
                <asp:RadioButton ID="rbOption1" runat="server" Text="Male" Checked="True"  />
           
                <asp:RadioButton ID="rbOption2" runat="server" Text="Female" />
                
            </td>
        </tr>
        <tr>
            <td>Image</td>
            <td>
                <asp:FileUpload ID="ImgUpload" runat="server" />
            </td>
        </tr>
        <tr>
            
            <td>
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
     
            </td>
            <td>
                <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset" />
     
            </td>
        </tr>
        
        
        <tr>
            <td>&nbsp;</td>
            <td>
                <br />
                To login &nbsp&nbsp;<a href="login.aspx">Click Here</a> </td>
        </tr>
    </table>
    </center>
    </form>


</body>
</html>
