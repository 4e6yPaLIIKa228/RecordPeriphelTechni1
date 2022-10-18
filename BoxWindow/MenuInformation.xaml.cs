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
using RecordPeriphelTechniс.BoxWindow;
using RecordPeriphelTechniс.Connection;

namespace RecordPeriphelTechniс.Windows
{
    /// <summary>
    /// Логика взаимодействия для MenuInformation.xaml
    /// </summary>
    public partial class MenuInformation : Window
    {
        int IndexTabCont;
        public MenuInformation()
        {
            InitializeComponent();
            LoadDB_InforPcTex();
            LoadDB_InforPerTech();
            LoadDB_InforDopOboryd();
        }

        public void LoadDB_InforPcTex()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            {
                try
                {
                connection.Open();
                    string query  = $@"SELECT MenuPerTech.ID as IDMenuPer, MenuPerTech.Name as NameYstr, TypeTechs.NameType,MenuPerTech.Kabunet ,Organiz.NameOrg, MenuPerTech.Number,
MenuPerTech.IDComponets as IDComponets, MenuPerTech.StartWork, MenuPerTech.EndWork,
MenuPerTech.Comments, Status.NameStatus, Works.NameWorks,
Procces.ID as ProccesID, Procces.Model as NameProcces ,Procces.Speed as SpeedProcces, MakersProcc.Name as MakerProcc,
MaterPlatas.ID as MaterPlatID, MaterPlatas.Model as ModelMatePlat, MakersMaterPlat.Name as MakerMaterPlat,
VideoCards.ID as VideoCardID, VideoCards.Model as ModeVideos, VideoCards.VVideoMemory , MakersVideoCard.Name as MakerVideoCard,
RAMs.ID as IDRAM,
SlotRAM1.ID as SlotID1, SlotRAM1.Model as Model1, SlotRAM1.Vmemory as V1, SlotRAM1.TypeMemory as TypeMemory1 , SlotRAM1.Maker as Maker1, 
SlotRAM2.ID as SlotID2, SlotRAM2.Model as Model2 ,SlotRAM2.Vmemory as V2, SlotRAM2.TypeMemory as TypeMemory2,  SlotRAM2.Maker as Maker2,
SlotRAM3.ID as SlotID3, SlotRAM3.Model as Model3 ,SlotRAM3.Vmemory as V3, SlotRAM3.TypeMemory as TypeMemory3, SlotRAM3.Maker as Maker3,
SlotRAM4.ID as SlotID4, SlotRAM4.Model as Model4 ,SlotRAM4.Vmemory as V4, SlotRAM4.TypeMemory as TypeMemory4,  SlotRAM4.Maker as Maker4  

FROM MenuPerTech
JOIN TypeTechs on MenuPerTech.IDTypeTech = TypeTechs.ID
JOIN Organiz on MenuPerTech.IDOrganiz = Organiz.ID
JOIN Components on MenuPerTech.IDComponets = Components.ID
JOIN Status on MenuPerTech.IDStatus = Status.ID
JOIN Works on MenuPerTech.IDWorks = Works.ID

JOIN Procces on Components.IDProcces = Procces.ID
LEFT JOIN MakersProcc ON Procces.IDMaker = MakersProcc.ID

JOIN MaterPlatas on Components.IDMaterPlata = MaterPlatas.ID
JOIN MakersMaterPlat on MaterPlatas.IDMaker = MakersMaterPlat.ID

JOIN VideoCards on Components.IDVideo = VideoCards.ID
JOIN MakersVideoCard on VideoCards.IDMaker = MakersVideoCard.ID

LEFT JOIN RAMs on Components.ID = RAMs.ID
LEFT JOIN SlotRAM1 on RAMs.IDSlotRam1 = SlotRAM1.ID
LEFT JOIN SlotRAM2 on RAMs.IDSlotRam2 = SlotRAM2.ID
LEFT JOIN SlotRAM3 on RAMs.IDSlotRam3 = SlotRAM3.ID
LEFT JOIN SlotRAM4 on RAMs.IDSlotRam4 = SlotRAM4.ID

WHERE  MenuPerTech.IDTypeTech = '1'
                          ";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);                    
                    DataTable DT = new DataTable("MenuPerTech");
                    SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
                    SDA.Fill(DT);
                    InforPcTex.ItemsSource = DT.DefaultView;
                    cmd.ExecuteNonQuery();
                    SQLiteDataReader dr = null;
                    dr = cmd.ExecuteReader();                   
                    while (dr.Read())
                    {
                        //Componets, ProccesID, MaterPlatID, VideCardID, IDRAM, Slot1ID1, Slot1ID2, Slot1ID3, Slot1ID4;
                        Saver.IDMenuPerPC = dr["IDMenuPer"].ToString();
                        Saver.IDComponets = dr["IDComponets"].ToString();
                        Saver.ProccesID = dr["ProccesID"].ToString();
                        Saver.MaterPlatID = dr["MaterPlatID"].ToString();
                        Saver.VideCardID = dr["VideoCardID"].ToString();
                        Saver.IDRAM = dr["IDRAM"].ToString();
                        Saver.SlotID1 = dr["SlotID1"].ToString();
                        Saver.SlotID2 = dr["SlotID2"].ToString();
                        Saver.SlotID3 = dr["SlotID3"].ToString();
                        Saver.SlotID4 = dr["SlotID4"].ToString();

                    }
                   

                }
                catch (Exception ex)
                {
                 MessageBox.Show(ex.Message);
                }
            }
        }
        public void LoadDB_InforPerTech()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            {
                try
                {
                    connection.Open();
                    string query = $@"SELECT MenuPerTech.ID as IDMenuPer, MenuPerTech.Name as NameYstr, TypeTechs.NameType, Organiz.NameOrg, MenuPerTech.Kabunet, MenuPerTech.Number,
MenuPerTech.IDComponets, MenuPerTech.StartWork, MenuPerTech.EndWork,
MenuPerTech.Comments, Status.NameStatus, Works.NameWorks

FROM MenuPerTech
LEFT JOIN TypeTechs on MenuPerTech.IDTypeTech = TypeTechs.ID
LEFT JOIN Organiz on MenuPerTech.IDOrganiz = Organiz.ID
LEFT JOIN Components on MenuPerTech.IDComponets = Components.ID
LEFT JOIN Status on MenuPerTech.IDStatus = Status.ID
LEFT JOIN Works on MenuPerTech.IDWorks = Works.ID

WHERE  MenuPerTech.IDTypeTech = '2'
                          ";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    DataTable DT = new DataTable("MenuPerTech");
                    SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
                    SDA.Fill(DT);
                    InforPerTech.ItemsSource = DT.DefaultView;
                    cmd.ExecuteNonQuery();
                    SQLiteDataReader dr = null;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Saver.IDMenuPerTech = dr["IDMenuPer"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void LoadDB_InforDopOboryd()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            {
                try
                {
                    connection.Open();
                    string query = $@"SELECT MenuPerTech.ID as IDMenuPer, MenuPerTech.Name as NameYstr, TypeTechs.NameType, Organiz.NameOrg,MenuPerTech.Kabunet, MenuPerTech.Number,
MenuPerTech.IDComponets, MenuPerTech.StartWork, MenuPerTech.EndWork,
MenuPerTech.Comments, Status.NameStatus, Works.NameWorks

FROM MenuPerTech
LEFT JOIN TypeTechs on MenuPerTech.IDTypeTech = TypeTechs.ID
LEFT JOIN Organiz on MenuPerTech.IDOrganiz = Organiz.ID
LEFT JOIN Components on MenuPerTech.IDComponets = Components.ID
LEFT JOIN Status on MenuPerTech.IDStatus = Status.ID
LEFT JOIN Works on MenuPerTech.IDWorks = Works.ID
WHERE  MenuPerTech.IDTypeTech = '3'
                          ";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    DataTable DT = new DataTable("MenuPerTech");
                    SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
                    SDA.Fill(DT);
                    InforDopOboryd.ItemsSource = DT.DefaultView;
                    cmd.ExecuteNonQuery();
                    SQLiteDataReader dr = null;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Saver.IDMenuOboryd = dr["IDMenuPer"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Eddit_InforPcTex()
        {
            if (InforPcTex.SelectedIndex != -1)
            {
                int Type = 1;
                EditTech tech = new EditTech((DataRowView)InforPcTex.SelectedItem, Type);
                tech.Owner = this;
                bool? result = tech.ShowDialog();
                switch (result)
                {
                    default:
                        LoadDB_InforPcTex();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Выберите строку с данными,чтобы ее изменить");
            }
        }
        private void Eddit_InforPerTech()
        {
            if (InforPerTech.SelectedIndex != -1)
            {
                int Type = 2;
                EditTech tech = new EditTech((DataRowView)InforPerTech.SelectedItem, Type);
                tech.Owner = this;
                bool? result = tech.ShowDialog();
                switch (result)
                {
                    default:
                        LoadDB_InforPerTech();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Выберите строку с данными,чтобы ее изменить");
            }
        }
        private void Eddit_InforDopOboryd()
        {
            if (InforDopOboryd.SelectedIndex != -1)
            {
                int Type = 3;
                EditTech tech = new EditTech((DataRowView)InforDopOboryd.SelectedItem, Type);
                tech.Owner = this;
                bool? result = tech.ShowDialog();
                switch (result)
                {
                    default:
                        LoadDB_InforDopOboryd();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Выберите строку с данными,чтобы ее изменить");
            }
        }

        private void InforPcTex_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Eddit_InforPcTex();
        }

        private void InforPerTech_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Eddit_InforPerTech();
        }
        private void InforDopOboryd_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Eddit_InforDopOboryd();
        }



        private void BtnEddit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Convert.ToString(IndexTabCont));
            if (IndexTabCont == 0)
            {
                Eddit_InforPcTex();
            }else if(IndexTabCont == 1)
            {
                Eddit_InforPerTech();
            }else if (IndexTabCont == 2)
            {
                Eddit_InforDopOboryd();
            }            
        }

        private void TabConrlMenuPer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          IndexTabCont =  TabConrlMenuPer.SelectedIndex;           
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddTech addtech = new AddTech();
            bool? result = addtech.ShowDialog();
            switch (result)
            {
                default:
                    LoadDB_InforPcTex();
                    LoadDB_InforPerTech();
                    LoadDB_InforDopOboryd();
                    break;
            }
        }
    }
}
