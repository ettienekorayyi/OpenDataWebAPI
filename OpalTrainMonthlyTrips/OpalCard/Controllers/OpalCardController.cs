using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using OpalCard.Classes;
using Microsoft.AspNetCore.Mvc;
using OpalCard.Interfaces;
using OpalCard.Model;

namespace Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class OpalCardController : ControllerBase {
        private IFileReader _fileReader;
        
        public OpalCardController (IFileReader fileReader = null) { 
            _fileReader = fileReader ?? new FileReader();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<OpalTicket>> GetRecords () {
            // set file path OpalTicket
            var csvPath = @"C:\Users\Stephen\Documents\Visual Studio Code\C#\OpenDataWebAPI\OpalTrainMonthlyTrips\OpalCard\DataSet\OpalTrainMonthlyTrip.csv";
            var csvFile = _fileReader.OpenFile(csvPath);
            return csvFile.ToList();
        }

        // GET api/values/5
        /* [HttpGet ("{id}")]
        public ActionResult<string> Get (int id) {
            return "Opal";
        }

        // POST api/values
        [HttpPost]
        public void Post ([FromBody] string value) { }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }*/
    }
}