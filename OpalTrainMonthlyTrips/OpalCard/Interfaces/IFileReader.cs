using System.Collections.Generic;
using OpalCard.Model;

namespace OpalCard.Interfaces { 
    public interface IFileReader {
        IEnumerable<OpalTicket> OpenFile (string csvPath);
    }
}