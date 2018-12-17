using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using ATL.AudioData;
using ATL;

namespace deflac
{
    class Program
    {
        static void Main(string[] args)
        {
	    string lamePath = @"D:\Program Files (x86)\FlacSquisher\lame.exe";
            string path = ".";
            if (args.Length == 1)
            {
                path = args[0];
            }//
            var files = Directory.GetFiles(path, "*.flac", SearchOption.TopDirectoryOnly);

            foreach(var file in files)
            {
                Track t = new Track(file);

                string inputFile = "\""+file+"\"";
                string outputFile = inputFile.Replace(".flac", ".mp3");
                string programArgs = "-b 320 --add-id3v2 --tt \"" + t.Title + "\" --ta \"" + t.Artist +
                    "\" --tl \"" + t.Album + "\" --tn \"" + t.TrackNumber + "\" --tg \"" + t.Genre + "\" --ty " + t.Year + " " + inputFile + " " + outputFile;

                Process.Start(lamePath , programArgs);

            }//foreach
        }
    }
}
