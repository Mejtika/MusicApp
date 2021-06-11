using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Songs.GetChannelsReport;
using MusicApp.Songs.GetSong;
using MusicApp.Songs.GetYearsReport;
using Newtonsoft.Json;

namespace MusicApp
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SongsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSong(int id)
        {
            var result = await _mediator.Send(new GetSongQuery(id));
            return Ok(result);
        }

        [HttpGet("{id}/yearsReport")]
        public async Task<IActionResult> GetReportByYear(int id)
        {
            var result = await _mediator.Send(new GetYearsReportQuery(id));
            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpGet("{id}/channelsReport")]
        public async Task<IActionResult> GetReportByChannel(int id)
        {
            var result = await _mediator.Send(new GetChannelsReportQuery(id));
            return Ok(result);
        }
    }
}
