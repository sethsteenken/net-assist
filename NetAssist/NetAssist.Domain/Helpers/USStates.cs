using System;
using System.Collections.Generic;
using System.Linq;

namespace NetAssist.Domain
{
    public static class USUSStates
    {
        private static readonly List<USState> _states = new List<USState>
        {
            //us
            new USState("AL", "Alabama"),
            new USState("AK", "Alaska"),
            new USState("AZ", "Arizona"),
            new USState("AR", "Arkansas"),
            new USState("CA", "California"),
            new USState("CO", "Colorado"),
            new USState("CT", "Connecticut"),
            new USState("DE", "Delaware"),
            new USState("DC", "District Of Columbia"),
            new USState("FL", "Florida"),
            new USState("GA", "Georgia"),
            new USState("HI", "Hawaii"),
            new USState("ID", "Idaho"),
            new USState("IL", "Illinois"),
            new USState("IN", "Indiana"),
            new USState("IA", "Iowa"),
            new USState("KS", "Kansas"),
            new USState("KY", "Kentucky"),
            new USState("LA", "Louisiana"),
            new USState("ME", "Maine"),
            new USState("MD", "Maryland"),
            new USState("MA", "Massachusetts"),
            new USState("MI", "Michigan"),
            new USState("MN", "Minnesota"),
            new USState("MS", "Mississippi"),
            new USState("MO", "Missouri"),
            new USState("MT", "Montana"),
            new USState("NE", "Nebraska"),
            new USState("NV", "Nevada"),
            new USState("NH", "New Hampshire"),
            new USState("NJ", "New Jersey"),
            new USState("NM", "New Mexico"),
            new USState("NY", "New York"),
            new USState("NC", "North Carolina"),
            new USState("ND", "North Dakota"),
            new USState("OH", "Ohio"),
            new USState("OK", "Oklahoma"),
            new USState("OR", "Oregon"),
            new USState("PA", "Pennsylvania"),
            new USState("RI", "Rhode Island"),
            new USState("SC", "South Carolina"),
            new USState("SD", "South Dakota"),
            new USState("TN", "Tennessee"),
            new USState("TX", "Texas"),
            new USState("UT", "Utah"),
            new USState("VT", "Vermont"),
            new USState("VA", "Virginia"),
            new USState("WA", "Washington"),
            new USState("WV", "West Virginia"),
            new USState("WI", "Wisconsin"),
            new USState("WY", "Wyoming"),
            //canada
            new USState("AB", "Alberta"),
            new USState("BC", "British Columbia"),
            new USState("MB", "Manitoba"),
            new USState("NB", "New Brunswick"),
            new USState("NL", "Newfoundland and Labrador"),
            new USState("NS", "Nova Scotia"),
            new USState("NT", "Northwest Territories"),
            new USState("NU", "Nunavut"),
            new USState("ON", "Ontario"),
            new USState("PE", "Prince Edward Island"),
            new USState("QC", "Quebec"),
            new USState("SK", "Saskatchewan"),
            new USState("YT", "Yukon"),
        };

        public static IReadOnlyList<string> Abbreviations()
        {
            return _states.Select(s => s.Abbreviation).ToList();
        }

        public static IReadOnlyList<string> Names()
        {
            return _states.Select(s => s.Name).ToList();
        }

        public static string GetName(string abbreviation)
        {
            return _states.Where(s => s.Abbreviation.Equals(abbreviation, StringComparison.CurrentCultureIgnoreCase)).Select(s => s.Name).FirstOrDefault();
        }

        public static string GetAbbreviation(string name)
        {
            return _states.Where(s => s.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).Select(s => s.Abbreviation).FirstOrDefault();
        }

        public static IReadOnlyList<USState> ToList()
        {
            return _states;
        }

        public static IReadOnlyList<SelectItem> ToSelectionList()
        {
            return ToSelectionList(useAbbr: false);
        }

        public static List<SelectItem> ToSelectionList(bool useAbbr)
        {
            return _states.Select(x => new SelectItem(useAbbr ? x.Abbreviation : x.Name)).ToList();
        }
    }
}
