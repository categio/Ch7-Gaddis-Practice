using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Test_Average
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Average method: accepts int array arg and returns the avg
        //of vals in the array.
        private double Average(int[] iArray)
        {
            //accumulator initialized to 0
            int total = 0;

            //to hold the average value calcualted
            double average;

            //step through the array adding each element to the 
            //accumulator variable
            // for each index in the iArray, that is less than the 
            //  array  total length, move up one.
            for (int index = 0; index < iArray.Length; index++)
            {
                //add each item in the array at each index to the total value
                total += iArray[index];
            }
            //calculate the average
            // double times total divided by the array's length
            average = (double)total/iArray.Length;

            //return the average of the numbers in the array
            return average;
        }

        //Highest method: accepts int array arg and returns highest
        //val in that array.
        private int Highest(int[] iArray)
        {
            //variable to hold highest val initialized with the val
            //and index 0
            int highest = iArray[0];

            //iterate over the array begining at element 1 (index 1)
            //when a val greater than highest is found assign val 
            //to the highest variable
            // for each index in the iArray, that is less than the 
            //  array  total length, move up one. 
            for (int index = 1; index < iArray.Length; index++)
            {
                //if the item that we are examining is higher than the highest 
                // current item val in the index... then "highest" variable 
                // accepts that value
                if (iArray[index] > highest)
                {
                    highest = iArray[index];
                }
            }
            return highest;
        }

        //Lowest method: accepts an int array argument and returns
        //lowest val in array
        private int Lowest(int[] iArray)
        {
            //variable to hold lowest val initialized with the val at 
            // index 0.
            int lowest = iArray[0];

            //iterate over the array beginning at element 1 (index 1)
            //when val less than lowest is found, assign that val to
            //the lowest variable
            // for each index in the iArray, that is less than the 
            //  array  total length, move up one. 
            for (int index = 1; index < iArray.Length; index++)
            {
                //if the item that we are examining is less than the lowest 
                // current item in the index... then "lowest" variable 
                // accepts that value
                if (iArray[index] < lowest)
                {
                    lowest = iArray[index];
                }
            }
            //return lowest value
            return lowest;
        }

        private void ClearAllData()
        {
            //clear out all the data from lables and the list box
            testScoresListBox.Items.Clear();
            highScoreLabel.Text = "";
            lowScoreLabel.Text = "";
            averageScoreLabel.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                //wipe data before getting averages
                ClearAllData();

                //num of tests
                const int SIZE = 5;

                //array of test scores
                int[] scores = new int[SIZE];

                //counter for loops
                int index = 0;

                //holds highest score
                int highestScore;

                //holds lowest score
                int lowestScore;

                //holds average score
                double averageScore;

                //file input var
                StreamReader inputFile;

                //open file and make StreamReader obj
                inputFile = File.OpenText("TestScores.txt");

                //read test scores and transfer into scores array
                // if the inputFile text is not all read and the index counter is less than
                // the length of the scores array.
                while (!inputFile.EndOfStream && index < scores.Length)
                {
                    //If statement here would be good to check values of the inputFile and
                    // ensure they are numerical and not text.

                    //parse text from TestScores.txt file as an int
                    // and add to array "scores"
                    scores[index] = int.Parse(inputFile.ReadLine());

                    //move up in the index of the array
                    index++;
                }
                //close the imported text file when complete
                inputFile.Close();

                //display the test scores
                // for every value in the scores array
                foreach (int val in scores)
                {
                    //add every value to the listbox on the form
                    testScoresListBox.Items.Add(val);
                }

                //get highest lowest and average score vals
                // get highest score val
                highestScore = Highest(scores);

                // get lowest score val
                lowestScore = Lowest(scores);

                // get avg score val
                averageScore = Average(scores);

                //display values 
                // display the highest score
                highScoreLabel.Text = highestScore.ToString();

                // display the lowest score
                lowScoreLabel.Text = lowestScore.ToString();

                // display the average
                averageScoreLabel.Text = averageScore.ToString("n1");
            }
            catch (Exception ex)
            {
                //display error
                MessageBox.Show(ex.Message);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            //call clear data method to wipe data clean
            ClearAllData();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //close the form
            this.Close();
        }

    }
}
