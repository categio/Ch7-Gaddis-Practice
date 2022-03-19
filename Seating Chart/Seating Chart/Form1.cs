using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Seating_Chart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ClearAllData()
        {
            txtCol.Text = "";
            txtRow.Text = "";
            priceLabel.Text = "";
        }

        private void displayPriceButton_Click(object sender, EventArgs e)
        {
            //variables 
            // to hold entered row and column
            int row, col;

            // consts for max row/col
            const int MAX_ROW = 5;
            const int MAX_COL = 3;

            // consts for row price
            const decimal row0 = 450m;
            const decimal row1 = 425m;
            const decimal row2 = 400m;
            const decimal row3n4 = 375m;
            const decimal row5 = 350m; 

            //create array obj with seat prices
            decimal[,] prices = {
                { row0, row0, row0, row0 },
                { row1, row1, row1, row1 },
                { row2, row2, row2, row2 },
                { row3n4, row3n4, row3n4, row3n4 },
                { row3n4, row3n4, row3n4, row3n4 },
                { row5, row5, row5, row5 }
                };

            //get entered row number while perfomring checks
            //   to validity
            // if the text entered is numerical, print to
            //  row variable
            if (int.TryParse(txtRow.Text, out row))
            {
                // if text entered is numerical, print to
                //  col variable
                if (int.TryParse(txtCol.Text, out col))
                {
                    // check to see if range entered is valid
                    //  for range of row/col max size.
                    if (row >= 0 && row <= MAX_ROW)
                    {
                        if (col >= 0 && col <= MAX_COL)
                        {
                            // passes all checks
                            //  show price 
                            priceLabel.Text = prices[row, col].ToString("c");
                        }
                        //error handling - invalid col number
                        else
                        {
                            //tell user entered data is wrong format
                            MessageBox.Show("Column must be 0 through " +
                                MAX_COL);
                            //clear data from col
                            txtCol.Text = "";
                        }
                    }
                    //error handling - invalid row number
                    else
                    {
                        //tell user entered data is wrong format
                        MessageBox.Show("Row must be 0 through " +
                            MAX_ROW);
                        //clear data from row
                        txtRow.Text = "";
                    }
                }
                //error handling - not numerical data in col
                else
                {
                    //tell user entered data is wrong format
                    MessageBox.Show("Column must be numerical data," + 
                        " try again.");
                    //clear data from col
                    txtCol.Text = "";
                }
            }
            //error handling - not numerical data in row
            else
            {
                //tell user entered data is wrong format
                MessageBox.Show("Row must be numerical data, try again.");
                //clear data from row
                txtRow.Text = "";
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAllData();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //close the form
            this.Close();
        }

    }
}
