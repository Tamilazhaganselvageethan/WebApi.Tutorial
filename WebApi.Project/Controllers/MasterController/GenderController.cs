using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GenderController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GenderDetails>>> GetAll()
        {
            var genderDetail = await _unitOfWork.gender.GetAll();

            _mapper.Map<List<GenderDetails>>(genderDetail);
            if (genderDetail == null)
            {
                return NoContent();
            }
            return Ok(genderDetail);
        }
        [HttpGet("{id:int}", Name = "GetGender")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GenderDetails>> GetById(int id)
        {
            var genderType = await _unitOfWork.gender.Get(id);
            if (genderType == null)
            {

                return NoContent();
            }
            var genderDto = _mapper.Map<GenderDetails>(genderType);
            return Ok(genderDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GenderDetails>> Create(int id, [FromBody] GenderDetails genderDto)
        {
            if (genderDto.GenderId > 0)
            {
                var genderType = _mapper.Map<GenderDetails>(genderDto);
                await _unitOfWork.gender.Update(genderType);
                return NoContent();

            }
            var gender = _mapper.Map<GenderDetails>(genderDto);

            await _unitOfWork.gender.Create(gender);

            return CreatedAtRoute("GetGender", new { id = gender.GenderId }, gender);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var gender = await _unitOfWork.gender.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (gender == null)
            {
                return NotFound();

            }
            await _unitOfWork.gender.Delete(gender);
            return NoContent();
        }
    }
}
