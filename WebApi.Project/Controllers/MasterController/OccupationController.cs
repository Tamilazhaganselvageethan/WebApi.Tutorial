using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OccupationController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OccupationDetails>>> GetAll()
        {
            var occupations = await _unitOfWork.occupationDetail.GetAll();

            _mapper.Map<List<OccupationDetails>>(occupations);
            if (occupations == null)
            {
                return NoContent();
            }
            return Ok(occupations);
        }
        [HttpGet("{id:int}", Name = "GetOccupation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OccupationDetails>> GetById(int id)
        {
            var occupations = await _unitOfWork.occupationDetail.Get(id);

            if (occupations == null)
            {

                return NoContent();
            }
            var occupationDto = _mapper.Map<OccupationDetails>(occupations);
            return Ok(occupationDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OccupationDetails>> Create(int id, [FromBody] OccupationDetails occupationDto)
        {
            if (occupationDto.occupation_id > 0)
            {
                var occupation = _mapper.Map<OccupationDetails>(occupationDto);
                await _unitOfWork.occupationDetail.Update(occupation);
                return NoContent();

            }
            var occupationType = _mapper.Map<OccupationDetails>(occupationDto);

            await _unitOfWork.occupationDetail.Create(occupationType);

            return CreatedAtRoute("GetOccupation", new { id = occupationType.occupation_id }, occupationType);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var occupation = await _unitOfWork.occupationDetail.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (occupation == null)
            {
                return NotFound();

            }
            await _unitOfWork.occupationDetail.Delete(occupation);
            return NoContent();
        }
    }
}
