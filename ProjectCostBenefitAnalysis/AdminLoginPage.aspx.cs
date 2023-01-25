using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace ProjectCostBenefitAnalysis
{
    public partial class AdminLoginPage : System.Web.UI.Page
    {
        ProjectCostBenefitAnalysisEntities db = new ProjectCostBenefitAnalysisEntities();
        public void Login()
        {
            try
            {
                int adminId = db.AdminUsers.Where(i => i.AdminUsername == Txt_UserName.Text).Select(i => i.AdminId).SingleOrDefault();
                bool verified = BCrypt.Net.BCrypt.Verify(Txt_Password.Text, db.AdminUsers.Where(i => i.AdminId == adminId).Select(i => i.AdminPassword).SingleOrDefault());
                var validation = db.AdminUsers.FirstOrDefault(x => x.AdminUsername == Txt_UserName.Text);
                if (validation != null && verified == true)
                {
                    Response.Redirect("AdminPanel.aspx?AdminId="+adminId);
                }
                else { Label1.Text = "Login Failed"; }
            }
            catch { Label1.Text = "User Not Found"; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Btn_AdminLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
    }
}