void ustvariFile(){

            string filePath =Application.persistentDataPath + "/Data";
            if (!Directory.Exists(filePath))
             {
                 Directory.CreateDirectory(filePath);
             }


    if (!System.IO.File.Exists(Application.persistentDataPath + "/Data/izbira2.txt"))
    {
         string path = Application.persistentDataPath + "/Data/izbira2.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        stream.Close();
        string vpis = "{\"score\":0}";
        StreamWriter writer = new StreamWriter(path, true);
        writer.Write(vpis);
        writer.Close();
    }
 
  

if (!System.IO.File.Exists(Application.persistentDataPath + "/Data/izbira2.txt"))
    {
        string path2 = Application.persistentDataPath + "/Data/limitData2.txt";
        FileStream stream2 = new FileStream(path2, FileMode.Create);
        stream2.Close();
        string vpis2 = "{\"limit\":0,\"limitOnStart\":100}";
        StreamWriter writer2 = new StreamWriter(path2, true);
        writer2.Write(vpis2);
        writer2.Close();

    }


    }
