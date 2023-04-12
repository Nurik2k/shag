using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kakayaraznica
{
    public class WriteErrors
    {
        public static void WriteError(string str, bool async)
        {
            if (async == true)
            {
                try
                {
                    _ = WriteRecords.WriteRecordAsync($"[error]\t{TimeForm.NowDateTime()}\t{str}");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"LoggerSingleton -> WriteErrorAsync: {ex.Message}");
                }
            }
            else
            {
                try
                {
                    WriteRecords.WriteRecord($"[error]\t{TimeForm.NowDateTime()}\t{str}");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"LoggerSingleton -> WriteError: {ex.Message}");
                }
            }
        }
    }
}
