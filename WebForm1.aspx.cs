using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonPesquisa_Click(object sender, EventArgs e)
        {
            LabelErros.Text = "";
            LabelRegistos.Text = "";
            LabelColuna.Text = "";
            LabelIP.Text = "";
            string chave = TextBoxPesquisa.Text;
            if (string.IsNullOrEmpty(chave))
            {
                LabelErros.Text = "introduza dados";
            }
            else
            {
                chave = LimpaChave(chave);
                if (chave.StartsWith("ixp")) PesquisaIXP(chave);
                else PesquisaTodos(chave);
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ClickVerFicheiro")
            {
                string ip = e.CommandArgument.ToString();
                LabelIP.Text = ip;
                EscreveConteudoFicheiro(ip);
            }
        }

        private void EscreveConteudoFicheiro(string ip)
        {
            ip = ip.Replace(".", "-");
            ip = System.IO.File.ReadAllText(@"C:\Users\webrp\Downloads\" + ip + ".txt");
            TextBox2.Text = ip;
        }

        private string LimpaChave(string chave)
        {
            chave = chave.Trim().ToLower();
            while (chave.Contains(" "))
            {
                chave = chave.Replace(" ", string.Empty);
            }
            return chave;
        }

        private void PesquisaIXP(string chave)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["teste-ptConnectionString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * from xpto where ixp like '" + chave + "%'", connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                    if (Repeater1.Items.Count > 0)
                    {
                        LabelErros.Text = Repeater1.Items.Count.ToString();
                    }
                    else LabelRegistos.Text = "Sem dados";
                    LabelColuna.Text = "IXP";
                }
                catch (Exception ex)
                {
                    LabelErros.Text = ex.Message.ToString();
                }
            }
        }

        private void PesquisaTodos(string chave)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["teste-ptConnectionString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * from xpto where ixp like '%" + chave + "%'", connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                    if (Repeater1.Items.Count > 0)
                    {
                        LabelRegistos.Text = Repeater1.Items.Count.ToString();
                    }
                    else LabelRegistos.Text = "Sem dados";
                    LabelColuna.Text = "Todas";
                }
                catch (Exception ex)
                {
                    LabelErros.Text = ex.ToString();
                }
            }
        }

    }
}