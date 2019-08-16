using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using OpalCard.Interfaces;
using OpalCard.Model;

namespace OpalCard.Classes {
    public class FileReader : IFileReader {
        
        public IEnumerable<OpalTicket> OpenFile (string csvPath) {
            if(csvPath == null || csvPath == String.Empty)
                throw new NullReferenceException();

            var list = new List<OpalTicket> ();
            using (var reader = new StreamReader (csvPath)) {
                var header = reader.ReadLine ();
                var quote = '"'; 
                var regex = $"(?:,?)((?<={quote})[^{quote}]+(?={quote})|[^{quote},]+)"; 

                while (!reader.EndOfStream) {
                    var line = reader.ReadLine ();
                    var values = Regex.Split (line, regex);
                    var opalTapOnTapOff = (values[3] != "nan") ? Int32.Parse (values[3].Replace (",", "")) : 0; 

                    list.Add (
                        new OpalTicket {
                            CardType = values[1],
                                OpalTapCount = opalTapOnTapOff,
                                Period = values[5],
                                TrainLine = values[7]
                        });
                }
                return list;
            }
        }
    }
}