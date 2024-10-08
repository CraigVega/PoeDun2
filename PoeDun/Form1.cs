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
            this.KeyDown += new KeyEventHandler(Form1_KeyDown_1);
            int iNum = 10;
            gameEngine = new GameEngine(iNum);
            UpdateDisplay();
            // Debug.WriteLine("Display");
            lblAttack.Text = "Attack Using Button or ArrowKeys";
        }

        public void UpdateDisplay()
        {

            lblDisplay.Text = gameEngine.ToString();
            lblHealth.Text = gameEngine.HealthDisplay();
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }

       

        public void CallUpdateDisplay()
        {
            UpdateDisplay();
        }

        private void AttackLeft()
        {
            gameEngine.TriggerAttack(Direction.Left);
            CallUpdateDisplay();

        }

        private void AttackUp()
        {
            //Debug.WriteLine("Attacking Up");
            gameEngine.TriggerAttack(Direction.up);
            CallUpdateDisplay();
        }

        private void AttackDown()
        {
            gameEngine.TriggerAttack(Direction.Down);
            CallUpdateDisplay();
        }

        private void AttackRight()
        {
            gameEngine.TriggerAttack(Direction.Right);
            CallUpdateDisplay();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AttackLeft();
        }

        private void btnAttackUp_Click(object sender, EventArgs e)
        {
            AttackUp();
        }

        private void btnAttackDown_Click(object sender, EventArgs e)
        {
            AttackDown();

        }

        private void btnAttackRight_Click(object sender, EventArgs e)
        {
            AttackRight();
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)//For movment
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


            CallUpdateDisplay();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) //Used to stop the arrow keys from focusing on the buttons
        {
            
            switch (keyData)
            {
                case Keys.Up:
                    AttackUp();  // Handle up arrow
                    return true; // Indicate that the key press is handled
                case Keys.Down:
                    AttackDown(); // Handle down arrow
                    return true;  // Key press handled
                case Keys.Left:
                    AttackLeft(); // Handle left arrow
                    return true;  // Key press handled
                case Keys.Right:
                    AttackRight(); // Handle right arrow
                    return true;  // Key press handled
            }
            CallUpdateDisplay();
            return base.ProcessCmdKey(ref msg, keyData);

        }
    }

}
