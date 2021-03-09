using System;
using System.Collections.Generic;
using System.Linq;

namespace splendor.net5.core.tools.date
{
     public class Months
    {
        private static readonly List<Month> _spanishMonths = new()
        {
            new Month { Value = 1, Name = "ENERO"},
            new Month { Value = 2, Name = "FEBRERO"},
            new Month { Value = 3, Name = "MARZO"},
            new Month { Value = 4, Name = "ABRIL"},
            new Month { Value = 5, Name = "MAYO"},
            new Month { Value = 6, Name = "JUNIO"},
            new Month { Value = 7, Name = "JULIO"},
            new Month { Value = 8, Name = "AGOSTO"},
            new Month { Value = 9, Name = "SEPTIEMBRE"},
            new Month { Value = 10, Name = "OCTUBRE"},
            new Month { Value = 11, Name = "NOVIEMBRE"},
            new Month { Value = 12, Name = "DICIEMBRE"}
        };
        public static List<Month> SpanishMonths() 
        {
            return _spanishMonths;  
        }
        public static Month Month(int value, List<Month> cultureMonths = null)
        {
            cultureMonths ??= _spanishMonths;
            return cultureMonths.Where(m => m.Value == value).Single();
        }
    }
    
    public class Month
    {
        public short Value { get; set; }
        public string Name { get; set; }
    }
}