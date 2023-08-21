using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CollegeController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CollegeDetails>>> GetAll()
        {
            var college = await _unitOfWork.college.GetAll();

            _mapper.Map<List<CollegeDetails>>(college);
            if (college == null)
            {
                return NoContent();
            }
            return Ok(college);
        }
        [HttpGet("{id:int}", Name = "GetCollege")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CollegeDetails>> GetById(int id)
        {
            var college = await _unitOfWork.college.Get(id);
            if (college == null)
            {

                return NoContent();
            }
            var collegeDto = _mapper.Map<CollegeDetails>(college);
            return Ok(collegeDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CollegeDetails>> Create(int id, [FromBody] CollegeDetails collegeDetailDto)
        {
            if (collegeDetailDto.college_id > 0)
            {
                var college = _mapper.Map<CollegeDetails>(collegeDetailDto);
                await _unitOfWork.college.Update(college);
                return NoContent();

            }
            var collegeDetail = _mapper.Map<CollegeDetails>(collegeDetailDto);

            await _unitOfWork.college.Create(collegeDetail);

            return CreatedAtRoute("GetCollege", new { id = collegeDetail.college_id }, collegeDetail);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var college = await _unitOfWork.college.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (college == null)
            {
                return NotFound();

            }
            await _unitOfWork.college.Delete(college);
            return NoContent();
        }
    }
}
