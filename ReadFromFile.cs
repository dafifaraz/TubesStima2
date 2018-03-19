//FILE ReadFromFile.cs
/* Digunakan untuk membaca input dari file bernama InputMataKuliah.txt
di folder yang sama dan memasukannya ke dalam bentukan list of list */

// INPUT    : FILE EKSTERNAL
// OUTPUT   : DARI FILE EKSTERNAL DIUBAH MENJADI LIST OF STRUCT YANG
//            BERANGGOTA STRING DAN LIST

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

//PEMBUATAN LIST MATKUL DENGAN TIPE BENTUKAN YANG MEMILIKI NAMA DAN PREREQUISITE
public struct MatKul {
    public string _NamaMatKul;
    public List<string> _PreRequisite;
}

namespace TUBES2 {

    class ReadFromFile {

        public static List<MatKul> ListMatKul = new List<MatKul>();

        static void Main(){

            Console.WriteLine();
            Console.WriteLine("Masukan nama file TANPA ekstensi (harus *.txt) : ");
            Console.Write("Input : ");string filename = Console.ReadLine();
            string text = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory() + (@"\") + filename + (@".txt") ));
            Console.WriteLine("PRINT TEKS DALAM FILE : ");
            System.Console.WriteLine(text);

            //MENGHITUNG BANYAKNYA MATKUL 
            int nMatKul = text.Length - text.Replace(".","").Length;
            Console.Write("Banyaknya Matkul : "); Console.WriteLine(nMatKul); //"Banyaknya Matkul : ", 
            Console.WriteLine();

            Console.WriteLine("PRINT SEMUA KODE KULIAH + PREREQUISITE : ");
            string[] lines = text.Split(); //',','.'

            //Pembuatan array dan memasukan data ke array
            int isComma = 0; int iComma = 0;
            int isDot = 0;
            int iMatKul = 0;

            //deklarasi array dan inisialisasi
            MatKul[] Array_MatKul = new MatKul[nMatKul];
            for (int i = 0; i < nMatKul; i++){
                Array_MatKul[i]._PreRequisite = new List<string>();
            }

            //entri data ke array
            foreach (string line in lines) 
            {
                //PRINT aja, buat validasi data
                System.Console.Write(Regex.Replace(line, @"\s", ""));

                //cek koma dan dot
                isComma = line.Length - line.Replace(",","").Length;
                if (isComma == 1){
                    iComma++;
                }
                isDot = line.Length - line.Replace(".","").Length;

                //memasukan matkul dan prerequisite
                if (isComma == 1 && iComma == 1){
                    Array_MatKul[iMatKul]._NamaMatKul = line.Replace(",","");
                }
                else if (isComma == 1 ){ //iComma > 1
                    Array_MatKul[iMatKul]._PreRequisite.Add(line.Replace(",",""));
                }
                else if (isDot == 1 && iComma > 0){ // Dot
                    Array_MatKul[iMatKul]._PreRequisite.Add(line.Replace(".",""));
                    //ArrayMatKul[iMatKul].MatKul._PreRequisite.Clear();
                    //ArrayMatKul[iMatKul].MatKul._NamaMatKul = "NULL";
                    iMatKul++;
                    iComma = 0;
                }
                else if (isDot == 1 && iComma == 0){
                    Array_MatKul[iMatKul]._NamaMatKul = line.Replace(".","");  
                    iMatKul++;
                    iComma = 0;                  
                }
                else {
                    //DO NOTHING
                }
                
            }
            Console.WriteLine();
            //SELESAI MEMBUAT ARRAY OF MATKUL DENGAN MATKUL MERUPAKAN TIPE BENTUKAN
            //YANG MEMILIKI NAMAMATKUL DAN PREREQUISITE
            

            //MEMBUAT LIST OF MATKUL, UNTUK MEMUDAHKAN BFS-DFS 
            //LIST BERASAL DARI ARRAY YANG DI PASS BY REFERENCE, JANGAN DIHAPUS ARRAYNYA
            for (int i = 0; i < nMatKul; i++){
                ListMatKul.Add(Array_MatKul[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Coba Cetak List Yuk!");
            Console.WriteLine("Format : <NomorList> : <MataKuliah> ->> <BanyakPR> : <NamaPR_untuk_MataKuliah>");
            for (int i = 0; i < ListMatKul.Count; i++){
                Console.Write(i); Console.Write(" : "); Console.Write(ListMatKul[i]._NamaMatKul);

                Console.Write("  ->>  ");Console.Write(ListMatKul[i]._PreRequisite.Count);
                Console.Write(" : ");
                foreach (string PR in ListMatKul[i]._PreRequisite){
                    Console.Write(PR);Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("Banyaknya MatKul : "); Console.Write(ListMatKul.Count);
           
            //Console.ReadKey();

            
            int pilihan_algoritma;
            string input;
            Console.WriteLine();
            Console.WriteLine("Pilih algoritma yang ingin digunakan");
            Console.WriteLine();
            Console.WriteLine("1 : BFS");
            Console.WriteLine("2 : DFS");

            Console.Write("Masukan Input : ");input = Console.ReadLine();
            pilihan_algoritma = Convert.ToInt32(input);
            //GA JADI : MEMBUAT DARI ListMatKul Menjadi ListClassMatKul;


            if (pilihan_algoritma == 1){
                //List<MatKul> ListMatKulBFS = new List<MatKul>(ListMatKul);
                BFS f1 = new BFS();
                Console.Write("Mengeluarkan Nol Jika Berhasil : ");Console.WriteLine(f1.kembalinol());
                f1.CariSolusi(ListMatKul);
            }
            else if (pilihan_algoritma == 2){
                //Kode Hafiz
            }
            else {
                //DO NOTHING
            }




        }

    }

}