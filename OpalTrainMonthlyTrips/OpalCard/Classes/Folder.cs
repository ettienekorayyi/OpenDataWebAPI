using System;
using System.IO;
using OpalCard.Interfaces ;

namespace OpalCard.Classes {
    public class Folder : IFolder {
        public string GetFolderPath (string folderName = "OpalCard") {
            var relative = $@"\Visual Studio Code\C#\OpenDataWebAPI\OpalTrainMonthlyTrips\{folderName}\DataSet\";
            var filePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}{relative}";
            
            return Path.Combine(filePath, "OpalTrainMonthlyTrip.csv");
            
        }
    }
}