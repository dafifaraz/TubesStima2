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
        public Chooser()
        {
            InitializeComponent();
            textboxFile.Text = System.IO.File.ReadAllText(@MainWindow.filepath);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DFS dfs = new DFS();
            dfs.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BFS bfs = new BFS();
            bfs.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
