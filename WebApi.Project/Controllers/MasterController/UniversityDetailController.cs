using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityDetailController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UniversityDetailController(IMapper mapper, IUnitOfWork unitOfWork)
        {
           
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UniversityDetail>>> GetAll()
        {
            var universityDetail = await _unitOfWork.universityDetail.GetAll();

            _mapper.Map<List<UniversityDetail>>(universityDetail);
            if (universityDetail == null)
            {
                return NoContent();
            }
            return Ok(universityDetail);
        }
        [HttpGet("{id:int}", Name = "GetUniversity")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UniversityDetail>> GetById(int id)
        {
            var universityName = await _unitOfWork.universityDetail.Get(id);

            if (universityName == null)
            {

                return NoContent();
            }
            var univerasityDto = _mapper.Map<UniversityDetail>(universityName);
            return Ok(univerasityDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UniversityDetail>> Create(int id, [FromBody] UniversityDetail universityNameDto)
        {
            if (universityNameDto.university_id > 0)
            {
                var university = _mapper.Map<UniversityDetail>(universityNameDto);
                await _unitOfWork.universityDetail.Update(university);
                return NoContent();

            }
            var UniversityName = _mapper.Map<UniversityDetail>(universityNameDto);

            await _unitOfWork.universityDetail.Create(UniversityName);

            return CreatedAtRoute("GetUniversity", new { id = UniversityName.university_id }, UniversityName);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var university = await _unitOfWork.universityDetail.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (university == null)
            {
                return NotFound();

            }
            await _unitOfWork.universityDetail.Delete(university);
            return NoContent();
        }
    }
}
