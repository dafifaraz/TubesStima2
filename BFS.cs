//FILE BFS.cs
/* Algoritma pencarian BFS */

// INPUT    : List of MatKul (Struct with String and List)
// OUTPUT   : Hasil Susunan Mata Kuliah

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Management;

namespace TUBES2 {
    class BFS{
        public static uint currentsp , Maxsp;
        public void CPUSpeed()
        {
            using(ManagementObject Mo = new ManagementObject("Win32_Processor.DeviceID='CPU0'"))
            {
                currentsp = (uint)(Mo["CurrentClockSpeed"]);
                Maxsp = (uint)(Mo["MaxClockSpeed"]);
            }
        }

        public BFS(){}

        //BUAT CEK AJA, ABAIKAN
        public int kembalinol(){
            return 0;
        }

        const int MAX_SEMESTER = 10;

        public struct _SemesterX {
            public int _X; //SEMESTER KE-X
            public List<string> _NamaMatKul; //NAMANYA, CONTOH "C1"
        }

        //public static List<int> _IndeksMatKulPreRequisiteNol = new List<int>();

        public void CariSolusi(List<MatKul> ListMatKulBFS){

            Console.WriteLine();
            Console.Write("CariSolusi : ");Console.WriteLine("START");
            long start_time = Stopwatch.GetTimestamp();

            List<int> Indeks_Terpilih = new List<int>();
            
            //DEKLARASI DAN INISIALISASI
            //List<string> MatKulTersisa = new List<string>();
            //int IndeksPreRequisite;
            _SemesterX[] Array_Semester = new _SemesterX[MAX_SEMESTER];
            for (int i_Semester = 0; i_Semester < MAX_SEMESTER; i_Semester++){
                Array_Semester[i_Semester]._NamaMatKul = new List<string>();
            }

            //PENCARIAN IndeksMinimal
            int iSemesterX = 0;
            //Console.Write("CountLMBFS : "); Console.WriteLine(ListMatKulBFS.Count);
            while (ListMatKulBFS.Count != 0 && iSemesterX < 10 ){
                //IndeksPreRequisite = 0;
                /* PROGRAM MENCARI MATKUL DENGAN PR NOL, 
                DIMASUKAN KEDALAM _IndeksMatKulPreRequisiteNol INDEKSNYA*/
                //Console.Write("PROSES SEMESTER : ");Console.WriteLine(iSemesterX);

                Array_Semester[iSemesterX]._X = iSemesterX;
                int i = 0;
                while (i < ListMatKulBFS.Count){
                    //NO EFFECT

                    //Console.Write(ListMatKulBFS[i]._NamaMatKul); Console.Write(" Count ");
                    //Console.Write(ListMatKulBFS[i]._PreRequisite.Count); Console.Write(" ");

                    // ^ menghasilkan CX Count X 
                    // v menghasilkan CX CX CX (PR)
                    //foreach (string PreRequisite in ListMatKulBFS[i]._PreRequisite){
                    //    Console.Write(PreRequisite); Console.Write(" ");
                    //}
                    //Console.WriteLine();
                    //NO EFFECT
                   
                    bool isPRExist = false;
                    string NM;
                    int i_check = 0;
                    while (!isPRExist && i_check < Array_Semester[iSemesterX]._NamaMatKul.Count){
                        NM = Array_Semester[iSemesterX]._NamaMatKul[i_check];
                        if ( String.Compare(NM,ListMatKulBFS[i]._NamaMatKul)==0 ){
                            isPRExist = true;
                        }
                        else {
                            i_check++;
                        }
                    }

                    if (ListMatKulBFS[i]._PreRequisite.Count == 0 && !isPRExist ){
                        Array_Semester[iSemesterX]._NamaMatKul.Add(ListMatKulBFS[i]._NamaMatKul);
                        Indeks_Terpilih.Add(i);
                    }
                    else {
                    }

                    i++;
                    //Console.WriteLine();
                }
                //SEMESTER X SELESAI DIAMBIL
                //MATKUL YANG PR NOL SUDAH DIHAPUS DAN MASUK SEMESTER X
                iSemesterX++;
                //Console.WriteLine();
                foreach(int _i in Indeks_Terpilih){
                    //Console.Write(_i);
                }
                //Console.Write(Indeks_Terpilih.Count);

                for (int _i = (Indeks_Terpilih.Count); _i > 0; _i--){
                    //Console.Write("DUMMY TEST");
                    //Console.WriteLine(_i-1);
                    for (int k = 0; k < ListMatKulBFS.Count; k++){
                        ListMatKulBFS[k]._PreRequisite.Remove(ListMatKulBFS[Indeks_Terpilih[_i-1]]._NamaMatKul);
                    }
                    ListMatKulBFS.RemoveAt(Indeks_Terpilih[_i-1]);
                }
                Indeks_Terpilih.Clear();
            }

            long stop_time = Stopwatch.GetTimestamp();
            long elapsed_time = stop_time - start_time;
            int NeffSemester = iSemesterX;
            iSemesterX = 0;
            Console.Write("CariSolusi : ");Console.WriteLine("END");
            Console.WriteLine();
            //Console.Write("Tick Elapsed ");Console.WriteLine(elapsed_time);
            //CPUSpeed();
            //double real_time = elapsed_time *1000000000 / Maxsp ;
            //Console.Write("CPU Hz ");Console.WriteLine(Maxsp);
            Console.Write("Actual Time (nano seconds) : ");Console.WriteLine(elapsed_time);
            Console.WriteLine();

            Console.WriteLine("SOLUSI : ");
            for(int i = 0; i < NeffSemester; i++){
                Console.Write("Semester ");Console.Write(Array_Semester[i]._X + 1);
                Console.Write(" -> ");
                for(int j = 0; j < Array_Semester[i]._NamaMatKul.Count; j++){

                    Console.Write(Array_Semester[i]._NamaMatKul[j]); Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("");
            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadKey();
        }
    }
}