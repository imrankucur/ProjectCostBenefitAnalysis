<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminRegisterPage.aspx.cs" Inherits="ProjectCostBenefitAnalysis.AdminRegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <title>Admin Register</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div style="height: 300px; margin-top: 300px" class="mr-auto ml-auto text-center">
                    <div class="card">
                        <img class="card-img-top" src="https://upload.wikimedia.org/wikipedia/commons/thumb/2/22/Logo_of_SOCAR.svg/2560px-Logo_of_SOCAR.svg.png" alt="Card image cap" height="155" width="655">
                        <div class="card-body">
                            <asp:Label ID="Lbl_RegisterUsername" runat="server" Text="Username: " CssClass="btn-lg"></asp:Label>
                            <asp:TextBox ID="Txt_RegisterUsername" runat="server" required></asp:TextBox> <br /><br />  
                             &nbsp<asp:Label ID="Lbl_RegisterPassword" runat="server" Text="Password: " CssClass="btn-lg"></asp:Label>
                            <asp:TextBox ID="Txt_RegisterPassword" runat="server" input type="password" required></asp:TextBox> <br />
                            <asp:RequiredFieldValidator ID="Rfv_RegisterPasswword" runat="server" ErrorMessage="Please enter a password." ControlToValidate="Txt_RegisterPassword"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="Rev_RegisterPassword" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$" ControlToValidate="Txt_RegisterPassword"></asp:RegularExpressionValidator>
                            <br />
                            <asp:Button ID="Btn_Register" runat="server" Text="Register" CssClass="btn-md btn-primary" style="margin-left:15px" OnClick="Btn_Register_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
