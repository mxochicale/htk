using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dirNames = {"PourKettle", "AddMilk", "AddSugar", "AddTeabag", "FillKettle", "RemoveTeabag", "Stir", "ToyKettle", "Fulltrial", "ToyMilk"};
            foreach (string s in dirNames)
            {
                var d = @"C:\kaldi\AddMilk1\Data\Init1\bin\" + s + @"\";  // folder location

                if (!Directory.Exists(d))  // if it doesn't exist, create
                    Directory.CreateDirectory(d);

                // string dir = @"C:\Hedieh\mug data\fixed"; source
                string dir = @"C:\kaldi\AddMilk1\Data\Init1\" + s;
                // string dir = @"C:\CogWatch\orig-train\xls"; target
                string odir = @"C:\kaldi\AddMilk1\Data\Init1\bin\" + s + @"\";
                // string odir = @"C:\CogWatch\0-expt14\train\";

                DirectoryInfo di = new DirectoryInfo(dir);

                FileInfo[] rgFiles = di.GetFiles("*.csv");
                foreach (FileInfo fi in rgFiles)
                {
                    using (TextReader tr = new StreamReader(fi.FullName))
                    {
                        string data = tr.ReadToEnd();
                        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                        byte[] byteArray = encoding.GetBytes(data);

                        data = data.Replace(" ", "");
                        Regex pattern = new Regex("\r\n\\s?|\n\r\\s?|\n\\s?|\r\\s?");

                        string[] plit = pattern.Split(data);


                        //string middledata = data.Replace("\r\n", " ");
                        //string newdata = middledata.Replace('\n', ' ');

                        //string[] plit = newdata.Trim().Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries);

                        int samples = plit.Length;
                        if (plit[plit.Length - 1].Length < 1)
                            samples--;
                        int itemspersample = plit[0].Split(',').Length;

                        // now create binary data, each sample (part of a line in the file)
                        // has to be converted from a float to a 4 byte array and then joined to make one
                        // large binary file

                        byte[] bytedata = new byte[samples * (itemspersample) * 4];

                        // Signal processing
                        // Read the data into an array 'fldata'
                        float[] mean = new float[3];
                        float[] var = new float[3];
                        float[,] fldata = new float[samples, itemspersample];
                        for (int i = 0; i < samples; i++)
                        {
                            for (int j = 0; j < itemspersample; j++)
                            {
                                string dd = plit[i].Split(',')[j];
                                fldata[i, j] = (float)Convert.ToDouble(dd);
                            }
                        }


                        for (int i = 0; i < samples; i++)
                        {
                            for (int j = 0; j < itemspersample; j++)
                            {
                                // string dd = plit[i].Split(',')[j];
                                // float f = (float)Convert.ToDouble(dd);

                                byte[] temp = new byte[4];
                                temp = BitConverter.GetBytes(fldata[i, j]);

                                bytedata[(i * (itemspersample) * 4) + (j * 4)] = temp[3];
                                bytedata[(i * (itemspersample) * 4) + (j * 4) + 1] = temp[2];
                                bytedata[(i * (itemspersample) * 4) + (j * 4) + 2] = temp[1];
                                bytedata[(i * (itemspersample) * 4) + (j * 4) + 3] = temp[0];
                            }
                        }

                        // now create HTK header 12 bytes long
                        byte[] nSamples = BitConverter.GetBytes(samples);
                        byte[] sampPeriod = BitConverter.GetBytes(200000); // 1/sampling-freq  in  100 nanosecond (now is 50hz)
                        byte[] sampSize = BitConverter.GetBytes(Convert.ToInt16((itemspersample) * 4));
                        byte[] parmKind = BitConverter.GetBytes(Convert.ToInt16(9));

                        // using (BinaryWriter bw = new BinaryWriter(File.Open(fi.FullName + ".bin", FileMode.Create)))
                        using (BinaryWriter bw = new BinaryWriter(File.Open(odir + fi.Name + ".bin", FileMode.Create)))
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
                    }
                }
            }
        }
    }
}
