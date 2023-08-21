using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemporaryCountryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TemporaryCountryController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TemporaryCountryDetail>>> GetAll()
        {
            var temporaryCountry = await _unitOfWork.temporaryCountry.GetAll();

            _mapper.Map<List<TemporaryCountryDetail>>(temporaryCountry);
            if (temporaryCountry == null)
            {
                return NoContent();
            }
            return Ok(temporaryCountry);
        }
        [HttpGet("{id:int}", Name = "GetTempCountry")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TemporaryCountryDetail>> GetById(int id)
        {
            var temporaryCountry = await _unitOfWork.temporaryCountry.Get(id);

            if (temporaryCountry == null)
            {

                return NoContent();
            }
            var tempCountryDto = _mapper.Map<TemporaryCountryDetail>(temporaryCountry);
            return Ok(tempCountryDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TemporaryCountryDetail>> Create(int id, [FromBody] TemporaryCountryDetail temporaryCountryDto)
        {
            if (temporaryCountryDto.Country_id > 0)
            {
                var tempCountry = _mapper.Map<TemporaryCountryDetail>(temporaryCountryDto);
                await _unitOfWork.temporaryCountry.Update(tempCountry);
                return NoContent();

            }
            var Country = _mapper.Map<TemporaryCountryDetail>(temporaryCountryDto);

            await _unitOfWork.temporaryCountry.Create(Country);

            return CreatedAtRoute("GetTempCountry", new { id = Country.Country_id }, Country);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var tempCountry = await _unitOfWork.temporaryCountry.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (tempCountry == null)
            {
                return NotFound();

            }
            await _unitOfWork.temporaryCountry.Delete(tempCountry);
            return NoContent();
        }
    }
}
