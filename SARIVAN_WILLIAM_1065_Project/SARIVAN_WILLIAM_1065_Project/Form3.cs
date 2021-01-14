using SARIVAN_WILLIAM_1065_Project.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SARIVAN_WILLIAM_1065_Project
{
    public partial class Form3 : Form

    {

        private string connectionS = "Data Source=database2.db";

        private string query = "INSERT INTO USERSII(username,password,browserType,visitedWebsites,websiteCategory) VALUES " +
            "(@username,@password,@browserType,@visitedWebsites,@websiteCategory);";

      //  private string connection = "Data Source=database2.db";
        private gridView _users;

        List<User> users;

        public string createT = "CREATE TABLE USERSII(id INTEGER AUTO INCREMENT  ,username TEXT ,password TEXT ,browserType TEXT,visitedWebsites TEXT,websiteCategory TEXT )  ";
        public string delteT = "DROP TABLE USERSII;";
        public Form3()
        {
            users = new List<User>();
            _users = new gridView();

            using (SQLiteConnection creTa = new SQLiteConnection(connectionS))
            {
                creTa.Open();
                try
                {
                    SQLiteCommand delete = new SQLiteCommand(delteT, creTa);
                    int nustiu = delete.ExecuteNonQuery();
                }
                catch 
                {

                }
                finally
                {
                    SQLiteCommand comanda = new SQLiteCommand(createT, creTa);

                    int ceva = comanda.ExecuteNonQuery();
                }
            }





            InitializeComponent();
            comboBox1.Items.Add("Mozilla Firefox");
            comboBox1.Items.Add("Google Chrome");
            comboBox1.Items.Add("Internet Edge");
            comboBox1.Items.Add("Vivaldi");
            comboBox1.Items.Add("Brave");
            comboBox1.Items.Add("Safari");
            comboBox2.Items.Add("Gambling");
            comboBox2.Items.Add("Online Shop");
            comboBox2.Items.Add("Streaming services");
            comboBox2.Items.Add("News site");
            comboBox2.Items.Add("Entertaiment site");
            comboBox2.Items.Add("Paid services site");



        }

        public void ShowUsers()
        {
           // lvUsers.Items.Clear();
            
            foreach( User u in users)
            {
                ListViewItem item = new ListViewItem(u.UserName);
                item.SubItems.Add(u.Password);
                item.SubItems.Add(u.visitedWebsite);
                 item.SubItems.Add(u.usedBrowser);
                if(u.usedBrowser.Contains("Safari"))
               item.ImageKey = "safari.png";
               

                item.SubItems.Add(u.category);

               
              
               // lvUsers.Items.Add(item);
                
                

            }
            
        }


        private void btAddUser_Click(object sender, EventArgs e)
        {
            string user = tbUser.Text;
            string pass = tbPass.Text;
            string visited = tbVisitedWebsite.Text;
            string browser = comboBox1.Text;
            string type = comboBox2.Text;


            try
            {
               // User u = new User(user, pass, visited, browser, type);
                using (SQLiteConnection connection = new SQLiteConnection(connectionS))
                {
                    connection.Open();

                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@username", user);
                    command.Parameters.AddWithValue("@password", pass);
                    command.Parameters.AddWithValue("@browserType", browser);
                    command.Parameters.AddWithValue("@visitedWebsites", visited);
                    command.Parameters.AddWithValue("@websiteCategory", type);



                    int ceva = command.ExecuteNonQuery();
                    
                }

                //                users.Add(u);
                _users.AddUser();
     
                lbcCount.Text = _users._users.Count().ToString() + " logged users";
                tbUser.Clear();
                tbPass.Clear();
                tbVisitedWebsite.Clear();
                comboBox1.Text = "Please select a browser";
                comboBox2.Text = "Please select a category";
               // ShowUsers();


            }
            catch(InvalidPassword ex)
            {
                MessageBox.Show("INVALID PASSWORD");
            }
            catch(InvalidUserName ex)
            {
                MessageBox.Show("INVALID USERNAME");
            }


        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dvUsers.DataSource = _users._users;
            
            tbUser.DataBindings.Add("Text", _users, nameof(_users.Username));
            tbPass.DataBindings.Add("Text", _users, nameof(_users.Password));
            tbVisitedWebsite.DataBindings.Add("Text", _users, nameof(_users.Visited));
            comboBox1.DataBindings.Add("Text", _users, nameof(_users.Browser));
            comboBox2.DataBindings.Add("Text", _users, nameof(_users.Category));




        }

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = File.Create("serializedUsers.bin"))
            {
                formatter.Serialize(stream, _users._users);
            }
        }

        private void binaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = File.OpenRead("serializedUsers.bin"))
            {
              BindingList<User> proxy =(BindingList<User>)formatter.Deserialize(stream);
                foreach(User u in proxy)
                {
                    _users._users.Add(u);
                }
            }


        }

        private void createAReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = " Export TXT as";
            saveFileDialog.Filter = "TXT File | *.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine("UserName,Password,Visited Website,Used Browser,Website Category");
                    foreach (User u in _users._users)
                    {
                        writer.WriteLine($"{u.UserName},{u.Password},{u.visitedWebsite},{u.usedBrowser},{u.category}");
                    }
                }
            }
        }

        private void Tab(object sender, KeyPressEventArgs e)
        {
            MessageBox . Show("TabShortCut");
        }

        private void ceva(object sender, KeyPressEventArgs e)
        {

        }

        private void Tab(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                tbUser.Text = "AltASecretUser";
            if (e.KeyCode == Keys.Down)
                tbPass.Text = "AltASecretPassword";
        }

        private void toolStripButton1_Paint(object sender, PaintEventArgs e)
        {




            Graphics g = e.Graphics;

            Rectangle clipRectangle = e.ClipRectangle;

            int legendWidth = 150;

            float radius = Math.Min(clipRectangle.Height, clipRectangle.Width - legendWidth) / (float)2;

            int xCenter = (clipRectangle.Width - legendWidth) / 2;
            int yCenter = clipRectangle.Height / 2;


            float x = xCenter - radius;
            float y = yCenter - radius;

            float width = radius * 2;
            float height = radius * 2;

            float percent1 = 0;
            float percent2 = 0;
            

        }
    }
}
