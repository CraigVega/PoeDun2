using System.Security.Cryptography.X509Certificates;

namespace PoeDun
{
    public partial class Form1 : Form
    {


        private GameEngine gameEngine;

        public Form1()
        {
            InitializeComponent();

            int iNum = 10;
            gameEngine = new GameEngine(iNum);
            UpdateDisplay();
        }

        public void UpdateDisplay()
        {

            lblDisplay.Text = gameEngine.ToString();
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {
            
        }
    }

}
