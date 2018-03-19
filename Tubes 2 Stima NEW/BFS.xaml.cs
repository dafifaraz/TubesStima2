using System;

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
using System.Management;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Runtime.InteropServices;

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
        public static uint currentsp, Maxsp;
        public void CPUSpeed()
        {
            using (ManagementObject Mo = new ManagementObject("Win32_Processor.DeviceID='CPU0'"))
            {
                currentsp = (uint)(Mo["CurrentClockSpeed"]);
                Maxsp = (uint)(Mo["MaxClockSpeed"]);
            }
        }
        const int MAX_SEMESTER = 10;


        public struct _SemesterX
        {
            public int _X; //SEMESTER KE-X
            public List<string> _NamaMatKul; //NAMANYA, CONTOH "C1"
        }


    }
}
