// The program reads a directory and converts all *.csv files into HTK format binary files
// by reading in the data as floats, converting to bytes, writing a header and then writing
// the data to a binary file *.csv.bin.

//James Rossiter
//http://blog.jamesrossiter.co.uk/2008/11/16/converting-csv-and-vector-data-to-native-htk-format-using-c/


static void Main(string[] args)
{
      string dir = @”G:PHD Nov 09# programsmatlab worktest”;
      DirectoryInfo di = new DirectoryInfo(dir);

      FileInfo[] rgFiles = di.GetFiles("*.csv");

      foreach (FileInfo fi in rgFiles)
      {
          using (TextReader tr = new StreamReader(fi.FullName))
          {
            string data = tr.ReadToEnd();
            System.Text.ASCIIEncoding encoding=new System.Text.ASCIIEncoding();
            byte[] byteArray = encoding.GetBytes(data);

            string newdata = data.Replace(‘n’,’ ‘);
            string[] plit = newdata.Trim().Split(‘ ‘);

            int samples = plit.Length;
            int itemspersample = plit[0].Split(‘,’).Length;

            // now create binary data, each sample (part of a line in the file)
            // has to be converted from a float to a 4 byte array and then joined to make one
            // large binary file

            byte[] bytedata = new byte[samples * itemspersample * 4];

            for (int i = 0; i < samples; i++)
              {
                for (int j = 0; j < itemspersample; j++)
                  {
                    string dd = plit[i].Split(‘,’)[j];
                    float f = (float)Convert.ToDouble(plit[i].Split(‘,’)[j]);

                    byte[] temp = new byte[4];
                    temp = BitConverter.GetBytes(f);

                    bytedata[(i * itemspersample * 4) + (j * 4)] = temp[3];
                    bytedata[(i * itemspersample * 4) + (j * 4) + 1] = temp[2];
                    bytedata[(i * itemspersample * 4) + (j * 4) + 2] = temp[1];
                    bytedata[(i * itemspersample * 4) + (j * 4) + 3] = temp[0];
                  }
                }


             // now create HTK header 12 bytes long
            byte[] nSamples = BitConverter.GetBytes(samples);
            byte[] sampPeriod = BitConverter.GetBytes(100000);
            byte[] sampSize = BitConverter.GetBytes(Convert.ToInt16(itemspersample * 4));
            byte[] parmKind = BitConverter.GetBytes(Convert.ToInt16(9));

            using (BinaryWriter bw = new BinaryWriter(File.Open(fi.FullName + “.bin”, FileMode.Create)))
            {
              Array.Reverse(nSamples);
              Array.Reverse(sampPeriod);
              Array.Reverse(sampSize);
              Array.Reverse(parmKind);
              bw.Write(nSamples);
              bw.Write(sampPeriod);
              bw.Write(sampSize);
              bw.Write(parmKind);
              bw.Write(bytedata);
            }
    } //using (TextReader tr = new StreamReader(fi.FullName))
  } //foreach (FileInfo fi in rgFiles)

}//static void Main(string[] args)
