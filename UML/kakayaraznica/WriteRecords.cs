using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kakayaraznica
{
    public class WriteRecords
    {
        private static readonly string _file = "test.txt";
        public static async Task WriteRecordAsync(string str)
        {
            using (StreamWriter sw = new StreamWriter(_file, append: true))
            {
                await sw.WriteLineAsync(str);
            }
        }
        public static void WriteRecord(string str)
        {
            using (StreamWriter sw = new StreamWriter(_file, append: true))
            {
                sw.WriteLine(str);
            }
        }
    }
}
