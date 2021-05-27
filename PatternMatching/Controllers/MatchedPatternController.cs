using AutoMapper;
using PatternMatching.DTO;
using PatternMatching.Models;
using PatternMatching.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PatternMatching.Controllers
{
    [RoutePrefix("api/MatchedPattern")]
    public class MatchedPatternController : ApiController
    {
        private readonly IPatternMatchService _patternMatchService;
        private readonly IMapper _mapper;
        public MatchedPatternController(IPatternMatchService patternMatchService,IMapper mapper)
        {
            _patternMatchService = patternMatchService;
            _mapper = mapper;
        }

        [Route("GetMatchedPatternsList")]
        [HttpGet]
        public IHttpActionResult GetMatchedPatternsList([FromUri] PatternMatchDTO patternMatchedDTO)
        {
            try
            {
                 var matchedPatternResult = _patternMatchService.GetTextStringPatternFromSubTextString(_mapper.Map<Models.PatternMatch>(patternMatchedDTO));
                 return Ok(matchedPatternResult);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
