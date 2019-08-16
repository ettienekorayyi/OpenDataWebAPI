using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using OpalCard.Interfaces;
using OpalCard.Model;
using OpalCard.Classes;

namespace Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class OpalCardController : ControllerBase {
        private IFileReader _fileReader;
        
        public OpalCardController () { }

        public OpalCardController (IFileReader fileReader = null) { 
            _fileReader = fileReader ?? new FileReader();
        }

        [HttpGet]
        public ActionResult<IEnumerable<OpalTicket>> GetRecords () {
            var csvPath = @"C:\Users\Stephen\Documents\Visual Studio Code\C#\OpenDataWebAPI\OpalTrainMonthlyTrips\OpalCard\DataSet\OpalTrainMonthlyTrip.csv";
            var csvFile = _fileReader.OpenFile(csvPath);
            
            return csvFile.ToList();
        }

        
    }
}