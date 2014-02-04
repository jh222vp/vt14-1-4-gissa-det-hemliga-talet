using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _1_4_Gissa_det_hemliga_talet.Model;

namespace _1_4_Gissa_det_hemliga_talet
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SendGuess_Click(object sender, EventArgs e)
        {
            var sec = new SecretNumber();
            int input = int.Parse(Input.Text);

            sec.MakeGuess(input);
        }
    }
}