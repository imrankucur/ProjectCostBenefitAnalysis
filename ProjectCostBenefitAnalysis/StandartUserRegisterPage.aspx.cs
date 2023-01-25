using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCostBenefitAnalysis
{
    public partial class StandartUserRegisterPage : System.Web.UI.Page
    {
        ProjectCostBenefitAnalysisEntities database = new ProjectCostBenefitAnalysisEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_StandartRegister_Click(object sender, EventArgs e)
        {
            StandartUsers sendhash = new StandartUsers();
            sendhash.StandartUserUsername = Txt_RegisterStandartUsername.Text;
            sendhash.StandartUserPassword = Utilities.EncryptPassword(Txt_RegisterStandartPassword.Text);
            database.StandartUsers.Add(sendhash);
            database.SaveChanges();
        }

        protected void Btn_LogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("StandartUserLoginPage.aspx");
        }
    }
}