using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeDetailController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GradeDetailController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GradeDetails>>> GetAll()
        {
            var gradeDetail = await _unitOfWork.gradeDetail.GetAll();

            _mapper.Map<List<GradeDetails>>(gradeDetail);
            if (gradeDetail == null)
            {
                return NoContent();
            }
            return Ok(gradeDetail);
        }
        [HttpGet("{id:int}", Name = "GetGrade")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GradeDetails>> GetById(int id)
        {
            var gradeDetail = await _unitOfWork.gradeDetail.Get(id);
            if (gradeDetail == null)
            {

                return NoContent();
            }
            var gradeDto = _mapper.Map<GradeDetails>(gradeDetail);
            return Ok(gradeDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GradeDetails>> Create(int id, [FromBody] GradeDetails gradeDto)
        {
            if (gradeDto.grade_id > 0)
            {
                var gradename = _mapper.Map<GradeDetails>(gradeDto);
                await _unitOfWork.gradeDetail.Update(gradename);
                return NoContent();

            }
            var grade = _mapper.Map<GradeDetails>(gradeDto);

            await _unitOfWork.gradeDetail.Create(grade);

            return CreatedAtRoute("GetGrade", new { id = grade.grade_id }, grade);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var grade = await _unitOfWork.gradeDetail.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (grade == null)
            {
                return NotFound();

            }
            await _unitOfWork.gradeDetail.Delete(grade);
            return NoContent();
        }
    }
}
