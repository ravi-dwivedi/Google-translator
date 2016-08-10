using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using HtmlAgilityPack;


namespace Google_Translator_Example
{


    public class Translator
    {
        #region Properties

        /// <summary>
        /// Gets the supported languages.
        /// </summary>
        public static IEnumerable<string> Languages
        {
            get
            {
                Translator.EnsureInitialized();
                return Translator._languageModeMap.Keys.OrderBy(p => p);
            }
        }

        /// <summary>
        /// Gets the time taken to perform the translation.
        /// </summary>
        public TimeSpan TranslationTime
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the url used to speak the translation.
        /// </summary>
        /// <value>The url used to speak the translation.</value>
        public string TranslationSpeechUrl
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the error.
        /// </summary>
        public Exception Error
        {
            get;
            private set;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Translates the specified source text.
        /// </summary>
        /// <param name="sourceText">The source text.</param>
        /// <param name="sourceLanguage">The source language.</param>
        /// <param name="targetLanguage">The target language.</param>
        /// <returns>The translation.</returns>
        /// 
        public String Translate
            (string sourceText,
             string sourceLanguage,
             string targetLanguage)
        {

            string url = String.Format("http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair={1}", sourceText,
             Translator.LanguageEnumToIdentifier(sourceLanguage) + "|" +
                                           targetLanguage);
            WebClient webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.GetEncoding(Translator.LanguageEnumToIdentifier(targetLanguage));
            //webClient.Encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            //string result = webClient.DownloadString(url);
            webClient.DownloadFile(url, @"C:\Users\ravidwivedi\Desktop\1.html");
            //  Byte[] dataInBytes =  webClient.DownloadData(url);
            //System.IO.File.WriteAllText(@"C:\Users\ravidwivedi\Desktop\1.txt", result,Encoding.Unicode);
            // result = System.IO.File.ReadAllText(@"C:\Users\ravidwivedi\Desktop\1.html", Encoding.GetEncoding("Windows-1256"));
           // Byte[] content = File.ReadAllBytes((@"C:\Users\ravidwivedi\Desktop\1.html"));
           // File.WriteAllBytes(@"C:\Users\ravidwivedi\Desktop\2.html", content);
            //int startIndex = result.IndexOf("id=result_box");
            //int lastIndex = result.LastIndexOf("id=result_box");
            //result = result.Substring(result.IndexOf("id=result_box"), result.LastIndexOf("id=result_box"));
            //System.IO.File.WriteAllText(@"C:\Users\ravidwivedi\Desktop\1.html", result);
            string capture = "";
            var webGet = new HtmlWeb();
            var document = webGet.Load(@"C:\Users\ravidwivedi\Desktop\1.html");
            var output = document.DocumentNode.SelectSingleNode("//span[@id='result_box']");
            
              foreach(var nodes in output.ChildNodes)
              {
                  capture += nodes.InnerText;
              }




              //Regex r = new Regex(@"<span[^>].*?>([^<]*)</span>", RegexOptions.IgnoreCase);
              //foreach (Match matchedSpan in r.Matches(result))
              //{
              //    string span = matchedSpan.Groups[0].Value;
              //    if (span.Contains("result_box"))
              //    {
              //        capture = matchedSpan.Groups[1].Value;

              //        break;
              //    }
              //}


            // result = result.Substring(0, result.IndexOf("</span"));
            return capture;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Converts a language to its identifier.
        /// </summary>
        /// <param name="language">The language."</param>
        /// <returns>The identifier or <see cref="string.Empty"/> if none.</returns>
        private static string LanguageEnumToIdentifier
            (string language)
        {
            string mode = string.Empty;
            Translator.EnsureInitialized();
            Translator._languageModeMap.TryGetValue(language, out mode);
            return mode;
        }

        /// <summary>
        /// Ensures the translator has been initialized.
        /// </summary>
        private static void EnsureInitialized()
        {
            if (Translator._languageModeMap == null)
            {
                Translator._languageModeMap = new Dictionary<string, string>();

                Translator._languageModeMap.Add("cs", "iso-8859-2");
                Translator._languageModeMap.Add("ar", "Windows-1256");
                Translator._languageModeMap.Add("da", "iso-8859-1");
                Translator._languageModeMap.Add("de", "iso-8859-1");
                Translator._languageModeMap.Add("es", "iso-8859-1");
                Translator._languageModeMap.Add("fi", "iso-8859-1");
                Translator._languageModeMap.Add("fr", "iso-8859-2");
                Translator._languageModeMap.Add("he", "iso-8859-1");
                Translator._languageModeMap.Add("it", "iso-8859-1");
                Translator._languageModeMap.Add("ja", "Shift-JIS");
                Translator._languageModeMap.Add("ko", "EUC-KR");
                Translator._languageModeMap.Add("no", "iso-8859-1");
                Translator._languageModeMap.Add("iw", "windows-1255");
                Translator._languageModeMap.Add("nl", "iso-8859-1");
                Translator._languageModeMap.Add("pl", "windows-1250");
                Translator._languageModeMap.Add("pt", "iso-8859-1");
                Translator._languageModeMap.Add("ru", "Windows-1251");
                Translator._languageModeMap.Add("sk", "ISO-8859-2");
                Translator._languageModeMap.Add("sl", "iso-8859-2");
                Translator._languageModeMap.Add("sv", "iso-8859-2");
                Translator._languageModeMap.Add("tr", "iso-8859-2");
                Translator._languageModeMap.Add("lv", "iso-8859-2");
                //Translator._languageModeMap.Add("lv", "iso-8859-2");
                Translator._languageModeMap.Add("Afrikaans", "af");
                Translator._languageModeMap.Add("Albanian", "sq");
                Translator._languageModeMap.Add("Arabic", "ar");
                Translator._languageModeMap.Add("Armenian", "hy");
                Translator._languageModeMap.Add("Azerbaijani", "az");
                Translator._languageModeMap.Add("Basque", "eu");
                Translator._languageModeMap.Add("Belarusian", "be");
                Translator._languageModeMap.Add("Bengali", "bn");
                Translator._languageModeMap.Add("Bulgarian", "bg");
                Translator._languageModeMap.Add("Catalan", "ca");
                Translator._languageModeMap.Add("Chinese", "zh-CN");
                Translator._languageModeMap.Add("Croatian", "hr");
                Translator._languageModeMap.Add("Czech", "cs");
                Translator._languageModeMap.Add("Danish", "da");
                Translator._languageModeMap.Add("Dutch", "nl");
                Translator._languageModeMap.Add("English", "en");
                Translator._languageModeMap.Add("Esperanto", "eo");
                Translator._languageModeMap.Add("Estonian", "et");
                Translator._languageModeMap.Add("Filipino", "tl");
                Translator._languageModeMap.Add("Finnish", "fi");
                Translator._languageModeMap.Add("French", "fr");
                Translator._languageModeMap.Add("Galician", "gl");
                Translator._languageModeMap.Add("German", "de");
                Translator._languageModeMap.Add("Georgian", "ka");
                Translator._languageModeMap.Add("Greek", "el");
                Translator._languageModeMap.Add("Haitian Creole", "ht");
                Translator._languageModeMap.Add("Hebrew", "iw");
                Translator._languageModeMap.Add("Hindi", "hi");
                Translator._languageModeMap.Add("Hungarian", "hu");
                Translator._languageModeMap.Add("Icelandic", "is");
                Translator._languageModeMap.Add("Indonesian", "id");
                Translator._languageModeMap.Add("Irish", "ga");
                Translator._languageModeMap.Add("Italian", "it");
                Translator._languageModeMap.Add("Japanese", "ja");
                Translator._languageModeMap.Add("Korean", "ko");
                Translator._languageModeMap.Add("Lao", "lo");
                Translator._languageModeMap.Add("Latin", "la");
                Translator._languageModeMap.Add("Latvian", "lv");
                Translator._languageModeMap.Add("Lithuanian", "lt");
                Translator._languageModeMap.Add("Macedonian", "mk");
                Translator._languageModeMap.Add("Malay", "ms");
                Translator._languageModeMap.Add("Maltese", "mt");
                Translator._languageModeMap.Add("Norwegian", "no");
                Translator._languageModeMap.Add("Persian", "fa");
                Translator._languageModeMap.Add("Polish", "pl");
                Translator._languageModeMap.Add("Portuguese", "pt");
                Translator._languageModeMap.Add("Romanian", "ro");
                Translator._languageModeMap.Add("Russian", "ru");
                Translator._languageModeMap.Add("Serbian", "sr");
                Translator._languageModeMap.Add("Slovak", "sk");
                Translator._languageModeMap.Add("Slovenian", "sl");
                Translator._languageModeMap.Add("Spanish", "es");
                Translator._languageModeMap.Add("Swahili", "sw");
                Translator._languageModeMap.Add("Swedish", "sv");
                Translator._languageModeMap.Add("Tamil", "ta");
                Translator._languageModeMap.Add("Telugu", "te");
                Translator._languageModeMap.Add("Thai", "th");
                Translator._languageModeMap.Add("Turkish", "tr");
                Translator._languageModeMap.Add("Ukrainian", "uk");
                Translator._languageModeMap.Add("Urdu", "ur");
                Translator._languageModeMap.Add("Vietnamese", "vi");
                Translator._languageModeMap.Add("Welsh", "cy");
                Translator._languageModeMap.Add("Yiddish", "yi");
            }
        }

        #endregion

        #region Fields

        /// <summary>
        /// The language to translation mode map.
        /// </summary>
        private static Dictionary<string, string> _languageModeMap;

        #endregion
    }


    class Directory_Info
    {
        private System.IO.DirectoryInfo dir;
        private List<FileInfo> Files;
        public Directory_Info(string path)
        {
            dir = new System.IO.DirectoryInfo(@path);
            Files = new List<FileInfo>();
            foreach (FileInfo fi in this.dir.GetFiles())
            {
                Files.Add(fi);
            }
        }

        public IEnumerable<FileInfo> GetFiles()
        {
            foreach (FileInfo fi in Files)
            {
                yield return fi;
            }
        }

    }


    class Directory_Operations
    {
        IEnumerable<FileInfo> FileEnumerator;

        public Directory_Operations(string path)
        {
            Directory_Info dir = new Directory_Info(path);
            FileEnumerator = dir.GetFiles();
        }
        internal int getTotalFiles(string extension)
        {
            var a = from f in this.FileEnumerator
                    where f.Extension.ToLower() == "." + extension
                    select f;
            System.Console.WriteLine(" " + a.GetType());
            int count = 0;
            foreach (FileInfo fi in a)
            {
                ++count;
            }

            return count;
        }
        internal IEnumerable<IGrouping<string, FileInfo>> filesPerExtension()
        {
            var rows = from fe in this.FileEnumerator
                       group fe by fe.Extension into countANDextension
                       select countANDextension;

            IEnumerable<IGrouping<string, FileInfo>> resultSet = rows;
            return resultSet;
        }


        internal Dictionary<string, long> getAllFiles()
        {
            var rows = (from fe in this.FileEnumerator
                        orderby fe.Length descending
                        select new
                        {
                            Name = fe.Name,
                            Size = fe.Length
                        });
            Dictionary<string, long> d = new Dictionary<string, long>();
            foreach (var row in rows)
            {
                d.Add(row.Name, row.Size);
            }
            return d;
        }
    }

    class Program
    {


        static void Main(string[] args)
        {


            var a = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");

            Translator t = new Translator();
            //  String output =  t.Translate("This is ravi", "English", "Japanese");
            //Console.WriteLine(output);
            var abc = a.GetType();

            var abcd = TimeZoneInfo.GetSystemTimeZones().Where(z => z.DisplayName == "(GMT) Dublin, Edinburgh, Lisbon, London").FirstOrDefault().BaseUtcOffset;
            
            Directory_Operations dO = new Directory_Operations(@"C:\Users\ravidwivedi\Desktop\ItemBooking Resource\");

            String dataToEdit = System.IO.File.ReadAllText(@"C:\Users\ravidwivedi\Desktop\aaa.rtf", Encoding.Default);

            Regex r = new Regex(@"<value>([^<]*)</value>", RegexOptions.IgnoreCase);

            List<String> dToEdit = new List<string>();

            foreach (Match matchedSpan in r.Matches(dataToEdit))
            {

                dToEdit.Add(matchedSpan.Groups[1].Value);


            }


            foreach (String str in dToEdit)
            {

                //  String capture = "";
                Dictionary<string, long> resultDic = dO.getAllFiles();
                Console.WriteLine(str);

                foreach (var file in resultDic)
                {

                    string fileType = file.Key.Split('.', '-').GetValue(1).ToString();

                    string fileName = @"C:\Users\ravidwivedi\Desktop\ItemBooking Resource\" + file.Key;

                    if (fileType.CompareTo("nb") == 0)
                    {
                        fileType = "no";
                    }



                    if (fileType.CompareTo("he") == 0)
                    {
                        fileType = "iw";
                    }
                    String temp = str;
                    if (str.Contains('\\'))
                    {
                        temp = "";
                       String[] ss = str.Split('\\');
                      
                        for(int i=0;i<ss.Length;i++)
                        {
                            temp += ss[i];
                        }
                    }


                    String output = t.Translate(temp, "English", fileType);
                    //     capture += fileType + "          -          " + output + "<BR>";
                    Console.WriteLine(fileType + "  - " + output);
                    string tmp1 = "<value>" + temp + "</value>";

                    string tmp2 = "<value>" + output + "</value>";

                 File.WriteAllText(fileName, File.ReadAllText(fileName).Replace(tmp1, tmp2));
                }

                Console.WriteLine("-----------------------------------------");
            }
            //  System.IO.File.WriteAllText(@"C:\Users\ravidwivedi\Desktop\2.html", capture);


            Console.Read();
        }
    }
}
