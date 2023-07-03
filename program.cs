using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
    { 
        static void Main(string[] args)
        {
            // UC 1
            MoodAnalyser moodAnalyser1 = new MoodAnalyser();
            string result1 = moodAnalyser1.AnalyseMood("I am in Sad Mood");
            Console.WriteLine("UC 1: " + result1);  

            // UC 2
            MoodAnalyser moodAnalyser2 = new MoodAnalyser();
            string result2 = moodAnalyser2.AnalyseMood("I am in Any Mood");
            Console.WriteLine("UC 2: " + result2); 
            // UC 3
            MoodAnalyser moodAnalyser3 = new MoodAnalyser("I am in Sad Mood");
            string result3 = moodAnalyser3.AnalyseMood();
            Console.WriteLine("UC 3: " + result3);  

            // UC 4
            MoodAnalyser moodAnalyser4 = MoodAnalyserFactory.CreateMoodAnalyser();
            Console.WriteLine("UC 4: " + (moodAnalyser4 != null));  
            // UC 5
            MoodAnalyser moodAnalyser5 = MoodAnalyserFactory.CreateMoodAnalyser("I am in Happy Mood");
            Console.WriteLine("UC 5: " + (moodAnalyser5 != null));  

            // UC 6
            object result6 = MoodAnalyserReflector.InvokeMethodUsingReflector("AnalyseMood", "Happy");
            Console.WriteLine("UC 6: " + result6);  

            Console.ReadLine();
       }
    }
