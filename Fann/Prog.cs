using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using FANNCSharp;
using FANNCSharp.Double;

namespace FANNCSharp.Double
{
    class Prog
    {
        static void Main(string[] args)
        {
            string frenchText = System.IO.File.ReadAllText(@"E:/french.txt");

            double[] frenchFrequencies = Frequencies(frenchText);


            string englishText = System.IO.File.ReadAllText(@"E:/english.txt");

            double[] englishFrequencies = Frequencies(englishText);


            string polishText = System.IO.File.ReadAllText(@"E:/polish.txt");

            double[] polishFrequencies = Frequencies(polishText);

            double[][] inputs = { frenchFrequencies, englishFrequencies, polishFrequencies };
            double[][] outputs = { new double[] { 1, 0, 0 }, new double[] { 0, 1, 0 }, new double[] { 0, 0, 1 } };

            List<uint> layers = new List<uint>();
            layers.Add(26);
            layers.Add(5);
            layers.Add(3);

            NeuralNet network = new NeuralNet(NetworkType.LAYER,layers);

            TrainingData data = new TrainingData();
            data.SetTrainData(inputs, outputs);

            network.TrainOnData(data, 3000, 100, 0.001f);

            Console.WriteLine("Final error : " + network.MSE);


            string testText = System.IO.File.ReadAllText(@"E:/testPolish.txt");

            double[] testFrequencies = Frequencies(testText);

            double[] result = network.Run(testFrequencies);

            Console.WriteLine("Output: " + result[0] + " " + result[1] + " " + result[2]);
        }

        static double[] Frequencies(string text)
        {
            text = new String(text.ToLowerInvariant().Where(Char.IsLetter).ToArray());
            text = text.Normalize(NormalizationForm.FormD);
            text = new string(text.Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray());

            double[] frequencies = new double[26];

            foreach (char c in text)
            {
                if (c - 'a' >= 0 && c - 'a' < frequencies.Length)
                    frequencies[c - 'a']++;
            }
            //System.Console.WriteLine("Frequencies");
            for (int i = 0; i < frequencies.Length; i++)
            {
                frequencies[i] /= text.Length;
                //System.Console.WriteLine(frenchFrequencies[i]);
            }
            return frequencies;
        }
    }
}
