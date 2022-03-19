using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Test_Score_List
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //ReadScores method: reads scores from the 
        // TestScores.txt file into the scoresList param
        private void ReadScores(List<int> scoresList)
        {
            try
            {
                // open the TestScores.txt doc
                StreamReader inputFile = File.OpenText("TestScores.txt");

                //read scores into the list while not at end of file
                while (!inputFile.EndOfStream)
                {
                    scoresList.Add(int.Parse(inputFile.ReadLine()));
                }
                //close file TestScores.txt
                inputFile.Close();
            }
            catch (Exception ex)
            {
                //display error message
                MessageBox.Show(ex.Message);
            }
        }

        //DisplayScores method: displays contents of 
        // the scoresList parameter in the ListBox control
        private void DisplayScores(List<int> scoresList)
        {
            foreach(int score in scoresList)
            {
                testScoresListBox.Items.Add(score);
            }
        }

        //Average method: returns the average of the values
        // in the scoresList param
        private double Average(List<int> scoresList)
        {
            //accumulator variable
            int tot = 0;
            
            //average variable
            double avg;

            //calc total of all scores
            foreach (int score in scoresList)
            {
                tot += score;
            }

            //calc avg of scores
            // avg = (change val to double) total / count of scoresList.
            avg = (double)tot / scoresList.Count;

            //return avg
            return avg;
        }

        //AboveAvg method: returns the number of above avg scores
        // in scoresList
        private int AboveAverage(List<int> scoresList)
        {
            //accumulator variable
            int numAbove = 0;

            //Get average score
            double avg = Average(scoresList);

            //count num of above avg scores
            foreach (int score in scoresList)
            {
                if (score > avg)
                {
                    numAbove++;
                }
            }
            //return avg num scores above avg.
            return numAbove;
        }

        //BelowAverage method: returns num of scores below
        //  average in the scoresList array
        private int BelowAverage(List<int> scoresList)
        {
            //accumulator variable
            int numBelow = 0;

            //get avg score
            double avg = Average(scoresList);

            //couunt num of below avg scores
            foreach (int score in scoresList)
            {
                if (score < avg)
                {
                    numBelow++;
                }
            }

            //return num of below avg scores
            return numBelow;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            //variables
            // holds avg score
            double avgScore;

            //holds num of scores above avg
            int numAboveAvg;

            //holds num of scores below avg
            int numBelowAvg;

            //array of type list to hold the scores
            List<int> scoresList = new List<int>();

            //read scores from file into list
            ReadScores(scoresList);

            //display scores to labels
            DisplayScores(scoresList);

            //display avg score
            // pulls data from Average method
            avgScore = Average(scoresList);
            // prints to Average Label
            AverageLabel.Text = avgScore.ToString("n1");

            //display # of above avg scores
            //  pulls data from AboveAverage method
            numAboveAvg = AboveAverage(scoresList);
            //prints to AboveAverage Label
            aboveAverageLabel.Text = numAboveAvg.ToString();

            //display # of below avg scores
            //  pulls data from BelowAverage method
            numBelowAvg = BelowAverage(scoresList);
            //prints to BelowAverage Label
            belowAverageLabel.Text = numBelowAvg.ToString();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //close the form
            this.Close();
        }
    }
}
