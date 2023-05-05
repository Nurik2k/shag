using System.IO.MemoryMappedFiles;

string path = "D:/shag/SystemProgramming/HomeWorks/HW1/airports.json";


//using (var mmf = MemoryMappedFile.CreateFromFile(path, FileMode.Open))
//using (var stream = mmf.CreateViewStream())
//using (var reader = new StreamReader(stream))
//{
//    string line;

//    while ((line = reader.ReadLine()) != null)
//    {
//        // Обработка строки
//        Console.WriteLine(line);
//        Thread.Sleep(100);
//    }
//}

//using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
//using (var streamReader = new StreamReader(fileStream))
//{
//    string line;
//    while ((line = streamReader.ReadLine()) != null)
//    {
//        // Обработка строки
//        Console.WriteLine(line);
//        Thread.Sleep(100);
//    }
//}


