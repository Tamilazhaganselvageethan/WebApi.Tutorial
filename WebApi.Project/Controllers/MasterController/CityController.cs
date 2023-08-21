using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CityController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CityDetail>>> GetAll()
        {
            var cities = await _unitOfWork.city.GetAll();

            _mapper.Map<List<CityDetail>>(cities);
            if (cities == null)
            {
                return NoContent();
            }
            return Ok(cities);
        }
        [HttpGet("{id:int}", Name = "GetCity")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CityDetail>> GetById(int id)
        {
            var cityName = await _unitOfWork.city.Get(id);


            if (cityName == null)
            {

                return NoContent();
            }
            var cityNameDto = _mapper.Map<CityDetail>(cityName);
            return Ok(cityNameDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CityDetail>> Create(int id, [FromBody] CityDetail cityDetailDto)
        {
            if (cityDetailDto.city_id > 0)
            {
                var city = _mapper.Map<CityDetail>(cityDetailDto);
                await _unitOfWork.city.Update(city);
                return NoContent();

            }
            var cityDetail = _mapper.Map<CityDetail>(cityDetailDto);

            await _unitOfWork.city.Create(cityDetail);

            return CreatedAtRoute("GetCity", new { id = cityDetail.city_id }, cityDetail);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var city = await _unitOfWork.city.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (city == null)
            {
                return NotFound();

            }
            await _unitOfWork.city.Delete(city);
            return NoContent();
        }
    }
}
