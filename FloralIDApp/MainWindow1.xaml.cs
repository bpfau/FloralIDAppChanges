using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

namespace FloralIDApp
{
    /// <summary>
    /// Interaction logic for MainWindow1.xaml
    /// </summary>
    public partial class MainWindow1 : Window
    {
        string dbConnectionString = "Data Source=Plant.sqlite;Version=3;";

        public MainWindow1()
        {

            InitializeComponent();
            flower.Items.Clear();
            SQLiteConnection sqlitecon = new SQLiteConnection(dbConnectionString);
            sqlitecon.Open();
            string Query = "select distinct MainFlowerColor from plant";
            SQLiteCommand createComand = new SQLiteCommand(Query, sqlitecon);
            SQLiteDataReader reader = createComand.ExecuteReader();
            while (reader.Read())
            {
                //ListItem newList = new ListItem();
                flower.Items.Add((reader["MainFlowerColor"]));
            }
            sqlitecon.Close();
        

        }

        private void flower_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void leaf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void stem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void stem_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void flower_DropDownClosed(object sender, EventArgs e)
        {
            Label1.Content = "";
            leaf.Items.Clear();
            SQLiteConnection sqlitecon = new SQLiteConnection(dbConnectionString);
            sqlitecon.Open();
            string Query = "Select distinct LeafStructure from plant where  MainFlowerColor ='" + flower.Text + "'";
            //Label1.Content = (combosql.SelectedItem as ComboBoxItem).Content.ToString();
            Label1.Content = Query;
            //string Query = "select distinct StemStructure from plant where LeafStructur ='" + (combosql.SelectedItem as ComboBoxItem).Content.ToString() + "'";

            SQLiteCommand createComand = new SQLiteCommand(Query, sqlitecon);
            //createComand.ExecuteNonQuery();
            SQLiteDataReader read = createComand.ExecuteReader();
            while (read.Read())
            {
                //ListItem newList = new ListItem();
                leaf.Items.Add((read["LeafStructure"]));
            }
            sqlitecon.Close();
        }

        private void stem_DropDownClosed(object sender, EventArgs e)
        {
            stem.Items.Clear();
            SQLiteConnection sqlitecon = new SQLiteConnection(dbConnectionString);
            sqlitecon.Open();
            string Query = "select distinct StemStructure from plant where  LeafStructure ='"+leaf.Text+"' and MainFlowerColor='"+flower.Text+"'";
            
            SQLiteCommand createComand = new SQLiteCommand(Query, sqlitecon);
            //createComand.ExecuteNonQuery();
            SQLiteDataReader read = createComand.ExecuteReader();
            while (read.Read())
            {
                //ListItem newList = new ListItem();
                stem.Items.Add((read["StemStructure"]));
            }
            sqlitecon.Close();
        }
    }
}
