﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChipController : ControllerBase
    {
            private readonly ChipService _ChipService;

            public ChipController(ChipService ChipService)
            {
                _ChipService = ChipService;
            }

        [HttpPost("start")]
        public async Task<IActionResult> Start()
        {
            var chip = await _ChipService.CreateChipAsync();
            return Ok(chip);
        }

        [HttpGet]
        public async Task<ChipDto> Get()
        {
            var chip = new Chip();
            int chipCount = await _ChipService.GetChipCountAsync(chip);
            var dto = new ChipDto(chipCount);
            return dto;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChipDto dto)
        {
            var Chip = new Chip();
            await _ChipService.SetChipCountAsync(Chip, dto.ChipCount);
            return Ok();
        }

    }
}