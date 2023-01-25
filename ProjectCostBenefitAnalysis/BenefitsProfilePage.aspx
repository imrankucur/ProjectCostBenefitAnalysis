<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BenefitsProfilePage.aspx.cs" Inherits="ProjectCostBenefitAnalysis.BenefitsProfilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cost Profile</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="js/main.js"></script>
    <link href="MyStyleSheet.css" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" />
    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />
    <script src="js/bootstrap.min.js"></script>
    <link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
    <link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
    <link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
    <link rel="stylesheet" type="text/css" href="css/util.css">
    <link rel="stylesheet" type="text/css" href="css/main.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <link href="Content/toastr.css" rel="stylesheet" />
    <script src="Scripts/toastr.min.js"></script>
    <meta name="robots" content="noindex, follow">
    <script nonce="d5411c3d-c2ea-4c28-8144-8f7d646b453d">(function (w, d) { !function (a, e, t, r) { a.zarazData = a.zarazData || {}, a.zarazData.executed = [], a.zaraz = { deferred: [] }, a.zaraz.q = [], a.zaraz._f = function (e) { return function () { var t = Array.prototype.slice.call(arguments); a.zaraz.q.push({ m: e, a: t }) } }; for (const e of ["track", "set", "ecommerce", "debug"]) a.zaraz[e] = a.zaraz._f(e); a.zaraz.init = () => { var t = e.getElementsByTagName(r)[0], z = e.createElement(r), n = e.getElementsByTagName("title")[0]; for (n && (a.zarazData.t = e.getElementsByTagName("title")[0].text), a.zarazData.x = Math.random(), a.zarazData.w = a.screen.width, a.zarazData.h = a.screen.height, a.zarazData.j = a.innerHeight, a.zarazData.e = a.innerWidth, a.zarazData.l = a.location.href, a.zarazData.r = e.referrer, a.zarazData.k = a.screen.colorDepth, a.zarazData.n = e.characterSet, a.zarazData.o = (new Date).getTimezoneOffset(), a.zarazData.q = []; a.zaraz.q.length;) { const e = a.zaraz.q.shift(); a.zarazData.q.push(e) } z.defer = !0; for (const e of [localStorage, sessionStorage]) Object.keys(e || {}).filter((a => a.startsWith("_zaraz_"))).forEach((t => { try { a.zarazData["z_" + t.slice(7)] = JSON.parse(e.getItem(t)) } catch { a.zarazData["z_" + t.slice(7)] = e.getItem(t) } })); z.referrerPolicy = "origin", z.src = "/cdn-cgi/zaraz/s.js?z=" + btoa(encodeURIComponent(JSON.stringify(a.zarazData))), t.parentNode.insertBefore(z, t) }, ["complete", "interactive"].includes(e.readyState) ? zaraz.init() : a.addEventListener("DOMContentLoaded", zaraz.init) }(w, d, 0, "script"); })(window, document);</script>
    <script type="text/javascript">
        function funcUpdate() {

            toastr.success('Successfully Updated...', { timeOut: 700 }).css({ "width": "400px", "height": "55px", "top": "47px" });

            return false;


        }
        function funcSubmit() {

            toastr.success('Successfully Submitted...', { timeOut: 700 }).css({ "width": "400px", "height": "55px", "top": "47px" });

            return false;

        }
    </script>
</head>
<body>
    <div class="limiter">
        <div class="container-login100" style="min-height: 970px; height: auto">
            <div class="row" style="width: 1000px; height: 50px">
                <div class="MyWrap2" style="width: 1000px; height: 50px">
                    <asp:Label Text="BENEFITS PROFILE" Style="font-weight: bold; font-size: xx-large; font-family: Montserrat-Bold; display: block; text-align: center;"
                        runat="server" />
                </div>
            </div>
            <div class="MyWrap" style="width: 1650px; min-height:500px; display: inline-block; height: auto">
                <form class="login100-form validate-form" runat="server" style="width: 650px;">
                    <nav class="navbar navbar-expand-lg bg-light" style="width: 1620px">
                        <div class="container-fluid">
                            <div class="row" style="width: 1620px">
                                <div class="col-md-4">
                                    <img src="https://logos-download.com/wp-content/uploads/2016/06/Socar_logo.png" height="50" width="150" alt="Alternate Text" />
                                    
                                </div>
                                <div class="col-md-4">
                                </div>
                                <div class="col-md-4" style="padding-top: 5px">
                                    <asp:Button ID="Btn_BenefitsProfileNextPage" runat="server" Text="HOMEPAGE" Enabled="True" Style="float: right" class="login100-form-btn" Height="35" Width="150" OnClick="Btn_BenefitsProfileNextPage_Click"/>
                                    <asp:Button ID="Btn_BenefitsProfilePreviousPage" runat="server" Text="Previous Page" Style="float: right" class="login100-form-btn" Height="35" Width="150" OnClick="Btn_BenefitsProfilePreviousPage_Click"/>
                                </div>
                            </div>
                        </div>
                    </nav>
                    <div class="row" style="padding-left: 30px; padding-top: 70px; width: 1250px">
                        <div class="col-md-6" style="float:right">
                            <div class="col-md-11" style="width:610px;height:150px">
                            <asp:Label ID="Lbl_ProposedProduct" runat="server" Text="" Style="font-weight: bold;"></asp:Label><br />
                                <br />
                            <asp:Label ID="Lbl_DateConducted" runat="server" Text="" Style="font-weight: bold;"></asp:Label><br />
                                <br />
                            <asp:Label ID="Lbl_CompletedBy" runat="server" Text="" Style="font-weight: bold;"></asp:Label><br />
                            <br />
                           </div>
                            
                            <asp:Label ID="Lbl_Year1" runat="server" Text="2022:" Visible="False"></asp:Label>
                            <asp:TextBox ID="Txt_Year1" runat="server" CssClass="MyTextbox" Visible="False" Style="width:220px"></asp:TextBox>
                            <asp:Label ID="Lbl_Year2" runat="server" Text="2023:" Visible="False"></asp:Label>
                            <asp:TextBox ID="Txt_Year2" runat="server" CssClass="MyTextbox" Style="width:220px" Visible="False"></asp:TextBox>
                             <asp:Label ID="Lbl_Year3" runat="server" Text="2024:" Visible="False" Style="display: inline-block;width:220px"></asp:Label>
                            <asp:TextBox ID="Txt_Year3" runat="server" CssClass="MyTextbox" Style="width:220px" Visible="False"></asp:TextBox>
                            <asp:Label ID="Lbl_Year4" runat="server" Text="2025:" Visible="False" Style="display: inline-block;width:220px"></asp:Label>
                            <asp:TextBox ID="Txt_Year4" runat="server" CssClass="MyTextbox" Style="width:220px" Visible="False"></asp:TextBox>
                            <asp:Label ID="Lbl_Year5" runat="server" Text="2026:" Visible="False"></asp:Label>
                            <asp:TextBox ID="Txt_Year5" runat="server" CssClass="MyTextbox" Style="width:220px" Visible="False"></asp:TextBox>
                            
                        </div>
                        <div class="col-md-6">
                            <div class="col-md-6" style="width:610px;height:150px">
                            <asp:Label ID="Lbl_BenefitsCategory" runat="server" Text="Benefits Category:"></asp:Label>
                            <asp:DropDownList ID="Ddl_BenefitsCategory" style="width:400px" runat="server" CssClass="MyTextbox" AutoPostBack="True" DataTextField="BenefitsCategoryName" DataValueField="BenefitsCategoryId" OnSelectedIndexChanged="Ddl_BenefitsCategory_SelectedIndexChanged">
                            </asp:DropDownList>             
                            <br />
                               </div>
                            
                            
                            <asp:Label ID="Lbl_Year6" runat="server" Text="2027:"  Visible="False"></asp:Label>
                            <asp:TextBox ID="Txt_Year6" runat="server" CssClass="MyTextbox" Style="width:220px" Visible="False"></asp:TextBox>
                             <asp:Label ID="Lbl_Year7" runat="server" Text="2028:" Visible="False"></asp:Label>
                            <asp:TextBox ID="Txt_Year7" runat="server" CssClass="MyTextbox" Style="width:220px" Visible="False"></asp:TextBox>
                             <asp:Label ID="Lbl_Year8" runat="server" Text="2029:" Visible="False"></asp:Label>
                            <asp:TextBox ID="Txt_Year8" runat="server" CssClass="MyTextbox" Style="width:220px" Visible="False"></asp:TextBox>
                            <asp:Label ID="Lbl_Year9" runat="server" Text="2030:" Visible="False"></asp:Label>
                            <asp:TextBox ID="Txt_Year9" runat="server" CssClass="MyTextbox" Style="width:220px" Visible="False"></asp:TextBox>
                            <asp:Label ID="Lbl_Year10" runat="server" Text="2031:" Visible="False"></asp:Label>
                            <asp:TextBox ID="Txt_Year10" runat="server" CssClass="MyTextbox" Style="width:220px" Visible="False"></asp:TextBox>

                        </div>
                       
                        
                    </div>
                    <div class="row" style="padding-left: 30px; padding-top: 70px">
                        <div class="col-md-6">
                            <asp:Button ID="Btn_BenefitsProfileSubmit" runat="server" Text="Add New"  Width="300px" class="login100-form-btn" OnClick="Btn_BenefitsProfileSubmit_Click" />
                            <asp:Button ID="Btn_BenefitsProfileUpdate" runat="server" Text="Update"  Width="300px" class="login100-form-btn" Visible="False" OnClick="Btn_BenefitsProfileUpdate_Click"/><br />
                            <asp:GridView ID="GridView1" Style="margin: 0px" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" DataKeyNames="BenefitsProfileId" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:CommandField SelectText="Click to Update" ShowSelectButton="True" ButtonType="Button"/>
                                    <asp:BoundField DataField="BenefitsProfileId" HeaderText="BenefitsProfileId" InsertVisible="False" ReadOnly="True" SortExpression="BenefitsProfileId" />
                                    <asp:BoundField DataField="ProposedProduct" HeaderText="ProposedProduct" SortExpression="ProposedProduct" />
                                    <asp:BoundField DataField="DateConducted" HeaderText="DateConducted" SortExpression="DateConducted" />
                                    <asp:BoundField DataField="CompletedBy" HeaderText="CompletedBy" SortExpression="CompletedBy" />
                                    <asp:BoundField DataField="BenefitsCategoryId" HeaderText="BenefitsCategoryId" SortExpression="BenefitsCategoryId" />
                                    <asp:BoundField DataField="Year1" HeaderText="Year1" SortExpression="Year1" />
                                    <asp:BoundField DataField="Year2" HeaderText="Year2" SortExpression="Year2" />
                                    <asp:BoundField DataField="Year3" HeaderText="Year3" SortExpression="Year3" />
                                    <asp:BoundField DataField="Year4" HeaderText="Year4" SortExpression="Year4" />
                                    <asp:BoundField DataField="Year5" HeaderText="Year5" SortExpression="Year5" />
                                    <asp:BoundField DataField="Year6" HeaderText="Year6" SortExpression="Year6" />
                                    <asp:BoundField DataField="Year7" HeaderText="Year7" SortExpression="Year7" />
                                    <asp:BoundField DataField="Year8" HeaderText="Year8" SortExpression="Year8" />
                                    <asp:BoundField DataField="Year9" HeaderText="Year9" SortExpression="Year9" />
                                    <asp:BoundField DataField="Year10" HeaderText="Year10" SortExpression="Year10" />
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" Height="30px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" Height="30px" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#000065" />
                            </asp:GridView>
                           
                        </div>
                        <div class="col-md-6">
                            <asp:Button ID="Btn_BenefitsProfileClear" runat="server" Text="Clear to Add New Data"  Width="300px" class="login100-form-btn" Visible="False" OnClick="Btn_BenefitsProfileClear_Click"/>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
    <script src="vendor/bootstrap/js/popper.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="vendor/select2/select2.min.js"></script>
    <script src="vendor/tilt/tilt.jquery.min.js"></script>
    <script>
        $('.js-tilt').tilt({
            scale: 1.1
        })
    </script>
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-23581568-13"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'UA-23581568-13');
    </script>
    <script src="js/main.js"></script>
    <script defer src="https://static.cloudflareinsights.com/beacon.min.js/v652eace1692a40cfa3763df669d7439c1639079717194" integrity="sha512-Gi7xpJR8tSkrpF7aordPZQlW2DLtzUlZcumS8dMQjwDHEnw9I7ZLyiOj/6tZStRBGtGgN6ceN6cMH8z7etPGlw==" data-cf-beacon='{"rayId":"7271b1ae789efcfd","token":"cd0b4b3a733644fc843ef0b185f98241","version":"2022.6.0","si":100}' crossorigin="anonymous"></script>
</body>
</html>

