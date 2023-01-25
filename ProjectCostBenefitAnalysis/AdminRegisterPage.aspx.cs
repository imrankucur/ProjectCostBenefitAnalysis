using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCostBenefitAnalysis
{
    public partial class AdminRegisterPage : System.Web.UI.Page
    {
        ProjectCostBenefitAnalysisEntities database = new ProjectCostBenefitAnalysisEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Register_Click(object sender, EventArgs e)
        {
            AdminUsers sendhash = new AdminUsers();
            sendhash.AdminUsername = Txt_RegisterUsername.Text;
            sendhash.AdminPassword = Utilities.EncryptPassword(Txt_RegisterPassword.Text);
            database.AdminUsers.Add(sendhash);
            database.SaveChanges();
        }
    }
}