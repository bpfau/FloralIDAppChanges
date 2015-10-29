using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SQLite;
namespace FloralIDApp
{
    /// <summary>
    /// Interaction logic for Quiz.xaml
    /// </summary>
    public partial class Quiz : Window
    {
        string dbConnectionString = "Data Source=Plant.sqlite;Version=3;";
        //private SQLiteConnection dbConnectionString;
        public Quiz()
        {
            
            InitializeComponent();
            combo4.Items.Clear();
            SQLiteConnection sqlitecon = new SQLiteConnection(dbConnectionString);
            sqlitecon.Open();
            string Query = "select distinct LeafStructure from plant " ;
            //string Query = "select distinct StemStructure from plant where LeafStructur ='" + (combosql.SelectedItem as ComboBoxItem).Content.ToString() + "'";

            SQLiteCommand createComand = new SQLiteCommand(Query, sqlitecon);
            //createComand.ExecuteNonQuery();
            SQLiteDataReader read = createComand.ExecuteReader();
            while (read.Read())
            {
                //ListItem newList = new ListItem();
                combo5.Items.Add((read["LeafStructure"]));
            }
             Query = "select distinct StemStructure from plant ";
             combo6.Items.Clear();
             createComand = new SQLiteCommand(Query, sqlitecon);
             read = createComand.ExecuteReader();
            while (read.Read())
            {
                combo6.Items.Add((read["StemStructure"]));
            }
            Query = "select distinct MainFlowerColour from plant ";
            combo4.Items.Clear();
            createComand = new SQLiteCommand(Query, sqlitecon);
            read = createComand.ExecuteReader();
            while (read.Read())
            {
                combo4.Items.Add((read["MainFlowerColour"]));
            }
            sqlitecon.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqlitecon = new SQLiteConnection(dbConnectionString);
            sqlitecon.Open();
            string Query = "select PlantName from plant where MainFlowerColour = '" + combo4.Text + "'"; 
            //string Query = "select distinct StemStructure from plant where LeafStructur ='" + (combosql.SelectedItem as ComboBoxItem).Content.ToString() + "'";

            SQLiteCommand createComand = new SQLiteCommand(Query, sqlitecon);
            //createComand.ExecuteNonQuery();
            SQLiteDataReader read = createComand.ExecuteReader();
            while (read.Read())
            {
                if (textbox1.Text.ToString() == read["PlantName"].ToString())
                    label1.Content = "Your Answer is Correct";  
            }
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {


        }
        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            //combo5.Items.Clear();
            //SQLiteConnection sqlitecon = new SQLiteConnection(dbConnectionString);
            //sqlitecon.Open();
            //string Query = "select distinct StemStructure from plant where MainFlowerColour ='" + (combo4.SelectedItem as ComboBoxItem).Content.ToString() + "'";// and" + " LeafStructur ='Oval-shaped'";
            //;
            ////string Query = "select distinct StemStructure from plant where LeafStructur ='" + (combosql.SelectedItem as ComboBoxItem).Content.ToString() + "'";

            //SQLiteCommand createComand = new SQLiteCommand(Query, sqlitecon);
            ////createComand.ExecuteNonQuery();
            //SQLiteDataReader read = createComand.ExecuteReader();
            //while (read.Read())
            //{
            //    //ListItem newList = new ListItem();
            //    combo5.Items.Add((read["StemStructure"]));
            //}
            //sqlitecon.Close();
        }
    }
}
