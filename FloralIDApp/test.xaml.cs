using System;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace FloralIDApp
{
    /// <summary>
    /// Interaction logic for test.xaml
    /// </summary>

  
    public partial class test : Window
    {


        string plantname = "";
        int correctanswer = 0;
        int wrongAnswer = 0;
        
        string dbConnectionString = "Data Source=Plant.sqlite;Version=3;";

        public test()
        {
            InitializeComponent();
            
        }

        private void flower_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            //leaf.Items.Add("LeafStructure");
        }

        private void leaf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //stem.Items.Clear();
            //SQLiteConnection sqlitecon = new System.Data.SQLite.SQLiteConnection(dbConnectionString);
            //sqlitecon.Open();
            //string Query = "select distinct StemStructure from plant";// where MainFlowerColour ='" + (flower.SelectedItem as ComboBoxItem).Content.ToString() + "'";
            //SQLiteCommand createComand = new SQLiteCommand(Query, sqlitecon);
            ////createComand.ExecuteNonQuery();
            //SQLiteDataReader reader = createComand.ExecuteReader();
            //while (reader.Read())
            //{
            //    //ListItem newList = new ListItem();
               
            //}
            //sqlitecon.Close();

        }

        private void stem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int x = random.Next(1, 10);
            leaf.Items.Clear();
            flower.Items.Clear();
            stem.Items.Clear();
            textbox1.Clear();
            label1.Content = x;
            
            SQLiteConnection sqlitecon = new System.Data.SQLite.SQLiteConnection(dbConnectionString);
            sqlitecon.Open();
            string Query = "select PlantName, MainFlowercolor,LeafStructure,StemStructure from plant where ID ='" + x + "'"; 
            SQLiteCommand createComand = new SQLiteCommand(Query, sqlitecon);
            //createComand.ExecuteNonQuery();
            SQLiteDataReader reader = createComand.ExecuteReader();
            while (reader.Read())
            {
                //ListItem newList = new ListItem();
                plantname = reader["PlantName"].ToString();
                flower.Items.Add(reader["MainFlowercolor"]);
                leaf.Items.Add(reader["LeafStructure"]);
                stem.Items.Add(reader["StemStructure"]);
            }
            sqlitecon.Close();
        }   
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(textbox1.Text == "")
                label1.Content = "Please Write Plant name.";

            else if (textbox1.Text == plantname)                      
            {
                label1.Content = "Good Job";
                correctanswer++;
            }
            else
            {
                label1.Content = "Bad Job";
                wrongAnswer++;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (wrongAnswer == 0 && correctanswer == 0)
                label1.Content = "you have not answer any question";
            else
            label1.Content = "your Final Score is:" + ( 100*correctanswer / (correctanswer + wrongAnswer)) + "%";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PlantNameAnswer.Content = plantname;
        }

        }

        
    
}
