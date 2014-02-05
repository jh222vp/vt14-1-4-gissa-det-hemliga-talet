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
        public SecretNumber secretNumber { 
            get
            {
                return Session["SecretNumber"] as SecretNumber;
            }
            set
            {
                Session["SecretNumber"] = value;
            }
            }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SendGuess_Click(object sender, EventArgs e)
        {
            var sec = new SecretNumber();
            int input = int.Parse(Input.Text);

            sec.MakeGuess(input);

            switch (sec.MakeGuess(input))
            {
                case Outcome.Indefinite:
                    break;
                case Outcome.Low:
                    Label2.Text = "lågt";
                    Label3.Text = sec.Number.ToString();
                    break;
                case Outcome.High:
                    Label2.Text = "Högt";
                    break;
                case Outcome.Correct:
                    Label2.Text = "RÄTT!!!";
                    break;
                case Outcome.NoMoreGuesses:
                    Label2.Text = "Slut på gissningar!";
                    break;
                case Outcome.PreveiousGuess:
                    break;
                default:
                    break;
            }
        }
    }
}