using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCostBenefitAnalysis
{
    public partial class StandartUserLoginPage : System.Web.UI.Page
    {
        ProjectCostBenefitAnalysisEntities db = new ProjectCostBenefitAnalysisEntities();
        public void Login()
        {
            try
            {
                int standartUserId = db.StandartUsers.Where(i => i.StandartUserUsername == Txt_StandartUserUsername.Text).Select(i => i.UserId).SingleOrDefault();
                bool verified = BCrypt.Net.BCrypt.Verify(Txt_StandartUserPassword.Text, db.StandartUsers.Where(i => i.UserId == standartUserId).Select(i => i.StandartUserPassword).SingleOrDefault());
                var validation = db.StandartUsers.FirstOrDefault(x => x.StandartUserUsername == Txt_StandartUserUsername.Text);
                if (validation != null && verified == true)
                {

                    Response.Redirect("UserChoicePage.aspx?userId=" + standartUserId);
                }
                else { Label1.Text = "Login Failed"; }
            }
            catch { Label1.Text = "User Not Found"; }


        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_StandartUserLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        protected void Btn_CreateYourAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("StandartUserRegisterPage.aspx");
        }
    }
}