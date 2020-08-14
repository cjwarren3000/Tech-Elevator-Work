using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Capstone.Classes
{
    public class FileAccess 
    {
        

        string filePath = "C:\\Users\\Student\\team00-c-sharp-week04-pair-exercises\\18_Mini-Capstone";
        string filename = "cateringsystem.csv";
        string output = "Log.txt";

        public List<CateringItem> GetAndReadProductFile()
        {
            List<CateringItem> singleCateringItem = new List<CateringItem>();

            string fullPath = Path.Combine(filePath, filename);
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {

                        string unSplit = sr.ReadLine();
                        string[] split = unSplit.Split('|');

                        CateringItem temp = new CateringItem();
                        temp.Amount = 50;
                        temp.Code = split[0];
                        temp.Name = split[1];
                        temp.Price = double.Parse(split[2]);
                        temp.Type = split[3];
                        temp.TotalPrice = "";

                        singleCateringItem.Add(temp);
                    }
                }               
            }
            catch 
            {
                singleCateringItem = new List<CateringItem>();
            }

            return singleCateringItem;



        }

        public void WriteAuditLog1(double moneyAdded, double accountBalanceSum)
        {
            try
            {
                string outputPath = Path.Combine(filePath, output);

                File.AppendAllText(outputPath, DateTime.Now + " ADD MONEY: " + "$"+ moneyAdded + " $"+ accountBalanceSum + Environment.NewLine);
                

            }
            catch
            {

            }
        }

        
       public void WriteAuditLog2(double desiredAmount, string desiredID, string accountBalanceSum)
        {
            try
            {
                Catering newCatering = new Catering();
                string outputPath = Path.Combine(filePath, output);

                File.AppendAllText(outputPath, DateTime.Now + " " + desiredAmount.ToString() + " " + newCatering.GetCateringItem(desiredID).Name + " " + desiredID + " $" + (desiredAmount * newCatering.GetCateringItem(desiredID).Price) + " $" + accountBalanceSum + Environment.NewLine);
             
            }
            catch
            {

            }
        }
        public void WriteAuditLog3(double accountBalanceSum)
        {
            try
            {
                string outputPath = Path.Combine(filePath, output);
                File.AppendAllText(outputPath, DateTime.Now + " GIVE CHANGE: " + "$" + accountBalanceSum + " $0.00");
                
            }
            catch
            {

            }
        }



    }
}

