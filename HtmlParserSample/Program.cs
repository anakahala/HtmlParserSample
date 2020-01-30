using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HtmlParserSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // htmlファイルを読み込む
            var html = File.ReadAllText("html_parser_sample.html", System.Text.Encoding.UTF8);

            // HTMLParserのインスタンス生成
            var parser = new HtmlParser();

            // htmlをパースする
            var doc = parser.ParseDocument(html);

            // idを指定してElement取得
            var idP = doc.GetElementById("id-p");
            Console.WriteLine("GetElementByIdを使って[id-p]の値取得 : {0}", idP.TextContent);

            // classを指定してElementを取得
            var classpList = doc.GetElementsByClassName("class-p");
            foreach (var c in classpList)
            {
                Console.WriteLine("GetElementsByClassNameを使って[class-p]の値取得 : {0}", c.TextContent);
            }

            // QuerySelectorAllでclassを指定してElementを取得
            var elements = doc.Body.QuerySelectorAll("p.class-p");
            foreach (var e in elements)
            {
                Console.WriteLine("QuerySelectorAllを使って[class-p]の値取得 : {0}", e.TextContent);
            }

            Console.ReadLine();
        }
    }
}
