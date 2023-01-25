using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCostBenefitAnalysis
{
    public partial class QuestionsPage : System.Web.UI.Page
    {
        ProjectCostBenefitAnalysisEntities db = new ProjectCostBenefitAnalysisEntities();
        public void UpdateData(int projectId)
        {
            int userId = Convert.ToInt32(Request.QueryString["userId"]);
            //int projectId = Convert.ToInt32(Request.QueryString["ProjectId"]);
            //var answers = db.Answers.Where(x => x.UserId == userId && x.ProjectId == projectId).FirstOrDefault();
            int b = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    TextBox textBox = row.FindControl("TextBox1") as TextBox;
                    string a = GridView1.Rows[b].Cells[0].Text.ToString();
                    int c = db.Questions.Where(x => x.Question == a).Select(x => x.QuestionsId).FirstOrDefault();
                    var answers = db.Answers.Where(x => x.UserId == userId && x.ProjectId == projectId && x.QuestionsId == c).FirstOrDefault();
                    TextBox tb = GridView1.Rows[b].Cells[1].FindControl("TextBox1") as TextBox;
                    answers.Answer = tb.Text;
                    db.SaveChanges();
                    b++;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["OldProjectId"] != null)
            {
                int userId = Convert.ToInt32(Request.QueryString["userId"]);
                int projectId = Convert.ToInt32(Request.QueryString["OldProjectId"]);
                int b = 0;
                if (!Page.IsPostBack && db.Answers.Where(x => x.UserId == userId && x.ProjectId == projectId).FirstOrDefault() != null)
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            TextBox textBox = row.FindControl("TextBox1") as TextBox;
                            string a = GridView1.Rows[b].Cells[0].Text.ToString();
                            int c = db.Questions.Where(x => x.Question == a).Select(x => x.QuestionsId).FirstOrDefault();
                            var answers = db.Answers.Where(x => x.UserId == userId && x.ProjectId == projectId && x.QuestionsId == c).FirstOrDefault();
                            TextBox tb = GridView1.Rows[b].Cells[1].FindControl("TextBox1") as TextBox;
                            tb.Text = answers.Answer;
                            db.SaveChanges();
                            b++;
                        }
                    }
                    Btn_QuestionsNextPage.Enabled = true;
                    Btn_SubmitAnswers.Visible = false;
                    Btn_UpdateAnswers.Visible = true;
                }
            }
            else
            {
                int userId = Convert.ToInt32(Request.QueryString["userId"]);
                int projectId = Convert.ToInt32(Request.QueryString["ProjectId"]);
                int b = 0;
                if (!Page.IsPostBack && db.Answers.Where(x => x.UserId == userId && x.ProjectId == projectId).FirstOrDefault() != null)
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            TextBox textBox = row.FindControl("TextBox1") as TextBox;
                            string a = GridView1.Rows[b].Cells[0].Text.ToString();
                            int c = db.Questions.Where(x => x.Question == a).Select(x => x.QuestionsId).FirstOrDefault();
                            var answers = db.Answers.Where(x => x.UserId == userId && x.ProjectId == projectId && x.QuestionsId == c).FirstOrDefault();
                            TextBox tb = GridView1.Rows[b].Cells[1].FindControl("TextBox1") as TextBox;
                            tb.Text = answers.Answer;
                            db.SaveChanges();
                            b++;
                        }
                    }
                    Btn_QuestionsNextPage.Enabled = true;
                    Btn_SubmitAnswers.Visible = false;
                    Btn_UpdateAnswers.Visible = true;
                }
            }

        }

        protected void Btn_QuestionsNextPage_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["OldProjectId"] != null)
            {
                Response.Redirect("CostProfilePage.aspx?userId=" + Request.QueryString["userId"] + "&OldProjectId=" + Request.QueryString["OldProjectId"]);
            }
            else
            {
                Response.Redirect("CostProfilePage.aspx?userId=" + Request.QueryString["userId"] + "&ProjectId=" + Request.QueryString["ProjectId"]);
            }
        }

        protected void Btn_SubmitAnswers_Click1(object sender, EventArgs e)
        {
            int b = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    TextBox textBox = row.FindControl("TextBox1") as TextBox;
                    Answers send = new Answers();
                    send.Answer = textBox.Text;
                    string a = GridView1.Rows[b].Cells[0].Text.ToString();
                    send.QuestionsId = db.Questions.Where(x => x.Question == a).Select(x => x.QuestionsId).FirstOrDefault();
                    send.UserId = Convert.ToInt32(Request.QueryString["userId"]);
                    send.ProjectId = Convert.ToInt32(Request.QueryString["ProjectId"]);
                    db.Answers.Add(send);
                    db.SaveChanges();
                    b++;
                }
            }
            Btn_QuestionsNextPage.Enabled = true;
            Btn_SubmitAnswers.Visible = false;
            Btn_UpdateAnswers.Visible = true;
        }

        protected void Btn_QuestionsPreviousPage_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["OldProjectId"] != null)
            {
                Response.Redirect("ProjectDetailPage.aspx?userId=" + Request.QueryString["userId"] + "&OldProjectId=" + Request.QueryString["OldProjectId"]);
            }
            else
            {
                Response.Redirect("ProjectDetailPage.aspx?userId=" + Request.QueryString["userId"] + "&ProjectId=" + Request.QueryString["ProjectId"]);
            }
        }

        protected void Btn_UpdateAnswers_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["OldProjectId"] != null)
            {
                UpdateData(Convert.ToInt32(Request.QueryString["OldProjectId"]));
                string funcCall = "<script language='javascript'>funcUpdate();</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "JSScript", funcCall);
            }
            else
            {
                UpdateData(Convert.ToInt32(Request.QueryString["ProjectId"]));
                string funcCall = "<script language='javascript'>funcUpdate();</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "JSScript", funcCall);
            }
        }
    }
}