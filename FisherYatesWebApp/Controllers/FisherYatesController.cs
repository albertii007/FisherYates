using FisherYates.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FisherYates.Controllers
{
    [Route("fisheryates")]
    public class FisherYatesController : Controller
    {
        private const char Separator = '-';
        private readonly IFisherYatesShuffleService _fisherYatesShuffleService;
        
        public FisherYatesController(IFisherYatesShuffleService  fisherYatesShuffleService)
        {
            _fisherYatesShuffleService = fisherYatesShuffleService ?? throw new ArgumentNullException(nameof(fisherYatesShuffleService));
        }
        
        /// <summary>
        /// todo: Add the skeleton structure for the solution, and implement unit tests (in the FisherYatesTests project)!
        /// </summary>
        /// <param name="input">List of dasherized elements to shuffle (e.g. "D-B-A-C").</param>
        /// <returns>A "200 OK" HTTP response with a content-type of `text/plain; charset=utf-8`. The content should be the dasherized output of the algorithm, e.g. "C-D-A-B".</returns>
        [HttpGet]
        public ActionResult Index(string input)
        {
            var elements = input.Split(Separator);
            
            var shuffled = _fisherYatesShuffleService.Shuffle(elements);

            return Content(string.Join(Separator, shuffled), "text/plain; charset=utf-8");
        }
    }
}