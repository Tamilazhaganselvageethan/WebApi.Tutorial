using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermanentCountryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PermanentCountryController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PermanentCountryDetail>>> GetAll()
        {
            var permanentCountry = await _unitOfWork.permanentCountry.GetAll();

            _mapper.Map<List<PermanentCountryDetail>>(permanentCountry);
            if (permanentCountry == null)
            {
                return NoContent();
            }
            return Ok(permanentCountry);
        }
        [HttpGet("{id:int}", Name = "GetCountry")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PermanentCountryDetail>> GetById(int id)
        {
            var permanentDetail = await _unitOfWork.permanentCountry.Get(id);

            if (permanentDetail == null)
            {

                return NoContent();
            }
            var permanentDto = _mapper.Map<PermanentCountryDetail>(permanentDetail);
            return Ok(permanentDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PermanentCountryDetail>> Create(int id, [FromBody] PermanentCountryDetail permanentDto)
        {
            if (permanentDto.countryid > 0)
            {
                var permCountry = _mapper.Map<PermanentCountryDetail>(permanentDto);
                await _unitOfWork.permanentCountry.Update(permCountry);
                return NoContent();

            }
            var permanentCountry = _mapper.Map<PermanentCountryDetail>(permanentDto);

            await _unitOfWork.permanentCountry.Create(permanentCountry);

            return CreatedAtRoute("GetCountry", new { id = permanentCountry.countryid }, permanentCountry);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var permanentCountry = await _unitOfWork.permanentCountry.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (permanentCountry == null)
            {
                return NotFound();

            }
            await _unitOfWork.permanentCountry.Delete(permanentCountry);
            return NoContent();
        }
    }
}
