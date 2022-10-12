using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
using System.Windows.Shapes;
using RecordPeriphelTechniс.Connection;

namespace RecordPeriphelTechniс.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditTech.xaml
    /// </summary>
    public partial class EditTech : Window
    {
        string idi;
        public EditTech(DataRowView drv)
        {
            InitializeComponent();
            CombBoxDowmload();

            CombTypeTech.Text = drv["NameType"].ToString();
            CombIDOrgamniz.Text = drv["NameOrg"].ToString();
            TextIDKabuneta.Text = drv["Kabunet"].ToString();
            TextNumber.Text = drv["NameYstr"].ToString(); 
            TextDataStart.Text = drv["StartWork"].ToString();
            TextDataEnd.Text = drv["EndWork"].ToString();
            CombIDStatus.Text = drv["NamaStatus"].ToString();
            CombIDWorks.Text = drv["NameWorks"].ToString();
            TextComments.Text = drv["Comments"].ToString();




            TextProccModel.Text = drv["NameProcces"].ToString();
            TextSpeed.Text = drv["SpeedProcces"].ToString();
            CombProccMaker.Text = drv["MakerProcc"].ToString();
            TextMatePlatModel.Text = drv["ModelMatePlat"].ToString();
            CombMatePlatMaker.Text = drv["MakerMaterPlat"].ToString();

            TextRAMModel1.Text = drv["Model1"].ToString();
            TextVmemory1.Text = drv["V1"].ToString();
            TextTypeMemory1.Text = drv["TypeMemory1"].ToString();
            TextMaker1.Text = drv["Maker1"].ToString();

            TextRAMModel2.Text = drv["Model2"].ToString();
            TextVmemory2.Text = drv["V2"].ToString();
            TextTypeMemory2.Text = drv["TypeMemory2"].ToString();
            TextMaker2.Text = drv["Maker2"].ToString();

            TextRAMModel3.Text = drv["Model3"].ToString();
            TextVmemory3.Text = drv["V3"].ToString();
            TextTypeMemory3.Text = drv["TypeMemory3"].ToString();
            TextMaker3.Text = drv["Maker3"].ToString();

            TextRAMModel4.Text = drv["Model4"].ToString();
            TextVmemory4.Text = drv["V4"].ToString();
            TextTypeMemory4.Text = drv["TypeMemory4"].ToString();
            TextMaker4.Text = drv["Maker4"].ToString();

            TextVideoModel.Text = drv["ModeVideos"].ToString();
            TextVideoMemory.Text = drv["VVideoMemory"].ToString();
            Combmaker.Text = drv["MakerVideoCard"].ToString();




           idi = drv["Components"].ToString();
        }
        public void CombBoxDowmload()  //Данные для комбобоксов 
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            {
                try
                {
                    connection.Open();
                    string query1 = $@"SELECT * FROM TypeTechs"; // 
                    string query2 = $@"SELECT * FROM Organiz"; // 
                   // string query3 = $@"SELECT * FROM Kabunets"; // 
                    string query4 = $@"SELECT * FROM Status"; // 
                    string query5 = $@"SELECT * FROM Works"; // 
                    string query6 = $@"SELECT * FROM MakersProcc"; // 
                    string query7 = $@"SELECT * FROM MakersMaterPlat"; // 
                    string query8 = $@"SELECT * FROM MakersVideoCard"; // 


                    //----------------------------------------------
                    SQLiteCommand cmd1 = new SQLiteCommand(query1, connection);
                    SQLiteCommand cmd2 = new SQLiteCommand(query2, connection);
                    //SQLiteCommand cmd3 = new SQLiteCommand(query3, connection);
                    SQLiteCommand cmd4 = new SQLiteCommand(query4, connection);
                    SQLiteCommand cmd5 = new SQLiteCommand(query5, connection);
                    SQLiteCommand cmd6 = new SQLiteCommand(query6, connection);
                    SQLiteCommand cmd7 = new SQLiteCommand(query7, connection);
                    SQLiteCommand cmd8 = new SQLiteCommand(query8, connection);

                    //----------------------------------------------
                    SQLiteDataAdapter SDA1 = new SQLiteDataAdapter(cmd1);
                    SQLiteDataAdapter SDA2 = new SQLiteDataAdapter(cmd2);
                    //SQLiteDataAdapter SDA3 = new SQLiteDataAdapter(cmd3);
                    SQLiteDataAdapter SDA4 = new SQLiteDataAdapter(cmd4);
                    SQLiteDataAdapter SDA5 = new SQLiteDataAdapter(cmd5);
                    SQLiteDataAdapter SDA6 = new SQLiteDataAdapter(cmd6);
                    SQLiteDataAdapter SDA7 = new SQLiteDataAdapter(cmd7);
                    SQLiteDataAdapter SDA8 = new SQLiteDataAdapter(cmd8);
                    //----------------------------------------------
                    DataTable dt1 = new DataTable("TypeTechs");
                    DataTable dt2 = new DataTable("Organiz");
                   // DataTable dt3 = new DataTable("NumberKabs");
                    DataTable dt4 = new DataTable("Status");
                    DataTable dt5 = new DataTable("Works");
                    DataTable dt6 = new DataTable("MakersProcc");
                    DataTable dt7 = new DataTable("MakersMaterPlat");
                    DataTable dt8 = new DataTable("MakersVideoCard");
                    //----------------------------------------------
                    SDA1.Fill(dt1);
                    SDA2.Fill(dt2);
                    //SDA3.Fill(dt3);
                    SDA4.Fill(dt4);
                    SDA5.Fill(dt5);
                    SDA6.Fill(dt6);
                    SDA7.Fill(dt7);
                    SDA8.Fill(dt8);
                    //----------------------------------------------
                    CombTypeTech.ItemsSource = dt1.DefaultView;
                    CombTypeTech.DisplayMemberPath = "NameType";
                    CombTypeTech.SelectedValuePath = "ID";
                    //----------------------------------------------
                    CombIDOrgamniz.ItemsSource = dt2.DefaultView;
                    CombIDOrgamniz.DisplayMemberPath = "NameOrg";
                    CombIDOrgamniz.SelectedValuePath = "ID";
                    //----------------------------------------------
                    //----------------------------------------------
                    CombIDStatus.ItemsSource = dt4.DefaultView;
                    CombIDStatus.DisplayMemberPath = "NamaStatus";
                    CombIDStatus.SelectedValuePath = "ID";
                    //----------------------------------------------
                    CombIDWorks.ItemsSource = dt5.DefaultView;
                    CombIDWorks.DisplayMemberPath = "NameWorks";
                    CombIDWorks.SelectedValuePath = "ID";
                    //----------------------------------------------
                    CombIDWorks.ItemsSource = dt6.DefaultView;
                    CombIDWorks.DisplayMemberPath = "Model";
                    CombIDWorks.SelectedValuePath = "ID";
                    //----------------------------------------------
                    CombMatePlatMaker.ItemsSource = dt6.DefaultView;
                    CombMatePlatMaker.DisplayMemberPath = "Name";
                    CombMatePlatMaker.SelectedValuePath = "ID";
                    //----------------------------------------------
                    CombMatePlatMaker.ItemsSource = dt6.DefaultView;
                    CombMatePlatMaker.DisplayMemberPath = "Name";
                    CombMatePlatMaker.SelectedValuePath = "ID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
