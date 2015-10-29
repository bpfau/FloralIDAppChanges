using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
namespace FloralIDApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {string dbConnectionString = "Data Source=Plant.sqlite;Version=3;";
        public MainWindow()
        {
           // InitializeComponent();
           // MainWindow1 a = new MainWindow1();
           // a.ShowDialog();
        }
        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            

        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (combo1.Text == "Red")
            {


                myImage.Source = new BitmapImage(new Uri("Images/a.jpg", UriKind.Relative));
                wimage.Source = new BitmapImage(new Uri("Images/world_map.png", UriKind.Relative));


                label1.Visibility = Visibility.Visible;
                label1.Content =   "The plant name is Japanese Rose\n"+
                                    "Common Name: Japanese\n"+
                                    "Type: Deciduous shrub\n"+
                                    "Family: Rosaceae\n"+
                                    "Native Range: EasternRussia, Korea,Japan,northChina\n"+
                                    "Zone: 2 to 7\n"+
                                    "Height: 4.00 to 6.00 feet\n"+
                                    "Spread: 4.00 to 6.00 feet\n"+
                                    "Bloom Time: May to July\n"+
                                    "Bloom Description: Rose pink to white\n"+
                                    "Sun: Full sun\n"+
                                    "Water: Medium\n"+
                                    "Maintenance: Medium\n"+
                                    "Suggested Use: Hedge, Naturalize\n"+
                                    "Flower: Showy, Fragrant\n"+
                                    "Attracts: Birds, Butterflies\n"+
                                    "Fruit: Showy, Edible"+
                                    "Tolerate: Clay Soil\n"+
                                    "Invasive: Where is this species invasive in the US?\n"+
                                    "Garden locations\n";




            }
            else if (combo1.Text == "Purple") {
                label1.Content = "The plant name is Gumphrina";
                myImage.Source = new BitmapImage(new Uri("Images/achimenes.jpg", UriKind.Relative));
                wimage.Source = new BitmapImage(new Uri("Images/world_map.png", UriKind.Relative));
            }
            else if (combo1.Text == "Orange") {
                label1.Content = "The plant name is Gerbera";
                myImage.Source = new BitmapImage(new Uri("Images/Orange_Daisy.jpg", UriKind.Relative));
                wimage.Source = new BitmapImage(new Uri("Images/world_map.png", UriKind.Relative));
            }
            else if (combo1.Text == "Yellowb") {
                label1.Content = "The plant name is SunFlower";
                myImage.Source = new BitmapImage(new Uri("Images/sunflower.jpg", UriKind.Relative));
                wimage.Source = new BitmapImage(new Uri("Images/world_map.png", UriKind.Relative));
            }
            else if (combo1.Text == "Green") {
                label1.Content = "The plant name is Ceterala";
                myImage.Source = new BitmapImage(new Uri("Images/green.jpg", UriKind.Relative));
                wimage.Source = new BitmapImage(new Uri("Images/world_map.png", UriKind.Relative));
            }
            else 
                label1.Content = "Depending on our Database Record We are unable find your search\n"+
                    "Please modify your feature and search again";
        }

        private void combosql_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

       

       
    


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Label1.Content = combosql.Text;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            test q = new test();
            q.ShowDialog();
        }

        private void combosql_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void combo1_DropDownClosed(object sender, EventArgs e)
        {
            combosql.Items.Clear();
            SQLiteConnection sqlitecon = new SQLiteConnection(dbConnectionString);
            sqlitecon.Open();
            string Query = "select distinct LeafStructure from plant where MainFlowerColor ='" + combo1.Text + "'";
            //Label1.Content = (combo1.SelectedItem as ComboBoxItem).Content.ToString();
            SQLiteCommand createComand = new SQLiteCommand(Query, sqlitecon);
            //createComand.ExecuteNonQuery();
            SQLiteDataReader reader = createComand.ExecuteReader();
            while (reader.Read())
            {
                //ListItem newList = new ListItem();
                combosql.Items.Add((reader["LeafStructure"]));
            }
            sqlitecon.Close();
        }

        private void combosql_DropDownClosed(object sender, EventArgs e)
        {
            combosql2.Items.Clear();
            SQLiteConnection sqlitecon = new SQLiteConnection(dbConnectionString);
            sqlitecon.Open();
            string Query = "select distinct StemStructure from plant where  LeafStructure ='" + combosql.Text + "' and MainFlowerColor='" + combo1.Text + "'";
            //Label1.Content = (combosql.SelectedItem as ComboBoxItem).Content.ToString();
            Label1.Content = combosql.Text+combo1.Text;
            //string Query = "select distinct StemStructure from plant where LeafStructur ='" + (combosql.SelectedItem as ComboBoxItem).Content.ToString() + "'";

            SQLiteCommand createComand = new SQLiteCommand(Query, sqlitecon);
            //createComand.ExecuteNonQuery();
            SQLiteDataReader read = createComand.ExecuteReader();
            while (read.Read())
            {
                //ListItem newList = new ListItem();
                combosql2.Items.Add((read["StemStructure"]));
            }
            sqlitecon.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }
}
