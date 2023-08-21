using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityDetailsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CityDetailsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CityDetails>>> GetAll()
        {
            var cities = await _unitOfWork.cityDetail.GetAll();

            _mapper.Map<List<CityDetails>>(cities);
            if (cities == null)
            {
                return NoContent();
            }
            return Ok(cities);
        }
        [HttpGet("{id:int}", Name = "GetCities")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CityDetails>> GetById(int id)
        {
            var cities = await _unitOfWork.cityDetail.Get(id);


            if (cities == null)
            {

                return NoContent();
            }
            var cityDto = _mapper.Map<CityDetails>(cities);
            return Ok(cityDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CityDetails>> Create(int id, [FromBody] CityDetails cityDetailDto)
        {
            if (cityDetailDto.cityid > 0)
            {
                var cities = _mapper.Map<CityDetails>(cityDetailDto);
                await _unitOfWork.cityDetail.Update(cities);
                return NoContent();

            }
            var cityDetail = _mapper.Map<CityDetails>(cityDetailDto);

            await _unitOfWork.cityDetail.Create(cityDetail);

            return CreatedAtRoute("GetCities", new { id = cityDetail.cityid }, cityDetail);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var city = await _unitOfWork.cityDetail.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (city == null)
            {
                return NotFound();

            }
            await _unitOfWork.cityDetail.Delete(city);
            return NoContent();
        }
    }
}
