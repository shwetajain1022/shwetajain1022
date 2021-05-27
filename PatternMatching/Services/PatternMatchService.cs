using PatternMatching.DTO;
using PatternMatching.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace PatternMatching.Services
{
    public class PatternMatchService : IPatternMatchService
    {
        public PatternMatch GetTextStringPatternFromSubTextString(PatternMatch patternMatched)
        {

            string patternToMatch = Regex.Escape(patternMatched.SubText);
            Regex regularExpressionPattern = new Regex(patternToMatch,RegexOptions.IgnoreCase);
            var matchedPatternPositionList = new List<int>();
            var matchedPatternsInSubText = regularExpressionPattern.Matches(patternMatched.Text);
            for (int i = 0; i < matchedPatternsInSubText.Count; i++)
            {
               matchedPatternPositionList.Add(matchedPatternsInSubText[i].Index+1);                
            }            
            patternMatched.StartPositionOfMatchedPatternOccurences = matchedPatternPositionList;
           
            return patternMatched;
        }
    }
}