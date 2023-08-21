using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemporaryCityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TemporaryCityController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TemporaryCityDetail>>> GetAll()
        {
            var temporaryCity = await _unitOfWork.temporaryCity.GetAll();

            _mapper.Map<List<TemporaryCityDetail>>(temporaryCity);
            if (temporaryCity == null)
            {
                return NoContent();
            }
            return Ok(temporaryCity);
        }
        [HttpGet("{id:int}", Name = "GetTemp")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TemporaryCityDetail>> GetById(int id)
        {
            var temporaryCity = await _unitOfWork.temporaryCity.Get(id);

            if (temporaryCity == null)
            {

                return NoContent();
            }
            var religionDto = _mapper.Map<TemporaryCityDetail>(temporaryCity);
            return Ok(religionDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TemporaryCityDetail>> Create(int id, [FromBody] TemporaryCityDetail temporaryCityDto)
        {
            if (temporaryCityDto.city_id > 0)
            {
                var tempCityName = _mapper.Map<TemporaryCityDetail>(temporaryCityDto);
                await _unitOfWork.temporaryCity.Update(tempCityName);
                return NoContent();

            }
            var tempCity = _mapper.Map<TemporaryCityDetail>(temporaryCityDto);

            await _unitOfWork.temporaryCity.Create(tempCity);

            return CreatedAtRoute("GetTemp", new { id = tempCity.city_id }, tempCity);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var tempCity = await _unitOfWork.temporaryCity.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (tempCity == null)
            {
                return NotFound();

            }
            await _unitOfWork.temporaryCity.Delete(tempCity);
            return NoContent();
        }
    }
}
