using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.UserControls
{
    public partial class MyTextBoxValidate : System.Web.UI.UserControl
    {
        public string Text 
        {
            get { return this.TextBox.Text; }
            set { this.TextBox.Text = value; }
        }

        public string ErrorMessage 
        { 
            set { this.RegularExpressionValidator.ErrorMessage = value; } 
        }
        public string ValidationExpression 
        { 
            set { this.RegularExpressionValidator.ValidationExpression = value; } 
        }
        public bool Enabled 
        {
            set { this.TextBox.Enabled = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}