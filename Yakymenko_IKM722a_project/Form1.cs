using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Yakymenko_IKM722a_project
{
    public partial class Form1 : Form
    {
        private bool Mode;
        private MajorWork MajorObject; // Створення об'єкта класу MajorWork
        public Form1()
        {
            InitializeComponent();
        }

        private void tClock_Tick(object sender, EventArgs e)
        {
            tClock.Stop();
            MessageBox.Show("Минуло 25 секунд", "Увага");
            tClock.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MajorObject = new MajorWork();
            MajorObject.SetTime();
          
            About A = new About(); // створення форми About
            A.tAbout.Start();
            A.ShowDialog(); // відображення діалогового вікна About
            this.Mode = true;
           
        }

            private void bStart_Click(object sender, EventArgs e)
        {
            if (Mode)
            {
                tbInput.Enabled = true;// Режим дозволу введення
                tbInput.Focus();
                tClock.Start();
                bStart.Text = "Стоп"; // зміна тексту на кнопці на "Стоп"
                this.Mode = false;
                пускToolStripMenuItem.Text = "Стоп";

            }
            else
            {
                tbInput.Enabled = false;// Режим заборони введення
                tClock.Stop();
                bStart.Text = "Пуск";// зміна тексту на кнопці на "Пуск"
                this.Mode = true;
                MajorObject.Write(tbInput.Text);// Запис даних у об'єкт
                MajorObject.Task();// Обробка даних
                label1.Text = MajorObject.Read();// Відображення результату
                пускToolStripMenuItem.Text = "Старт";
            }
        }

              private void tbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            tClock.Stop();
            tClock.Start();
            if ((e.KeyChar >= '0') & (e.KeyChar <= '9') | (e.KeyChar == (char)8))
            {
                return;
            }
            else
            {
                tClock.Stop();
                MessageBox.Show("Неправильний символ", "Помилка");
                tClock.Start();
                e.KeyChar = (char)0;
            }
    
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
                string s;
                s = (System.DateTime.Now - MajorObject.GetTime()).ToString();
                MessageBox.Show(s, "Час роботи програми"); // Виведення часу роботи програми і повідомлення "Час роботи програми" на екран
            
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About A = new About();
            A.ShowDialog();
        }

        private void зберегтиЯкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdSave.ShowDialog() == DialogResult.OK)

{
                MessageBox.Show(sfdSave.FileName);
            }
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdOpen.ShowDialog() == DialogResult.OK) 

{
                MessageBox.Show(ofdOpen.FileName);
            }
        }

        private void проНакопичувачіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] disks = System.IO.Directory.GetLogicalDrives(); // Строковий масив з логічніх дисків
            string disk = "";
            for (int i = 0; i < disks.Length; i++)
            {
                try
                {
                    System.IO.DriveInfo D = new System.IO.DriveInfo(disks[i]);
                    int BytesInGigabytes = 1073741824;
                    disk += D.Name + "-" + (D.TotalSize / BytesInGigabytes).ToString() + "-" + (D.TotalFreeSpace / BytesInGigabytes).ToString()
                   + (char)13;// змінній присвоюється ім’я диска, загальна кількість місця и вільне місце на диску


                }
                catch
                {
                    disk += disks[i] + "- не готовий" + (char)13; // якщо пристрій не готовий, то виведення на екран ім’я пристрою і повідомлення «не готовий»

                }
            }
            MessageBox.Show(disk, "Накопичувачі");
        }
    }

}
