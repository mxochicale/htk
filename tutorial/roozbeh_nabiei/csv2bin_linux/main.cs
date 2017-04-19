
// The program reads a directory and converts all *.csv files into HTK format binary files
// by reading in the data as floats, converting to bytes, writing a header and then writing
// the data to a binary file *.csv.bin.

//James Rossiter

//http://blog.jamesrossiter.co.uk/2008/11/16/converting-csv-and-vector-data-to-native-htk-format-using-c/

// thanks to roozbeh_nabiei

// GNU-Linux compilation
//gmcs main.cs
//mono *.exe



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;


namespace CSV2BIN
{

    class Program
    {
        static void Main(string[] args)
        {

//           string[] dirNames = {"PourKettle", "AddMilk"};
//            foreach (string s in dirNames)
//		{
//		Console.WriteLine (s);
//		}


  // /home/map479-admin/hmm/htk/tutorial/roozbeh_nabiei/csv2bin_linux
  //string odir = @"/home/map479-admin/mxochicale/csharp/csv2bin/bin" + s + @"\";
  string bindir = @"/home/map479-admin/hmm/htk/tutorial/roozbeh_nabiei/csv2bin_linux/bin/";
  System.IO.Directory.CreateDirectory(bindir);

	string csvdir = @"/home/map479-admin/hmm/htk/tutorial/roozbeh_nabiei/csv2bin_linux/csvfiles/";
	DirectoryInfo di = new DirectoryInfo(csvdir);

        FileInfo[] rgFiles = di.GetFiles("*.csv");
        foreach (FileInfo fi in rgFiles)
        {
		      Console.WriteLine ( fi );

			using (TextReader tr = new StreamReader(fi.FullName))
			{

        string data = tr.ReadToEnd(); // data variable contains the characters of each csv file
        System.Text.ASCIIEncoding encoding=new System.Text.ASCIIEncoding();
        byte[] byteArray = encoding.GetBytes(data);


        string newdata = data.Replace(" ","");
        Regex pattern = new Regex("\r\n\\s?|\n\r\\s?|\n\\s?|\r\\s?");
        string[] plit = pattern.Split(newdata);




        int samples = plit.Length; //number of total samples per file
        if (plit[plit.Length - 1].Length < 1)
            samples--;
        //Console.WriteLine("samples {0:D}", samples);


        int itemspersample = plit[0].Split(',').Length; // number of rows
        //Console.WriteLine("itemspersample {0:D}",itemspersample);


        // now create binary data, each sample
        // (part of a line in the file)
        // has to be converted from
        // a float to a 4 byte array
        // and then joined to make one
        // large binary file

        byte[] bytedata = new byte[samples * itemspersample * 4];


        float[,] fldata = new float[samples, itemspersample];

        for (int i = 0; i < samples; i++)
        {
          for (int j = 0; j < itemspersample; j++)
          {
            string dd = plit[i].Split(',')[j];

            fldata[i, j] = (float)Convert.ToDouble(dd);

            byte[] temp = new byte[4];
            temp = BitConverter.GetBytes(fldata[i, j]);

            bytedata[(i * (itemspersample) * 4) + (j * 4)] = temp[3];
            bytedata[(i * (itemspersample) * 4) + (j * 4) + 1] = temp[2];
            bytedata[(i * (itemspersample) * 4) + (j * 4) + 2] = temp[1];
            bytedata[(i * (itemspersample) * 4) + (j * 4) + 3] = temp[0];


          }//for (int j = 0; j < itemspersample; j++)
        }//for (int i = 0; i < samples; i++)

        // now create HTK header 12 bytes long
       byte[] nSamples = BitConverter.GetBytes(samples);
       byte[] sampPeriod = BitConverter.GetBytes(200000); // 1/sampling-freq  in  100 nanosecond (now is 50hz)
       byte[] sampSize = BitConverter.GetBytes(Convert.ToInt16((itemspersample) * 4));
       byte[] parmKind = BitConverter.GetBytes(Convert.ToInt16(9));


       // using (BinaryWriter bw = new BinaryWriter(File.Open(fi.FullName + ".bin", FileMode.Create)))
    //   using (BinaryWriter bw = new BinaryWriter(File.Open(odir + fi.Name + ".bin", FileMode.Create)))
       using (BinaryWriter bw = new BinaryWriter(File.Open(bindir + fi.Name + ".bin", FileMode.Create)))
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

			}//using (TextReader tr = new StreamReader(fi.FullName))


	}//foreach (FileInfo fi in rgFiles)



	}//static void Main(string[] args)
   }//class Program



}//namespace CSV2BIN
