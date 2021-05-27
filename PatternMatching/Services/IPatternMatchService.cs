using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternMatching.DTO;
using PatternMatching.Models;
namespace PatternMatching.Services
{
    public interface IPatternMatchService
    {
         PatternMatch GetTextStringPatternFromSubTextString(PatternMatch patternMatched);
    }
}
