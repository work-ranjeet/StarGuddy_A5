using Microsoft.AspNetCore.Mvc;
using StarGuddy.Business.Interface.Search;
using StarGuddy.Business.Interface.UserJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarGuddy.Api.Controllers.Search
{
   
    [Route("api/Search")]
    [Produces("application/json")]
    public class SearchController : BaseApiController
    {

        private readonly ISearchManager _searchManager;

        public SearchController(ISearchManager searchManager)
        {
            _searchManager = searchManager;
        }

        [HttpGet]
        [Route("TalentGroups")]
        public async Task<IActionResult> GetTalentGroups()
        {
            var result = await _searchManager.GetUserGobGroup();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
