using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using SG.SwiftMatching.Models;
using SG.SwiftMatching.Utilities;

namespace SG.SwiftMatching.Web.App_Code
{
    public class Match
    {
        static Dictionary<string, string> mapping = new Dictionary<string, string>
        {
            {"20","ourRef"},
            {"82A","PartA"},
            {"87A","PartB"},
            {"77H","ISDADate"},
            {"30T","ContractDate"},
            {"30V","ValueDate"},
            {"36","ExchangeRate"},
            {"32B","WeBuy"},
            {"33B","WeSell"},
            {"56A","Intermed1"},
            {"56D","Intermed2"},
            {"57D","Settle2"},
            {"57A","Settle1"},
            {"58A","Ben1"},
            {"58D","Ben2"},
            
        };
        public static Message CodeMapper(Message message,string code,string value)
        {
            if (mapping.ContainsKey(code))
            message.GetType().GetProperty(mapping[code]).SetValue(message, value, null);
            return message;
        }
        public static Message ReadFile(string path)
        {
            var message = new Message();
            var allLines = File.ReadAllLines(path);
            using (StreamReader rdr = new StreamReader(path))
            {
                String line;
                while ((line = rdr.ReadLine()) != null)
                {
                    var arr = line.Split(':');
                    if(arr.Length>2)CodeMapper(message, arr[1], arr[2]);
                }
            }
            return message;
        }

        public static List<List<string>> MatchOperation(string path)
        {
            var message = new Message();
            var resultPair = new List<List<string>>();
            var clentData = ReadFile(path);
            var SGdataPath = Environment.CurrentDirectory+"\\Data\\SgProposedDataforSampleData\\";
            for (int i = 1; i < 18; i++)
            {
                var sgMessage = ReadFile(SGdataPath+(i).ToString()+"_message.txt");
                var result = MatchingEngine.Match(clentData, sgMessage);
                if (result == "Matched" || result == "Mismatch")
                {
                    resultPair.Add(
                        new List<string>{
                            sgMessage.ourRef,clentData.ourRef,result });
                }
            }
            return resultPair;
        }

        public static List<List<Message>> MatchOperationFullData(string path)
        {
            var message = new Message();
            var resultPair = new List<List<Message>>();
            var clentData = ReadFile(path);
            var SGdataPath = Environment.CurrentDirectory + "\\Data\\SgProposedDataforSampleData\\";
            for (int i = 1; i < 18; i++)
            {
                var sgMessage = ReadFile(SGdataPath + (i).ToString() + "_message.txt");
                var result = MatchingEngine.Match(clentData, sgMessage);
                if (result == "Matched" || result == "Mismatch")
                {
                    resultPair.Add(
                        new List<Message>{
                            sgMessage,clentData });
                }
            }
            return resultPair;
        }
    }
}
