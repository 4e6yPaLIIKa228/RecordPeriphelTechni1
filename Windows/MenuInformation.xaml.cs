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
    /// Логика взаимодействия для MenuInformation.xaml
    /// </summary>
    public partial class MenuInformation : Window
    {
        public MenuInformation()
        {
            InitializeComponent();
            LoadDB();
        }

        public void LoadDB()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            {
                try
                {
                connection.Open();
                    string query  = $@"SELECT MenuPerTech.ID as IDPer, TypeTechs.NameType, Organiz.NameOrg, MenuPerTech.Number,
MenuPerTech.IDComponets, MenuPerTech.StartWork, MenuPerTech.EndWork,
MenuPerTech.Comments, Status.NamaStatus, Works.NameWorks,Components.ID as Components ,
Procces.ID, ModelsProc.Model as NameProcces ,Procces.Speed as SpeedProcces, MakersProcc.Name as MakerProcc,
MaterPlatas.ID, ModelsMatePlat.Model as ModelMatePlat, MakersMaterPlat.Name as MakerMaterPlat,
VideoCards.ID, ModelsVideos.Model as ModeVideos, VideoCards.VVideoMemory , MakersVideoCard.Name as MakerVideoCard


FROM MenuPerTech
JOIN TypeTechs on MenuPerTech.IDTypeTech = TypeTechs.ID
JOIN Organiz on MenuPerTech.IDOrganiz = Organiz.ID
JOIN Components on MenuPerTech.IDComponets = Components.ID
JOIN Status on MenuPerTech.IDStatus = Status.ID
JOIN Works on MenuPerTech.IDWorks = Works.ID

JOIN Procces on Components.IDProcces = Procces.ID
JOIN ModelsProc on Procces.IDModel = ModelsProc.ID
LEFT JOIN MakersProcc ON Procces.IDMaker = MakersProcc.ID

JOIN MaterPlatas on Components.IDMaterPlata = MaterPlatas.ID
JOIN ModelsMatePlat on MaterPlatas.IDModel = ModelsMatePlat.ID
JOIN MakersMaterPlat on MaterPlatas.IDMaker = MakersMaterPlat.ID

JOIN VideoCards on Components.IDVideo = VideoCards.ID
JOIN ModelsVideos on VideoCards.IDModel = ModelsVideos.ID
JOIN MakersVideoCard on VideoCards.IDMaker = MakersVideoCard.ID

                            ";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);                    
                    DataTable DT = new DataTable("MenuPerTech");
                    SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
                    SDA.Fill(DT);
                    InforPerTech.ItemsSource = DT.DefaultView;
                    SQLiteDataReader dr = null;
                    dr = cmd.ExecuteReader();
                    string IDComponents = "";
                    while (dr.Read())
                    {
                        IDComponents = dr["Components"].ToString();
                    }
                    MessageBox.Show(IDComponents);
                    // cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                 MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
