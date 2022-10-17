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
        int TypeEdit;
        public EditTech(DataRowView drv, int Type)
        {

            InitializeComponent();
            CombBoxDowmload();
            TypeEdit = Type;
            CombTypeTech.Text = drv["NameType"].ToString();
            CombIDOrgamniz.Text = drv["NameOrg"].ToString();
            TextIDKabuneta.Text = drv["Kabunet"].ToString();
            TextName.Text = drv["NameYstr"].ToString();
            TextNumber.Text = drv["Number"].ToString();
            TextDataStart.Text = drv["StartWork"].ToString();
            TextDataEnd.Text = drv["EndWork"].ToString();
            CombIDStatus.Text = drv["NameStatus"].ToString();
            CombIDWorks.Text = drv["NameWorks"].ToString();
            TextComments.Text = drv["Comments"].ToString();



            if (Type == 1)
            {


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
                CombVidieoMaker.Text = drv["MakerVideoCard"].ToString();
                //idi = drv["Components"].ToString();

            }
            else

            {

                IsEnabledData();

            }





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
                    CombIDStatus.DisplayMemberPath = "NameStatus";
                    CombIDStatus.SelectedValuePath = "ID";
                    //----------------------------------------------
                    CombIDWorks.ItemsSource = dt5.DefaultView;
                    CombIDWorks.DisplayMemberPath = "NameWorks";
                    CombIDWorks.SelectedValuePath = "ID";
                    //----------------------------------------------
                    CombProccMaker.ItemsSource = dt6.DefaultView;
                    CombProccMaker.DisplayMemberPath = "Name";
                    CombProccMaker.SelectedValuePath = "ID";
                    //----------------------------------------------
                    CombMatePlatMaker.ItemsSource = dt7.DefaultView;
                    CombMatePlatMaker.DisplayMemberPath = "Name";
                    CombMatePlatMaker.SelectedValuePath = "ID";
                    //----------------------------------------------
                    CombVidieoMaker.ItemsSource = dt8.DefaultView;
                    CombVidieoMaker.DisplayMemberPath = "Name";
                    CombVidieoMaker.SelectedValuePath = "ID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void IsEnabledData()
        {

            //CombTypeTech.IsEnabled = false;
            //CombIDOrgamniz.IsEnabled = false;
            //TextIDKabuneta.IsEnabled = false;
            //TextNumber.IsEnabled = false;
            //TextDataStart.IsEnabled = false;
            //TextDataEnd.IsEnabled = false;
            //CombIDStatus.IsEnabled = false;
            //CombIDWorks.IsEnabled = false;
            //TextComments.IsEnabled = false;

            TextProccModel.IsEnabled = false;
            TextSpeed.IsEnabled = false;
            CombProccMaker.IsEnabled = false;
            TextMatePlatModel.IsEnabled = false;
            CombMatePlatMaker.IsEnabled = false;

            TextRAMModel1.IsEnabled = false;
            TextVmemory1.IsEnabled = false;
            TextTypeMemory1.IsEnabled = false;
            TextMaker1.IsEnabled = false;

            TextRAMModel2.IsEnabled = false;
            TextVmemory2.IsEnabled = false;
            TextTypeMemory2.IsEnabled = false;
            TextMaker2.IsEnabled = false;

            TextRAMModel3.IsEnabled = false; ;
            TextVmemory3.IsEnabled = false;
            TextTypeMemory3.IsEnabled = false;
            TextMaker3.IsEnabled = false;

            TextRAMModel4.IsEnabled = false;
            TextVmemory4.IsEnabled = false;
            TextTypeMemory4.IsEnabled = false;
            TextMaker4.IsEnabled = false;

            TextVideoModel.IsEnabled = false; ;
            TextVideoMemory.IsEnabled = false;
            CombVidieoMaker.IsEnabled = false;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            {
                connection.Open();
                if (String.IsNullOrEmpty(CombIDOrgamniz.Text) || String.IsNullOrEmpty(TextIDKabuneta.Text) || String.IsNullOrEmpty(TextNumber.Text) || String.IsNullOrEmpty(CombIDStatus.Text) || String.IsNullOrEmpty(TextName.Text) ||
                    String.IsNullOrEmpty(CombIDWorks.Text))
                {
                    MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    int id, id2, id3, id4, id5, id6;
                    bool resultClass = int.TryParse(CombIDOrgamniz.SelectedValue.ToString(), out id);
                    bool resultKab = int.TryParse(CombIDStatus.SelectedValue.ToString(), out id2);
                    bool resultCon = int.TryParse(CombIDWorks.SelectedValue.ToString(), out id3);
                    //bool resultTitl = int.TryParse(CombProccMaker.SelectedValue.ToString(), out id4);
                    //bool resultBrand = int.TryParse(CombMatePlatMaker.SelectedValue.ToString(), out id5);
                    //bool resultModel = int.TryParse(CombVidieoMaker.SelectedValue.ToString(), out id6);
                    string query = $@"UPDATE MenuPerTech SET IDOrganiz=@IDOrganiz, Kabunet=@Kabunet,Number=@Number,Name=@Name, Number=@Number, StartWork=@StartWork, 
                                            EndWork=@EndWork ,IDStatus=@IDStatus,IDWorks=@IDWorks,Comments=@Comments WHERE ID=@ID;";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    try
                    {
                        cmd.Parameters.AddWithValue("@ID", Saver.IDMenuPer);
                        cmd.Parameters.AddWithValue("@IDOrganiz", id);
                        cmd.Parameters.AddWithValue("@Kabunet", TextIDKabuneta.Text);
                        cmd.Parameters.AddWithValue("@Number", TextNumber.Text);
                        cmd.Parameters.AddWithValue("@Name", TextName.Text);
                        cmd.Parameters.AddWithValue("@StartWork", TextDataStart.Text);
                        cmd.Parameters.AddWithValue("@EndWork", TextDataEnd.Text);
                        cmd.Parameters.AddWithValue("@IDStatus", id2);
                        cmd.Parameters.AddWithValue("@IDWorks", id3);
                        cmd.Parameters.AddWithValue("@Comments", TextComments.Text);
                        cmd.ExecuteNonQuery();
                        // MessageBox.Show("Данные изменены");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                if (TypeEdit == 1)
                {
                    if (String.IsNullOrEmpty(TextProccModel.Text) || String.IsNullOrEmpty(TextSpeed.Text) || String.IsNullOrEmpty(CombProccMaker.Text) ||
                       String.IsNullOrEmpty(CombMatePlatMaker.Text) || String.IsNullOrEmpty(TextRAMModel1.Text) || String.IsNullOrEmpty(TextVmemory1.Text) || String.IsNullOrEmpty(TextTypeMemory1.Text) ||
                       String.IsNullOrEmpty(TextMaker1.Text) || String.IsNullOrEmpty(TextVideoModel.Text) || String.IsNullOrEmpty(TextVideoModel.Text) || String.IsNullOrEmpty(CombVidieoMaker.Text))
                    {
                        MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        int id4, id5, id6;
                        bool resultTitl = int.TryParse(CombProccMaker.SelectedValue.ToString(), out id4);
                        bool resultBrand = int.TryParse(CombMatePlatMaker.SelectedValue.ToString(), out id5);
                        bool resultModel = int.TryParse(CombVidieoMaker.SelectedValue.ToString(), out id6);
                        string query = $@"UPDATE Procces SET Model=@Model, Speed=@Speed,IDMaker=@IDMaker WHERE ID=@ID;";
                        SQLiteCommand cmd = new SQLiteCommand(query, connection);
                        try
                        {
                            cmd.Parameters.AddWithValue("@ID", Saver.ProccesID);
                            cmd.Parameters.AddWithValue("@Model", TextProccModel.Text);
                            cmd.Parameters.AddWithValue("@Speed", TextSpeed.Text);
                            cmd.Parameters.AddWithValue("@IDMaker", id4);
                            cmd.ExecuteNonQuery();
                           // MessageBox.Show("Данные изменены");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        query = $@"UPDATE MaterPlatas SET Model=@Model, IDMaker=@IDMaker WHERE ID=@ID;";
                        cmd = new SQLiteCommand(query, connection);
                        try
                        {
                            cmd.Parameters.AddWithValue("@ID", Saver.MaterPlatID);
                            cmd.Parameters.AddWithValue("@Model", TextMatePlatModel.Text);
                            cmd.Parameters.AddWithValue("@IDMaker", id5);
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Данные изменены");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        query = $@"UPDATE VideoCards SET Model=@Model, VVideoMemory=@VVideoMemory, IDMaker=@IDMaker WHERE ID=@ID;";
                        cmd = new SQLiteCommand(query, connection);
                        try
                        {
                            cmd.Parameters.AddWithValue("@ID", Saver.VideCardID);
                            cmd.Parameters.AddWithValue("@Model", TextVideoModel.Text);
                            cmd.Parameters.AddWithValue("@VVideoMemory", TextVideoMemory.Text);
                            cmd.Parameters.AddWithValue("@IDMaker", id6);
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Данные изменены");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        query = $@"UPDATE SlotRAM1 SET Model=@Model, Vmemory=@Vmemory, TypeMemory=@TypeMemory,Maker=@Maker WHERE ID=@ID;";
                        cmd = new SQLiteCommand(query, connection);
                        try
                        {
                            cmd.Parameters.AddWithValue("@ID", Saver.SlotID1);
                            cmd.Parameters.AddWithValue("@Model", TextRAMModel1.Text);
                            cmd.Parameters.AddWithValue("@Vmemory", TextVmemory1.Text);
                            cmd.Parameters.AddWithValue("@TypeMemory", TextTypeMemory1.Text);
                            cmd.Parameters.AddWithValue("@Maker", TextMaker1.Text);
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Данные изменены");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


                        if (TextRAMModel2.Text != "" && (TextVmemory2.Text == "" || TextTypeMemory2.Text == "" || TextMaker2.Text == ""))
                        {
                            MessageBox.Show("Заполните");
                        }
                        else if (TextRAMModel2.Text == "" && (TextVmemory2.Text == "" && TextTypeMemory2.Text == "" && TextMaker2.Text == ""))
                        {
                            if (Saver.SlotID2 == "") { }
                            else
                            {
                                query = $@"UPDATE SlotRAM2 SET Model=@Model, Vmemory=@Vmemory, TypeMemory=@TypeMemory,Maker=@Maker WHERE ID=@ID;";
                                cmd = new SQLiteCommand(query, connection);
                                try
                                {
                                    cmd.Parameters.AddWithValue("@ID", Saver.SlotID2);
                                    cmd.Parameters.AddWithValue("@Model", TextRAMModel2.Text);
                                    cmd.Parameters.AddWithValue("@Vmemory", TextVmemory2.Text);
                                    cmd.Parameters.AddWithValue("@TypeMemory", TextTypeMemory2.Text);
                                    cmd.Parameters.AddWithValue("@Maker", TextMaker2.Text);
                                    cmd.ExecuteNonQuery();
                                    //MessageBox.Show("Данные изменены");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                        else
                        {
                            if (Saver.SlotID2 == "")
                            {
                                query = $@"INSERT INTO SlotRAM2 ('Model','Vmemory','TypeMemory',Maker) VALUES (@Model,@Vmemory,@TypeMemory,@Maker)";
                                cmd = new SQLiteCommand(query, connection);
                                cmd.Parameters.AddWithValue("@Model", TextRAMModel3.Text);
                                cmd.Parameters.AddWithValue("@Vmemory", TextVmemory3.Text);
                                cmd.Parameters.AddWithValue("@TypeMemory", TextTypeMemory3.Text);
                                cmd.Parameters.AddWithValue("@Maker", TextMaker3.Text);
                                cmd.ExecuteNonQuery();
                                query = $@"SELECT ID FROM SlotRAM2 WHERE Model = {TextRAMModel2.Text} and Vmemory = {TextVmemory2.Text} and TypeMemory = {TextTypeMemory2.Text} and  Maker = {TextMaker2.Text}";
                                cmd = new SQLiteCommand(query, connection);
                                int IDSlot = Convert.ToInt32(cmd.ExecuteScalar());
                                MessageBox.Show(Convert.ToString(IDSlot));
                                query = $@"UPDATE RAMs SET IDSlotRam3=@IDSlotRam2 WHERE ID=@ID";
                                cmd = new SQLiteCommand(query, connection);
                                cmd.Parameters.AddWithValue("@IDSlotRam2", IDSlot);
                                cmd.Parameters.AddWithValue("@ID", Saver.IDRAM);
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                query = $@"UPDATE SlotRAM2 SET Model=@Model, Vmemory=@Vmemory, TypeMemory=@TypeMemory,Maker=@Maker WHERE ID=@ID;";
                                cmd = new SQLiteCommand(query, connection);
                                try
                                {
                                    cmd.Parameters.AddWithValue("@ID", Saver.SlotID2);
                                    cmd.Parameters.AddWithValue("@Model", TextRAMModel2.Text);
                                    cmd.Parameters.AddWithValue("@Vmemory", TextVmemory2.Text);
                                    cmd.Parameters.AddWithValue("@TypeMemory", TextTypeMemory2.Text);
                                    cmd.Parameters.AddWithValue("@Maker", TextMaker2.Text);
                                    cmd.ExecuteNonQuery();
                                    //MessageBox.Show("Данные изменены");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }


                        if (TextRAMModel3.Text != "" && (TextVmemory3.Text == "" || TextTypeMemory3.Text == "" || TextMaker3.Text == ""))
                                {
                                    MessageBox.Show("Заполните");
                                }
                        else if (TextRAMModel3.Text == "" && (TextVmemory3.Text == "" && TextTypeMemory3.Text == "" && TextMaker3.Text == ""))
                                {
                                    if (Saver.SlotID3 == "") { }
                                    else
                                    {
                                        query = $@"UPDATE SlotRAM3 SET Model=@Model, Vmemory=@Vmemory, TypeMemory=@TypeMemory,Maker=@Maker WHERE ID=@ID;";
                                        cmd = new SQLiteCommand(query, connection);
                                        try
                                        {
                                            cmd.Parameters.AddWithValue("@ID", Saver.SlotID3);
                                            cmd.Parameters.AddWithValue("@Model", TextRAMModel3.Text);
                                            cmd.Parameters.AddWithValue("@Vmemory", TextVmemory3.Text);
                                            cmd.Parameters.AddWithValue("@TypeMemory", TextTypeMemory3.Text);
                                            cmd.Parameters.AddWithValue("@Maker", TextMaker3.Text);
                                            cmd.ExecuteNonQuery();
                                            //MessageBox.Show("Данные изменены");
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
                                    }
                                }
                        else
                                {
                                    if (Saver.SlotID3 == "")
                                    {
                                        query = $@"INSERT INTO SlotRAM3 ('Model','Vmemory','TypeMemory',Maker) VALUES (@Model,@Vmemory,@TypeMemory,@Maker)";
                                        cmd = new SQLiteCommand(query, connection);
                                        cmd.Parameters.AddWithValue("@Model", TextRAMModel3.Text);
                                        cmd.Parameters.AddWithValue("@Vmemory", TextVmemory3.Text);
                                        cmd.Parameters.AddWithValue("@TypeMemory", TextTypeMemory3.Text);
                                        cmd.Parameters.AddWithValue("@Maker", TextMaker3.Text);
                                        cmd.ExecuteNonQuery();
                                        query = $@"SELECT ID FROM SlotRAM3 WHERE Model = {TextRAMModel3.Text} and Vmemory = {TextVmemory3.Text} and TypeMemory = {TextTypeMemory3.Text} and  Maker = {TextMaker3.Text}";
                                        cmd = new SQLiteCommand(query, connection);
                                        int IDSlot = Convert.ToInt32(cmd.ExecuteScalar());
                                        MessageBox.Show(Convert.ToString(IDSlot));
                                        query = $@"UPDATE RAMs SET IDSlotRam3=@IDSlotRam3 WHERE ID=@ID";
                                        cmd = new SQLiteCommand(query, connection);
                                        cmd.Parameters.AddWithValue("@IDSlotRam3", IDSlot);
                                        cmd.Parameters.AddWithValue("@ID", Saver.IDRAM);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        query = $@"UPDATE SlotRAM3 SET Model=@Model, Vmemory=@Vmemory, TypeMemory=@TypeMemory,Maker=@Maker WHERE ID=@ID;";
                                        cmd = new SQLiteCommand(query, connection);
                                        try
                                        {
                                            cmd.Parameters.AddWithValue("@ID", Saver.SlotID3);
                                            cmd.Parameters.AddWithValue("@Model", TextRAMModel3.Text);
                                            cmd.Parameters.AddWithValue("@Vmemory", TextVmemory3.Text);
                                            cmd.Parameters.AddWithValue("@TypeMemory", TextTypeMemory3.Text);
                                            cmd.Parameters.AddWithValue("@Maker", TextMaker3.Text);
                                            cmd.ExecuteNonQuery();
                                            //MessageBox.Show("Данные изменены");
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
                                    }
                                }

                        if (TextRAMModel4.Text != "" && (TextVmemory4.Text == "" || TextTypeMemory4.Text == "" || TextMaker4.Text == ""))
                        {
                            MessageBox.Show("Заполните");
                        }
                        else if (TextRAMModel4.Text == "" && (TextVmemory4.Text == "" && TextTypeMemory4.Text == "" && TextMaker4.Text == ""))
                        {
                            if (Saver.SlotID4 == "") { }
                            else
                            {
                                query = $@"UPDATE SlotRAM4 SET Model=@Model, Vmemory=@Vmemory, TypeMemory=@TypeMemory,Maker=@Maker WHERE ID=@ID;";
                                cmd = new SQLiteCommand(query, connection);
                                try
                                {
                                    cmd.Parameters.AddWithValue("@ID", Saver.SlotID4);
                                    cmd.Parameters.AddWithValue("@Model", TextRAMModel4.Text);
                                    cmd.Parameters.AddWithValue("@Vmemory", TextVmemory4.Text);
                                    cmd.Parameters.AddWithValue("@TypeMemory", TextTypeMemory4.Text);
                                    cmd.Parameters.AddWithValue("@Maker", TextMaker4.Text);
                                    cmd.ExecuteNonQuery();
                                    //MessageBox.Show("Данные изменены");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                        else
                        {
                            if (Saver.SlotID4 == "")
                            {
                                query = $@"INSERT INTO SlotRAM4 ('Model','Vmemory','TypeMemory',Maker) VALUES (@Model,@Vmemory,@TypeMemory,@Maker)";
                                cmd = new SQLiteCommand(query, connection);
                                cmd.Parameters.AddWithValue("@Model", TextRAMModel4.Text);
                                cmd.Parameters.AddWithValue("@Vmemory", TextVmemory4.Text);
                                cmd.Parameters.AddWithValue("@TypeMemory", TextTypeMemory4.Text);
                                cmd.Parameters.AddWithValue("@Maker", TextMaker4.Text);
                                cmd.ExecuteNonQuery();
                                query = $@"SELECT ID FROM SlotRAM4 WHERE Model = {TextRAMModel4.Text} and Vmemory = {TextVmemory4.Text} and TypeMemory = {TextTypeMemory4.Text} and  Maker = {TextMaker4.Text}";
                                cmd = new SQLiteCommand(query, connection);
                                int IDSlot = Convert.ToInt32(cmd.ExecuteScalar());
                                MessageBox.Show(Convert.ToString(IDSlot));
                                query = $@"UPDATE RAMs SET IDSlotRam4=@IDSlotRam4 WHERE ID=@ID";
                                cmd = new SQLiteCommand(query, connection);
                                cmd.Parameters.AddWithValue("@IDSlotRam4", IDSlot);
                                cmd.Parameters.AddWithValue("@ID", Saver.IDRAM);
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                query = $@"UPDATE SlotRAM4 SET Model=@Model, Vmemory=@Vmemory, TypeMemory=@TypeMemory,Maker=@Maker WHERE ID=@ID;";
                                cmd = new SQLiteCommand(query, connection);
                                try
                                {
                                    cmd.Parameters.AddWithValue("@ID", Saver.SlotID4);
                                    cmd.Parameters.AddWithValue("@Model", TextRAMModel4.Text);
                                    cmd.Parameters.AddWithValue("@Vmemory", TextVmemory4.Text);
                                    cmd.Parameters.AddWithValue("@TypeMemory", TextTypeMemory4.Text);
                                    cmd.Parameters.AddWithValue("@Maker", TextMaker4.Text);
                                    cmd.ExecuteNonQuery();
                                    //MessageBox.Show("Данные изменены");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }


                    }
                }
            }
        }
    }
}
      
        
    

