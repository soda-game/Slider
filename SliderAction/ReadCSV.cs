using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SliderAction
{
    //CSV読み込み専用クラス
     class ReadCSV
    {
        static public List<int[]> ReadArray(string csvPase) //CSVの要素を返す 引数で読み込むファイルを決める
        {
            //何行か分からないのでリスト化
            List<int[]> csvList = new List<int[]>();

            try
            {
                using (StreamReader wc = new StreamReader(@csvPase)) //ファイルを開く
                {
                    while (!wc.EndOfStream) //末尾まで
                    {
                        string line = wc.ReadLine(); //1行読み込む
                        string[] elements = line.Split(','); //lineを , で分割して配列へ

                        int[] e_int = elements.Select(int.Parse).ToArray(); //LINQでintに一斉変換
                        csvList.Add(e_int); //要素共をリストに リストのiで行数が取れる
                    }
                }
            }

            catch (Exception e) //失敗したときのエラーを受け取る
            {
                Console.WriteLine("CSVエラー:"+e.Message);
            }

            return csvList;
        }

        static public List<int> ReadList(string csvPase) 
        {
            //Linqのために１行に
            List<int> csvList = new List<int>();

            try
            {
                using (StreamReader wc = new StreamReader(@csvPase)) 
                {
                    while (!wc.EndOfStream)
                    {
                        string line = wc.ReadLine();
                        string[] elements = line.Split(','); 
                        int[] e_int = elements.Select(int.Parse).ToArray(); 
                        
                        for(int i=0;i < e_int.Length;i++)
                        {
                            csvList.Add(e_int[i]);
                        }
                    }
                }
            }

            catch (Exception e)  
            {
                Console.WriteLine("CSVエラー:" + e.Message);
            }

            return csvList;
        }
    }
}
