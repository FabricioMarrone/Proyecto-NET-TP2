using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.UserControls
{
    public partial class LabelText : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string TextoDelLabel
        {
            get { return this.Label.Text; }
            set { this.Label.Text = value; }
        }

        public string TextoDelTextBox
        {
            get { return this.TextBox.Text; }
            set { this.TextBox.Text = value; }
        }

        public TextBox GetTextBox 
        {
            get { return this.TextBox; }
        }


    }
}