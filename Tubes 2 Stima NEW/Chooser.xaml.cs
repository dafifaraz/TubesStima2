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
using System.Windows.Shapes;

namespace Tubes_2_Stima_NEW
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Chooser : Window
    {
        public struct MatKul
        {
            public string _NamaMatKul;
            public List<string> _PreRequisite;
        }

        //variables
        public static int input;
        public static List<MatKul> ListMatKul;
        public static int nMatKul;
        MatKul[] Array_MatKul;
        
        public int GetCount(List<MatKul> l)
        {
            return l.Count;
        }
        public Chooser()
        {
            InitializeComponent();
            textboxFile.Text = System.IO.File.ReadAllText(@MainWindow.filepath);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            input = 1;
            DFS dfs = new DFS();
            dfs.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            input = 2;
            BFS bfs = new BFS();
            bfs.Show();
            this.Close();
        }

        public void ReadFromFile() //Implementasi dari ReadFromFile.cs
        {
            ListMatKul = new List<MatKul>();
            string text = MainWindow.filepath;
            nMatKul = text.Length - text.Replace(".", "").Length;
            string[] lines = text.Split();
            int isComma = 0; int iComma = 0;
            int isDot = 0;
            int iMatKul = 0;
            Array_MatKul = new MatKul[nMatKul];
            for (int i = 0; i < nMatKul; i++)
            {
                Array_MatKul[i]._PreRequisite = new List<string>();
            }
            foreach (string line in lines)
            {
                //cek koma dan dot
                isComma = line.Length - line.Replace(",", "").Length;
                if (isComma == 1)
                {
                    iComma++;
                }
                isDot = line.Length - line.Replace(".", "").Length;

                //memasukan matkul dan prerequisite
                if (isComma == 1 && iComma == 1)
                {
                    Array_MatKul[iMatKul]._NamaMatKul = line.Replace(",", "");
                }
                else if (isComma == 1)
                { //iComma > 1
                    Array_MatKul[iMatKul]._PreRequisite.Add(line.Replace(",", ""));
                }
                else if (isDot == 1 && iComma > 0)
                { // Dot
                    Array_MatKul[iMatKul]._PreRequisite.Add(line.Replace(".", ""));
                    //ArrayMatKul[iMatKul].MatKul._PreRequisite.Clear();
                    //ArrayMatKul[iMatKul].MatKul._NamaMatKul = "NULL";
                    iMatKul++;
                    iComma = 0;
                }
                else if (isDot == 1 && iComma == 0)
                {
                    Array_MatKul[iMatKul]._NamaMatKul = line.Replace(".", "");
                    iMatKul++;
                    iComma = 0;
                }
                else
                {
                    //DO NOTHING
                }

                //MEMBUAT LIST OF MATKUL, UNTUK MEMUDAHKAN BFS-DFS 
                //LIST BERASAL DARI ARRAY YANG DI PASS BY REFERENCE, JANGAN DIHAPUS ARRAYNYA
                for (int i = 0; i < nMatKul; i++)
                {
                    ListMatKul.Add(Array_MatKul[i]);
                }



            }
        }
    }
}
