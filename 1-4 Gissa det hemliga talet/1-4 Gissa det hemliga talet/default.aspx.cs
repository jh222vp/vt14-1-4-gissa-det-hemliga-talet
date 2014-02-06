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
                if (Session["secretNumber"] == null)
                {
                    Session["secretNumber"] = new SecretNumber();
                }
                return Session["secretNumber"] as SecretNumber;
            }
            set
            {
                Session["secretNumber"] = value;
            }
            }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Restart_Click(object sender, EventArgs e)
        {
            //secretNumber.Initialize();
        }
        protected void SendGuess_Click(object sender, EventArgs e)
        {
            
            var input = int.Parse(Input.Text);

            switch (secretNumber.MakeGuess(input))
            {
                case Outcome.Indefinite:
                    break;
                case Outcome.Low:
                    AmountOfGuesslabel.Text = String.Format("Du har gissat {0} gånger!", secretNumber.Count.ToString());
                    GuessLabel.Text = secretNumber.Number.ToString();
                    HighOrLowLabel.Text = "Gissningen var för låg!";
                    break;
                case Outcome.High:
                    AmountOfGuesslabel.Text = String.Format("Du har gissat {0} gånger!", secretNumber.Count.ToString());
                    GuessLabel.Text = secretNumber.Number.ToString();
                    HighOrLowLabel.Text = "Gissningen var för hög!";
                    break;
                case Outcome.Correct:
                    AmountOfGuesslabel.Text = String.Format("Rätt gissat!, Talet var mycket riktigt {0}", secretNumber.Number);
                    SendGuess.Enabled = false;
                    sendHolder.Visible = false;
                    myPlaceHolder.Visible = true;
                    secretNumber.Initialize();
                    
                    break;
                case Outcome.NoMoreGuesses:
                    SendGuess.Enabled = false;
                    AmountOfGuesslabel.Text = String.Format("Slut på gissningar! Talet var: {0}", secretNumber.Number);
                    sendHolder.Visible = false;
                    myPlaceHolder.Visible = true;
                    secretNumber.Initialize();
                    
                    break;
                case Outcome.PreveiousGuess:
                    AmountOfGuesslabel.Text = String.Format("Du har redan gissat på: {0}", input);
                    break;
                default:
                    break;
            }
            GuessLabel.Text = String.Join(", ", secretNumber.PreviousGuesses);
        }
    }
}