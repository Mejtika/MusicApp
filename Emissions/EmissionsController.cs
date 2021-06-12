using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MusicApp.MusicData;

namespace MusicApp.Emissions
{
    public class EmissionsController : ODataController
    {
        private readonly MusicDataDbContext _context;

        public EmissionsController(MusicDataDbContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_context.EmissionsView);
        }
    }
}
