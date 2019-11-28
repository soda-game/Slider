using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SliderAction
{
    //CSV読み込み専用クラス
    class ReadCSV
    {
        static public List<int[]> Status(string csvPase) //CSVの要素を返す 引数で読み込むファイルを決める
        {
            //何行か分からないのでリスト化
            List<int[]> csvList = new List<int[]>();

            try
            {
                using (StreamReader wc = new StreamReader(@csvPase)) //ファイルを開く
                {
                    bool nameColumn = true;
                    while (!wc.EndOfStream) //末尾まで
                    {
                        string line = wc.ReadLine(); //1行読み込む
                        string[] elements = line.Split(','); //lineを , で分割して配列へ
                        if (nameColumn) {
                            nameColumn = false; continue; }

                        int[] e_int = elements.Select(int.Parse).ToArray(); //LINQでintに一斉変換
                        csvList.Add(e_int); //要素共をリストに リストのiで行数が取れる
                    }
                }
            }

            catch (Exception e) //失敗したときのエラーを受け取る
            {
                Console.WriteLine("CSVエラー:" + e.Message);
            }

            return csvList;
        }

        static public int[] Status(string csvPase, int sn) //読む行数が決まっている
        {
            //何行か分からないのでリスト化
            int[] csvList= { };

            try
            {
                using (StreamReader wc = new StreamReader(@csvPase))
                {
                    int nowRow = 0;
                    while (!wc.EndOfStream)
                    {
                        string line = wc.ReadLine();
                        if (nowRow < sn) { nowRow++; continue; }

                        string[] elements = line.Split(',');
                        csvList = elements.Select(int.Parse).ToArray();

                        break;
                    }
                }
            }

            catch (Exception e) //失敗したときのエラーを受け取る
            {
                Console.WriteLine("CSVエラー:" + e.Message);
            }

            return csvList;
        }

        static public List<int[]> Map(string csvPase)
        {
            List<int[]> csvList = new List<int[]>();

            try
            {
                using (StreamReader wc = new StreamReader(@csvPase))
                {
                    while (!wc.EndOfStream)
                    {
                        string line = wc.ReadLine();
                        string[] elements = line.Split(',');

                        int[] e_int = elements.Select(int.Parse).ToArray();
                        csvList.Add(e_int);
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
