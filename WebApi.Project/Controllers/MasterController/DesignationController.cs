using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DesignationController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DesignationGradeDetails>>> GetAll()
        {
            var designationGrade = await _unitOfWork.designationDetail.GetAll();

            _mapper.Map<List<DesignationGradeDetails>>(designationGrade);
            if (designationGrade == null)
            {
                return NoContent();
            }
            return Ok(designationGrade);
        }
        [HttpGet("{id:int}", Name = "GetDesignation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DesignationGradeDetails>> GetById(int id)
        {
            var designation = await _unitOfWork.designationDetail.Get(id);

            if (designation == null)
            {

                return NoContent();
            }
            var designationDto = _mapper.Map<DesignationGradeDetails>(designation);
            return Ok(designationDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DesignationGradeDetails>> Create(int id, [FromBody] DesignationGradeDetails designationGradeDto)
        {
            if (designationGradeDto.designation_grade_id > 0)
            {
                var designation = _mapper.Map<DesignationGradeDetails>(designationGradeDto);
                await _unitOfWork.designationDetail.Update(designation);
                return NoContent();

            }
            var designationGrade = _mapper.Map<DesignationGradeDetails>(designationGradeDto);

            await _unitOfWork.designationDetail.Create(designationGrade);

            return CreatedAtRoute("GetDesignation", new { id = designationGrade.designation_grade_id }, designationGrade);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var designation = await _unitOfWork.designationDetail.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (designation == null)
            {
                return NotFound();

            }
            await _unitOfWork.designationDetail.Delete(designation);
            return NoContent();
        }
    }
}
