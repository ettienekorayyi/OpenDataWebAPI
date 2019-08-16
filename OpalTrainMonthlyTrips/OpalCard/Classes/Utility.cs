using System;
using System.IO;

namespace OpalCard.Classes {
    public class Utility {
        public static string GetFileFromDirectory (string folderName = "OpalCard") {
            var relative = $@"\Visual Studio Code\C#\OpenDataWebAPI\OpalTrainMonthlyTrips\{folderName}\DataSet\";
            var filePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}{relative}";
            
            return Path.Combine(filePath, "OpalTrainMonthlyTrip.csv");
            
        }
    }
}