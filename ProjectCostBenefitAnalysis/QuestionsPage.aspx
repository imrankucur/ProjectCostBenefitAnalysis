<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestionsPage.aspx.cs" Inherits="ProjectCostBenefitAnalysis.QuestionsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Questions</title>
    <link href="MyStyleSheet.css" rel="stylesheet" />
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />
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
    <script src="Scripts/toastr.min.js"></script>
    <script src="Scripts/toastr.js"></script>
    <link href="Content/toastr.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
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
                    <asp:Label Text="QUESTIONS" Style="font-weight: bold; font-size: xx-large;  font-family: Montserrat-Bold; display: block; text-align: center;"
                        runat="server" />

                </div>
            </div>
            <div class="MyWrap" style="width: 1000px;min-height:500px; display: inline-block; height: auto">

                <form class="login100-form validate-form" runat="server" style="width: 650px;">
                    <nav class="navbar navbar-expand-lg bg-light" style="width: 970px">
                        <div class="container-fluid">
                             <div class="row" style="width: 1620px">
                                <div class="col-md-3">
                                    <img src="https://logos-download.com/wp-content/uploads/2016/06/Socar_logo.png" height="50" width="150" alt="Alternate Text" />
                                    
                                </div>
                                <div class="col-md-4">
                                </div>
                                <div class="col-md-5" style="padding-top: 5px">
                                                                     <asp:Button ID="Btn_QuestionsNextPage" runat="server" Text="Next Page" class="login100-form-btn" Enabled="False" style="float: right;height:35px;width:150px" OnClick="Btn_QuestionsNextPage_Click" />

                                   <asp:Button ID="Btn_QuestionsPreviousPage" runat="server" Text="Previous Page" class="login100-form-btn" style="float: right;height:35px;width:150px"  OnClick="Btn_QuestionsPreviousPage_Click" />

                                </div>
                            </div>
                            
                        </div>
                    </nav>
                    <div class="row" style="padding-left: 30px; padding-top: 70px; width: 970px">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableViewState="true" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="Question" HeaderText="Questions"   SortExpression="Question" />
                                <asp:TemplateField HeaderText="Answers"  >
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text="" TextMode="MultiLine" Height="100px" Width="300px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProjectCostBenefitAnalysisConnectionString %>" SelectCommand="SELECT [Question] FROM [Questions] WHERE ([QuestionState] = @QuestionState)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="1" Name="QuestionState" Type="Byte" />
                            </SelectParameters>
                        </asp:SqlDataSource>


                        <asp:Button ID="Btn_SubmitAnswers" runat="server" Text="Submıt Answers" class="login100-form-btn" Style="margin-top: 10px; width: 950px; height: 35px" OnClick="Btn_SubmitAnswers_Click1" />
                        <asp:Button ID="Btn_UpdateAnswers" runat="server" Text="Update" class="login100-form-btn" Style="margin-top: 10px; width: 950px; height: 35px" OnClick="Btn_UpdateAnswers_Click" Visible="False" />



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
