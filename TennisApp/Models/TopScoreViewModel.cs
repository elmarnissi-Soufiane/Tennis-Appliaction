using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TennisApp.Models
{
    public class TopScoreViewModel
    {
        public TopScoreViewModel() { }
        public string NomGagnant { get; set; }
        public string PrenomGagnant { get; set; }
        public string NomPerdant { get; set; }
        public string PrenomPerdant { get; set; }
        public string NomTournoi { get; set; }
        public DateTime DateTournoi { get; set; }
        public string Score { get; set; }
    }
}