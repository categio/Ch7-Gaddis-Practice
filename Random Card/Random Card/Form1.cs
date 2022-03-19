using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Random_Card
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getCardButton_Click(object sender, EventArgs e)
        {
            //create Random object
            Random rando = new Random();

            //get random index
            int index = rando.Next(cardImageList.Images.Count);

            //display a card
            cardPictureBox.Image = cardImageList.Images[index];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
