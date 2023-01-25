using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCostBenefitAnalysis
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_UserLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("StandartUserLoginPage.aspx");
        }

        protected void Btn_AdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLoginPage.aspx");

        }
    }
}
