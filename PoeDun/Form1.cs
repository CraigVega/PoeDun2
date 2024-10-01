using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using static PoeDun.Level;

namespace PoeDun
{
    public partial class Form1 : Form
    {


        private GameEngine gameEngine;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            int iNum = 10;
            gameEngine = new GameEngine(iNum);
            UpdateDisplay();
           // Debug.WriteLine("Display");
        }

        public void UpdateDisplay()
        {

            lblDisplay.Text = gameEngine.ToString();
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    gameEngine.TriggerMovement(Direction.up);
                    break;

                case Keys.A:
                    gameEngine.TriggerMovement(Direction.Left);
                    break;

                case Keys.D:
                    gameEngine.TriggerMovement(Direction.Right);
                    break;

                case Keys.S:
                    gameEngine.TriggerMovement(Direction.Down);
                    break;

            }

            UpdateDisplay();
        }
    }

}
