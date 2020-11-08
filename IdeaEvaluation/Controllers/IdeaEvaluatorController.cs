using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeaEvaluation.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdeaEvaluation.Controllers
{
    [Route("api/Ideas")]
    public class IdeaEvaluatorController : ControllerBase
    {
        public readonly EvaluationService _evaluate;

        public IdeaEvaluatorController(EvaluationService evaluate)
        {
            _evaluate = evaluate;
        }
        [HttpPost]
        public IActionResult Post([FromBody] int userID)
        {
            var result = _evaluate.GetIdea(userID);
            return Ok(result);
        }
    }
}
