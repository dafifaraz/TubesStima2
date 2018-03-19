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
    /// Interaction logic for BFS.xaml
    /// </summary>
    public partial class BFS : Window
    {
        public BFS()
        {
            InitializeComponent();
        }
        public struct MatKul
        {
            public string _NamaMatKul;
            public List<string> _PreRequisite;
        }

    }
}
