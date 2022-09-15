using Application.Features.GithubProfiles.Commands.CreateGithubProfile;
using Application.Features.GithubProfiles.Commands.DeleteGithubProfile;
using Application.Features.GithubProfiles.Commands.UpdateGithubProfile;
using Application.Features.GithubProfiles.Dtos;
using Application.Features.GithubProfiles.Models;
using Application.Features.GithubProfiles.Queries.GetListGithubProfile;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubProfilesController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody]  CreateGithubProfileCommand createGithubProfileCommand)
        {
            CreatedGithubProfileDto result = await Mediator.Send(createGithubProfileCommand);
            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteGithubProfileCommand deleteGithubProfileCommand)
        {
            DeletedGithubProfileDto deletedGithubProfileDto = await Mediator.Send(deleteGithubProfileCommand);
            return Ok(deletedGithubProfileDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGithubProfileCommand updateGithubProfileCommand)
        {
            UpdatedGithubProfileDto updatedGithubProfileDto = await Mediator.Send(updateGithubProfileCommand);
            return Ok(updatedGithubProfileDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListGithubProfileQuery getListGithubProfileQuery = new() { PageRequest = pageRequest };
            GithubProfileListModel result = await Mediator.Send(getListGithubProfileQuery);
            return Ok(result);
        }
    }
}
