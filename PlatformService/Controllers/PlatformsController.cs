using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepo _repository;
    private readonly IMapper _mapper;

    public PlatformsController(IPlatformRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    // GET: api/<PlatformsController>
    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        var platforms = _repository.GetAllPlatforms();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
    }

    // GET api/<PlatformsController>/5  
    [HttpGet("{id}", Name = "GetPlatformById")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
        var platform = _repository.GetPlatformsById(id);
        
        if(platform != null)
        {
            return Ok(_mapper.Map<PlatformReadDto>(platform));
        }
        return NotFound(); 
    }

    // POST api/<PlatformsController>
    [HttpPost]
    public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platform)
    {
        var platformModel = _mapper.Map<Platform>(platform);
        _repository.CreatePlatform(platformModel);
        _repository.SaveChanges();

        var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);
        return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id }, platformReadDto);
    }

    // PUT api/<PlatformsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<PlatformsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
