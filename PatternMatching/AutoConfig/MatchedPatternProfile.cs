using AutoMapper;
using PatternMatching.DTO;
using PatternMatching.Extensions;
using PatternMatching.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatternMatching.AutoConfig
{
    public class MatchedPatternProfile:Profile
    {
        public MatchedPatternProfile()
        {
            CreateMap<PatternMatchDTO, PatternMatch>().IgnoreNoMap();
        }
    }
}