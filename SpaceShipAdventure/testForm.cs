using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceshipCommander
{
    public partial class testForm : Form
    {

        FinishGate test = new FinishGate(10,10);
        FinishGate test2 = new FinishGate(400, 10);

        int angle_ = 0;

        public testForm()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {




        }

        private void testForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
           // test.Draw(g,angle_);
            test2.Draw2(g,angle_);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //test.normalgate = RotateImage(test.normalgate,angle_);

            angle_ += 4;
            if (angle_ > 360)
                angle_ = 0;
            Invalidate();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
