using System;
using System.IO;
using System.Collections.Generic;

namespace SleepData
{
    class Program
    {
        //This program is used to track sleep data
        static void Main(string[] args)
        {
            string[] dataSplit;// = phrase.Split(' ');
            var datesSlept= new List<string>();
            var hoursSlept= new List<string>();
              // ask for input
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit.");
            // input response
            string resp = Console.ReadLine();

            if (resp == "1")
            {
                 // create data file

                 // ask a question
                Console.WriteLine("How many weeks of data is needed?");
                // input the response (convert to int)
                int weeks = int.Parse(Console.ReadLine());

                // determine start and end date
                DateTime today = DateTime.Now;
                // we want full weeks sunday - saturday
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
                // subtract # of weeks from endDate to get startDate
                DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
                
                // random number generator
                Random rnd = new Random();

                // create file
                StreamWriter sw = new StreamWriter("data.txt");
                // loop for the desired # of weeks
                while (dataDate < dataEndDate)
                {
                    // 7 days in a week
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {
                        // generate random number of hours slept between 4-12 (inclusive)
                        hours[i] = rnd.Next(4, 13);
                    }
                    // M/d/yyyy,#|#|#|#|#|#|#
                    //Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                    sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)},");
                    // add 1 week to date
                    dataDate = dataDate.AddDays(7);
                }
                sw.Close();
            }
            else if (resp == "2")
            {
                // TODO: parse data file
                string toRead = File.ReadAllText("data.txt");
                dataSplit = toRead.Split(',');
                for(int i =0; i<dataSplit.Length-1;i++){
                    //Console.WriteLine(dataSplit[i]+" "+i);
                    if( (i+1) % 2==0){
                        hoursSlept.Add(dataSplit[i]);                        
                    }
                    else{
                        datesSlept.Add(dataSplit[i]);
                    }
                }
            //    for(int j=0; j<datesSlept.Count;j++){
            //    Console.WriteLine(datesSlept[j]);}

               for(int q=0; q<hoursSlept.Count;q++){
                   Console.WriteLine("Week of {0}",datesSlept[q]);
                   Console.WriteLine("Mo Tu We Th Fr Sa Su");
                   Console.WriteLine("-- -- -- -- -- -- --");
                   Console.WriteLine(hoursSlept[q]);

               }

            }
        }
    }
}
