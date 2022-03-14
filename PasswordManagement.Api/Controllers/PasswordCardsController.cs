using Microsoft.AspNetCore.Mvc;
using PasswordManagement.Api.Dtos;
using PasswordManagement.Api.Models;
using PasswordManagement.Api.Resources;
using PasswordManagement.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PasswordManagement.Api.Controllers
{
    [Route("api/password-card")]
    [ApiController]
    public class PasswordCardsController : ControllerBase
    {
        private readonly IPasswordCardService _passwordCardService;
        private readonly IApiErrorResources _apiErrorResources;
        public PasswordCardsController(IPasswordCardService passwordCardService, IApiErrorResources apiErrorResources)
        {
            _passwordCardService = passwordCardService;
            _apiErrorResources = apiErrorResources;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<PasswordCard>>> Get(string name)
        {
            var passwordCardsDto = await _passwordCardService.GetPasswordCardsAsync(name);
        
            return Ok(passwordCardsDto);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody]PasswordCardDto passwordCardDto)
        {
            if (!passwordCardDto.Id.Equals(default))
            {
                return BadRequest(_apiErrorResources.CannotSetId());
            }

            var id = await _passwordCardService.AddPasswordCardAsync(passwordCardDto);
            passwordCardDto.Id = id;

            return CreatedAtAction(nameof(Get), new { id }, passwordCardDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PasswordCardDto passwordCardDto)
        {
            await _passwordCardService.GetPasswordCardAsync(passwordCardDto.Id);

            await _passwordCardService.UpdatePasswordCardAsync(passwordCardDto);

            return Ok();
        }
    }
}
