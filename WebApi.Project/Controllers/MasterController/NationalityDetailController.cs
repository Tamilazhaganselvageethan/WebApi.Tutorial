using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalityDetailController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public NationalityDetailController (IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<NationalityDetails>>> GetAll()
        {
            var nationality = await _unitOfWork.nationalityRepository.GetAll();

            _mapper.Map<List<NationalityDetails>>(nationality);
            if (nationality == null)
            {
                return NoContent();
            }
            return Ok(nationality);
        }
        [HttpGet("{id:int}", Name = "GetNation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<NationalityDetails>> GetById(int id)
        {
            var nationality = await _unitOfWork.nationalityRepository.Get(id);

            if (nationality == null)
            {

                return NoContent();
            }
            var nationalDto = _mapper.Map<NationalityDetails>(nationality);
            return Ok(nationalDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NationalityDetails>> Create(int id, [FromBody] NationalityDetails nationalityDto)
        {
            if (nationalityDto.nationalityid > 0)
            {
                var nationality = _mapper.Map<NationalityDetails>(nationalityDto);
                await _unitOfWork.nationalityRepository.Update(nationality);
                return NoContent();

            }
            var national = _mapper.Map<NationalityDetails>(nationalityDto);

            await _unitOfWork.nationalityRepository.Create(national);

            return CreatedAtRoute("GetNation", new { id = national.nationalityid }, national);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var national = await _unitOfWork.nationalityRepository.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (national == null)
            {
                return NotFound();

            }
            await _unitOfWork.nationalityRepository.Delete(national);
            return NoContent();
        }
    }
}
