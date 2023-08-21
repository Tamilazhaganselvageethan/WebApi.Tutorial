using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamTypeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ExamTypeController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ExamDetails>>> GetAll()
        {
            var examType = await _unitOfWork.exam.GetAll();

            _mapper.Map<List<ExamDetails>>(examType);
            if (examType == null)
            {
                return NoContent();
            }
            return Ok(examType);
        }
        [HttpGet("{id:int}", Name = "GetExam")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExamDetails>> GetById(int id)
        {
            var examType = await _unitOfWork.exam.Get(id);
            if (examType == null)
            {

                return NoContent();
            }
            var examDto = _mapper.Map<ExamDetails>(examType);
            return Ok(examDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ExamDetails>> Create(int id, [FromBody] ExamDetails examTypeDto)
        {
            if (examTypeDto.ExamTypeid > 0)
            {
                var examType = _mapper.Map<ExamDetails>(examTypeDto);
                await _unitOfWork.exam.Update(examType);
                return NoContent();

            }
            var examDetail = _mapper.Map<ExamDetails>(examTypeDto);

            await _unitOfWork.exam.Create(examDetail);

            return CreatedAtRoute("GetExam", new { id = examDetail.ExamTypeid }, examDetail);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var examType = await _unitOfWork.exam.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (examType == null)
            {
                return NotFound();

            }
            await _unitOfWork.exam.Delete(examType);
            return NoContent();
        }
    }
}
