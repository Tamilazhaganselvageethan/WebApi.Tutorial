using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermanentCityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PermanentCityController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PermanentCityDetail>>> GetAll()
        {
            var permanentDetail = await _unitOfWork.permanentCity.GetAll();

            _mapper.Map<List<PermanentCityDetail>>(permanentDetail);
            if (permanentDetail == null)
            {
                return NoContent();
            }
            return Ok(permanentDetail);
        }

        [HttpGet("{id:int}", Name = "GetPermanent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PermanentCityDetail>> GetById(int id)
        {
            var permanentDetail = await _unitOfWork.permanentCity.Get(id);

            if (permanentDetail == null)
            {

                return NoContent();
            }
            var permanentDto = _mapper.Map<PermanentCityDetail>(permanentDetail);
            return Ok(permanentDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PermanentCityDetail>> Create(int id, [FromBody] PermanentCityDetail permanentDto)
        {
            if (permanentDto.cityid > 0)
            {
                var permanent = _mapper.Map<PermanentCityDetail>(permanentDto);
                await _unitOfWork.permanentCity.Update(permanent);
                return NoContent();

            }
            var permanentType = _mapper.Map<PermanentCityDetail>(permanentDto);

            await _unitOfWork.permanentCity.Create(permanentType);

            return CreatedAtRoute("GetPermanent", new { id = permanentType.cityid }, permanentType);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var permanentCity = await _unitOfWork.permanentCity.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (permanentCity == null)
            {
                return NotFound();

            }
            await _unitOfWork.permanentCity.Delete(permanentCity);
            return NoContent();
        }
    }
}
