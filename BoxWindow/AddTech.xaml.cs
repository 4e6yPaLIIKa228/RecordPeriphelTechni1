﻿using System;
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


namespace RecordPeriphelTechniс.BoxWindow
{
    /// <summary>
    /// Логика взаимодействия для AddTech.xaml
    /// </summary>
    public partial class AddTech : Window
    {
        int IDMenuPerTech = 0, IDTypeTech=0, Proverka=0, Proverka2=0,IDComponets = 0, IDProcces=0, IDMaterPlat=0, IDVideoCard=0,IDRams=0, IDSlot1=0;
        int IDSlot2= 0, IDSlot3 = 0, IDSlot4 = 0;
        //string IDSlot2 = null, IDSlot3 = null, IDSlot4 = null;
        public AddTech()
        {
            InitializeComponent();
            CombBoxDowmload();
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

      
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            AddOsnova();
            if (IDTypeTech == 1 && Proverka == 0)
            {
                
                AddPcCompet();
                if (Proverka2 != 0)
                {
                    AddOsnova();
                    AddRams();
                    AddComponets();
                    UpdateMenuPer();
                    MessageBox.Show("Данные добавлены");
                }
                
            }
        } 
        
        public void AddOsnova()
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
                    bool resultType = int.TryParse(CombTypeTech.SelectedValue.ToString(), out  IDTypeTech);
                    bool resultClass = int.TryParse(CombIDOrgamniz.SelectedValue.ToString(), out int  id);
                    bool resultKab = int.TryParse(CombIDStatus.SelectedValue.ToString(), out int  id2);
                    bool resultCon = int.TryParse(CombIDWorks.SelectedValue.ToString(), out int  id3);
                    string query = $@"SELECT count (Number) FROM MenuPerTech WHERE Number = '{TextNumber.Text}'";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    Proverka = Convert.ToInt32(cmd.ExecuteScalar());

                    if (Proverka != 1 && IDTypeTech != 1)
                    {
                        if (Proverka != 1)
                        {

                            query = $@"INSERT INTO MenuPerTech('IDTypeTech','IDOrganiz','Kabunet','Number','IDComponets','Name','StartWork','EndWork','IDStatus','IDWorks','Comments')
                                        values (@IDTypeTech,@IDOrganiz,@Kabunet,@Number,@IDComponets,@Name,@StartWork,@EndWork,@IDStatus,@IDWorks,@Comments)";
                            cmd = new SQLiteCommand(query, connection);
                            try
                            {
                                cmd.Parameters.AddWithValue("@IDTypeTech", IDTypeTech);
                                cmd.Parameters.AddWithValue("@IDOrganiz", id);
                                cmd.Parameters.AddWithValue("@Kabunet", TextIDKabuneta.Text);
                                cmd.Parameters.AddWithValue("@Number", TextNumber.Text);
                                cmd.Parameters.AddWithValue("@IDComponets", null);
                                cmd.Parameters.AddWithValue("@Name", TextName.Text);
                                cmd.Parameters.AddWithValue("@StartWork", TextDataStart.Text);
                                cmd.Parameters.AddWithValue("@EndWork", TextDataEnd.Text);
                                cmd.Parameters.AddWithValue("@IDStatus", id2);
                                cmd.Parameters.AddWithValue("@IDWorks", id3);
                                cmd.Parameters.AddWithValue("@Comments", TextComments.Text);
                                cmd.ExecuteNonQuery();
                            }
                            catch (SQLiteException ex)
                            {
                                MessageBox.Show("Error: " + ex.Message);
                            }
                            query = $@"SELECT ID FROM MenuPerTech WHERE IDTypeTech = '{IDTypeTech}' and IDOrganiz = '{id}' and Kabunet = '{TextIDKabuneta.Text}' and  Number = '{TextNumber.Text}' and Name = '{TextName.Text}' and StartWork = '{TextDataStart.Text}' and EndWork = '{TextDataEnd.Text}' and  IDStatus = '{id2}' and  IDWorks ='{id3}' and Comments = '{TextComments.Text}' ";
                            cmd = new SQLiteCommand(query, connection);
                            IDMenuPerTech = Convert.ToInt32(cmd.ExecuteScalar());
                            MessageBox.Show("Данные добавлены");
                        }
                        else
                        {
                            MessageBox.Show("Измените номер техники");
                        }

                    }
                    else
                    {
                       // MessageBox.Show("Измените номер техники");
                    }
                    if (Proverka2 != 0)
                    {
                        query = $@"INSERT INTO MenuPerTech('IDTypeTech','IDOrganiz','Kabunet','Number','IDComponets','Name','StartWork','EndWork','IDStatus','IDWorks','Comments')
                                        values (@IDTypeTech,@IDOrganiz,@Kabunet,@Number,@IDComponets,@Name,@StartWork,@EndWork,@IDStatus,@IDWorks,@Comments)";
                        cmd = new SQLiteCommand(query, connection);
                        try
                        {
                            cmd.Parameters.AddWithValue("@IDTypeTech", IDTypeTech);
                            cmd.Parameters.AddWithValue("@IDOrganiz", id);
                            cmd.Parameters.AddWithValue("@Kabunet", TextIDKabuneta.Text);
                            cmd.Parameters.AddWithValue("@Number", TextNumber.Text);
                            cmd.Parameters.AddWithValue("@IDComponets", 1);
                            cmd.Parameters.AddWithValue("@Name", TextName.Text);
                            cmd.Parameters.AddWithValue("@StartWork", TextDataStart.Text);
                            cmd.Parameters.AddWithValue("@EndWork", TextDataEnd.Text);
                            cmd.Parameters.AddWithValue("@IDStatus", id2);
                            cmd.Parameters.AddWithValue("@IDWorks", id3);
                            cmd.Parameters.AddWithValue("@Comments", TextComments.Text);
                            cmd.ExecuteNonQuery();
                        }
                        catch (SQLiteException ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                        query = $@"SELECT ID FROM MenuPerTech WHERE IDTypeTech = '{IDTypeTech}' and IDOrganiz ='{id}' and Kabunet = '{TextIDKabuneta.Text}' and  Number = '{TextNumber.Text}' and Name = '{TextName.Text}' and StartWork = '{TextDataStart.Text}' and EndWork = '{TextDataEnd.Text}' and  IDStatus = '{id2}' and  IDWorks = '{id3}' and Comments = '{TextComments.Text}' ";
                        cmd = new SQLiteCommand(query, connection);
                        IDMenuPerTech = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
        }

        public void AddPcCompet()
        {
            if (String.IsNullOrEmpty(TextProccModel.Text) || String.IsNullOrEmpty(TextSpeed.Text) || String.IsNullOrEmpty(CombProccMaker.Text) || String.IsNullOrEmpty(TextMatePlatModel.Text) || String.IsNullOrEmpty(CombMatePlatMaker.Text) ||
                       String.IsNullOrEmpty(CombMatePlatMaker.Text) || String.IsNullOrEmpty(TextRAMModel1.Text) || String.IsNullOrEmpty(TextVmemory1.Text) || String.IsNullOrEmpty(TextTypeMemory1.Text) ||
                       String.IsNullOrEmpty(TextMaker1.Text) || String.IsNullOrEmpty(TextVideoModel.Text) || String.IsNullOrEmpty(TextVideoMemory.Text) || String.IsNullOrEmpty(CombVidieoMaker.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Proverka2 = 0;
            }
            else
            {
                using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
                {
                    connection.Open();
                    bool resultTitl = int.TryParse(CombProccMaker.SelectedValue.ToString(), out int id4);
                    bool resultBrand = int.TryParse(CombMatePlatMaker.SelectedValue.ToString(), out int id5);
                    bool resultModel = int.TryParse(CombVidieoMaker.SelectedValue.ToString(), out int id6);

                    string query = $@"INSERT INTO Procces ('Model', 'Speed','IDMaker') VALUES ('{TextProccModel.Text}','{TextSpeed.Text}','{id4}');";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    query = $@"SELECT ID FROM Procces WHERE Model = '{TextProccModel.Text}' and Speed = '{TextSpeed.Text}' and IDMaker = '{id4}' ";
                    cmd = new SQLiteCommand(query, connection);
                    IDProcces = Convert.ToInt32(cmd.ExecuteScalar());


                    query = $@"INSERT INTO MaterPlatas ('Model','IDMaker') VALUES ('{TextMatePlatModel.Text}','{id5}');";
                    cmd = new SQLiteCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    query = $@"SELECT ID FROM MaterPlatas  WHERE Model = '{TextMatePlatModel.Text}' and IDMaker = '{id5}' ";
                    cmd = new SQLiteCommand(query, connection);
                    IDMaterPlat = Convert.ToInt32(cmd.ExecuteScalar());

                    query = $@"INSERT INTO VideoCards ('Model','VVideoMemory','IDMaker') VALUES ('{TextVideoModel.Text}','{TextVideoMemory.Text}','{id6}');";
                    cmd = new SQLiteCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    query = $@"SELECT ID FROM VideoCards  WHERE Model = '{TextVideoModel.Text}' and VVideoMemory = '{TextVideoMemory.Text}' and IDMaker = '{id6}' ";
                    cmd = new SQLiteCommand(query, connection);
                    IDVideoCard = Convert.ToInt32(cmd.ExecuteScalar());

                    query = $@"INSERT INTO SlotRAM1 ('Model','Vmemory','TypeMemory','Maker') VALUES ('{TextRAMModel1.Text}','{TextVmemory1.Text}','{TextTypeMemory1.Text}','{TextMaker1.Text}');";
                    cmd = new SQLiteCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    query = $@"SELECT ID FROM SlotRAM1 WHERE Model = '{TextRAMModel1.Text}' and Vmemory = '{TextVmemory1.Text}' and TypeMemory = '{TextTypeMemory1.Text}' and Maker = '{TextMaker1.Text}'";
                    cmd = new SQLiteCommand(query, connection);
                    IDSlot1 = Convert.ToInt32(cmd.ExecuteScalar());                    
                    Proverka2 = 1;
                }
            }
        }

        public void AddRams()
        {
            try 
            {
                using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
                {
                    connection.Open();                    
                    if (TextRAMModel2.Text != "" && TextVmemory2.Text != "" && TextTypeMemory2.Text != "" && TextMaker2.Text != "")
                    {
                        MessageBox.Show("заполнено все2");
                        string query1 = $@"INSERT INTO SlotRAM2 ('Model','Vmemory','TypeMemory','Maker') VALUES ('{TextRAMModel2.Text}','{TextVmemory2.Text}','{TextTypeMemory2.Text}','{TextMaker2.Text}')";
                        SQLiteCommand cmd1 = new SQLiteCommand(query1, connection);
                        cmd1.ExecuteNonQuery();
                        query1 = $@"SELECT ID FROM SlotRAM2 WHERE Model = '{TextRAMModel2.Text}' and Vmemory = '{TextVmemory2.Text}' and TypeMemory = '{TextTypeMemory2.Text}' and  Maker = '{TextMaker2.Text}'";
                        cmd1 = new SQLiteCommand(query1, connection);
                       // int IDSlot2loc = Convert.ToInt32(cmd1.ExecuteScalar());
                        IDSlot2 = Convert.ToInt32(cmd1.ExecuteScalar());
                        //IDSlot2 = Convert.ToString(IDSlot2loc);
                    }
                    else if (TextRAMModel2.Text != "" && (TextVmemory2.Text == "" || TextTypeMemory2.Text == "" || TextMaker2.Text == ""))
                    {
                        //  MessageBox.Show("Дозаполните");
                    }
                    else if (TextRAMModel2.Text == "" && (TextVmemory2.Text == "" && TextTypeMemory2.Text == "" && TextMaker2.Text == ""))
                    {
                        //  MessageBox.Show("Все пусто");
                        string query1 = $@"INSERT INTO SlotRAM2 ('Model','Vmemory','TypeMemory','Maker') VALUES ('Нет','Нет','Нет','Нет')";
                        SQLiteCommand cmd1 = new SQLiteCommand(query1, connection);
                        cmd1.ExecuteNonQuery();
                        query1 = $@"SELECT ID FROM SlotRAM2 WHERE Model = 'Нет' and Vmemory = 'Нет' and TypeMemory = 'Нет' and  Maker = 'Нет'";
                        cmd1 = new SQLiteCommand(query1, connection);
                       // int IDSlot2loc = Convert.ToInt32(cmd1.ExecuteScalar());
                        //IDSlot2 = Convert.ToString(IDSlot2loc);
                        IDSlot2 = Convert.ToInt32(cmd1.ExecuteScalar());
                    }
                    else
                    {
                        // MessageBox.Show("Дозаполните");
                    }
                    if (TextRAMModel3.Text != "" && TextVmemory3.Text != "" && TextTypeMemory3.Text != "" && TextMaker3.Text != "")
                    {
                        MessageBox.Show("заполнено все3");
                        string query1 = $@"INSERT INTO SlotRAM3 ('Model','Vmemory','TypeMemory','Maker') VALUES ('{TextRAMModel3.Text}','{TextVmemory3.Text}','{TextTypeMemory3.Text}','{TextMaker3.Text}')";
                        SQLiteCommand cmd1 = new SQLiteCommand(query1, connection);
                        cmd1.ExecuteNonQuery();
                        query1 = $@"SELECT ID FROM SlotRAM3 WHERE Model = '{TextRAMModel3.Text}' and Vmemory = '{TextVmemory3.Text}' and TypeMemory = '{TextTypeMemory3.Text}' and  Maker = '{TextMaker3.Text}'";
                        cmd1 = new SQLiteCommand(query1, connection);
                       // int IDSlot3loc = Convert.ToInt32(cmd1.ExecuteScalar());
                       // IDSlot3 = Convert.ToString(IDSlot3loc);
                        IDSlot3 = Convert.ToInt32(cmd1.ExecuteScalar());
                    }
                    else if (TextRAMModel3.Text != "" && (TextVmemory3.Text == "" || TextTypeMemory3.Text == "" || TextMaker3.Text == ""))
                    {
                        //  MessageBox.Show("Дозаполните");
                    }
                    else if (TextRAMModel3.Text == "" && (TextVmemory3.Text == "" && TextTypeMemory3.Text == "" && TextMaker3.Text == ""))
                    {
                        //  MessageBox.Show("Все пусто");
                        string query1 = $@"INSERT INTO SlotRAM3 ('Model','Vmemory','TypeMemory','Maker') VALUES ('Нет','Нет','Нет','Нет')";
                        SQLiteCommand cmd1 = new SQLiteCommand(query1, connection);
                        cmd1.ExecuteNonQuery();
                        query1 = $@"SELECT ID FROM SlotRAM3 WHERE Model = 'Нет' and Vmemory = 'Нет' and TypeMemory = 'Нет' and  Maker = 'Нет'";
                        cmd1 = new SQLiteCommand(query1, connection);
                        // int IDSlot3loc = Convert.ToInt32(cmd1.ExecuteScalar());
                        // IDSlot3 = Convert.ToString(IDSlot3loc);
                        IDSlot3 = Convert.ToInt32(cmd1.ExecuteScalar());
                    }
                    else
                    {
                        // MessageBox.Show("Дозаполните");
                    }
                    if (TextRAMModel4.Text != "" && TextVmemory4.Text != "" && TextTypeMemory4.Text != "" && TextMaker4.Text != "")
                    {
                        MessageBox.Show("заполнено все4");
                        string query1 = $@"INSERT INTO SlotRAM4 ('Model','Vmemory','TypeMemory','Maker') VALUES ('{TextRAMModel4.Text}','{TextVmemory4.Text}','{TextTypeMemory4.Text}','{TextMaker4.Text}')";
                        SQLiteCommand cmd1 = new SQLiteCommand(query1, connection);
                        cmd1.ExecuteNonQuery();
                        query1 = $@"SELECT ID FROM SlotRAM4 WHERE Model = '{TextRAMModel4.Text}' and Vmemory = '{TextVmemory4.Text}' and TypeMemory = '{TextTypeMemory4.Text}' and  Maker = '{TextMaker4.Text}'";
                        cmd1 = new SQLiteCommand(query1, connection);
                        // int IDSlot4loc = Convert.ToInt32(cmd1.ExecuteScalar());
                        // IDSlot4 = Convert.ToString(IDSlot4loc);
                        IDSlot4 = Convert.ToInt32(cmd1.ExecuteScalar());
                    }
                    else if (TextRAMModel4.Text != "" && (TextVmemory4.Text == "" || TextTypeMemory4.Text == "" || TextMaker4.Text == ""))
                    {
                        //  MessageBox.Show("Дозаполните");
                    }
                    else if (TextRAMModel4.Text == "" && (TextVmemory4.Text == "" && TextTypeMemory4.Text == "" && TextMaker4.Text == ""))
                    {
                        //  MessageBox.Show("Все пусто");
                        string query1 = $@"INSERT INTO SlotRAM4 ('Model','Vmemory','TypeMemory','Maker') VALUES ('Нет','Нет','Нет','Нет')";
                        SQLiteCommand cmd1 = new SQLiteCommand(query1, connection);
                        cmd1.ExecuteNonQuery();
                        query1 = $@"SELECT ID FROM SlotRAM4 WHERE Model = 'Нет' and Vmemory = 'Нет' and TypeMemory = 'Нет' and  Maker = 'Нет' ";
                        cmd1 = new SQLiteCommand(query1, connection);
                        // int IDSlot4loc = Convert.ToInt32(cmd1.ExecuteScalar());
                        //IDSlot4 = Convert.ToString(IDSlot4loc);
                        IDSlot4 = Convert.ToInt32(cmd1.ExecuteScalar());
                    }
                    else
                    {
                        // MessageBox.Show("Дозаполните");
                    }
                    // string query = $@"SELECT ID FROM RAMs WHERE IDSlotRam1 = '{IDSlot1}' and IDSlotRam2 = '{IDSlot2}' and IDSlotRam3 = '{IDSlot3}' and IDSlotRam4 = '{IDSlot4}' ";
                    // SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    // IDRams = Convert.ToInt32(cmd.ExecuteScalar());
                    //if (IDRams == 0)
                    // {
                    string query = $@"INSERT  INTO RAMs  ('IDSlotRam1', 'IDSlotRam2','IDSlotRam3','IDSlotRam4') VALUES ('{IDSlot1}','{IDSlot2}','{IDSlot3}','{IDSlot4}');";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                        cmd.ExecuteNonQuery();
                        query = $@"SELECT ID FROM RAMs WHERE IDSlotRam1 = '{IDSlot1}' and IDSlotRam2 = '{IDSlot2}' and IDSlotRam3 = '{IDSlot3}' and IDSlotRam4 = '{IDSlot4}' ";
                        cmd = new SQLiteCommand(query, connection);
                        IDRams = Convert.ToInt32(cmd.ExecuteScalar());
                   // }
                   // else
                   // {
                    //    query = $@"UPDATE RAMs SET IDSlotRam1='{IDSlot1}', IDSlotRam2='{IDSlot2}', IDSlotRam3='{IDSlot3}',IDSlotRam4='{IDSlot4}' WHERE ID='{IDRams}';";
                    //    cmd = new SQLiteCommand(query, connection);
                   //     cmd.ExecuteNonQuery();
                   // }
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddComponets()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
                {
                    connection.Open();
                    string query = $@"INSERT INTO Components  ('IDProcces', 'IDMaterPlata','IDRAM','IDVideo') VALUES ('{IDProcces}','{IDMaterPlat}','{IDRams}','{IDVideoCard}') ";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    query = $@"SELECT ID FROM Components WHERE IDProcces = '{IDProcces}' and IDMaterPlata = '{IDMaterPlat}' and IDRAM = '{IDRams}' and IDVideo = '{IDVideoCard}'";
                    cmd = new SQLiteCommand(query, connection);
                    IDComponets = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateMenuPer()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
                {
                    connection.Open();
                    string query = $@"UPDATE MenuPerTech SET IDComponets ='{IDComponets}' WHERE ID ='{IDMenuPerTech}' ";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
