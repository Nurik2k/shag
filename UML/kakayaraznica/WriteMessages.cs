using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kakayaraznica
{
    public class WriteMessages
    {
        public static void WriteMessage(string str, bool async)
        {
            if (async == true)
            {
                try
                {
                    _ = WriteRecords.WriteRecordAsync($"[message]\t{TimeForm.NowDateTime()}\t{str}");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"LoggerSingleton -> WriteMessageAsync: {ex.Message}");
                }
            }
            else
            {
                try
                {
                    WriteRecords.WriteRecord($"[message]\t{TimeForm.NowDateTime()}\t{str}");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"LoggerSingleton -> WriteMessage: {ex.Message}");
                }
            }
        }
    }
}
