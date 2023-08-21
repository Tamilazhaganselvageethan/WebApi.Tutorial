using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<QuestionDetail>>> GetAll()
        {
            var questionType = await _unitOfWork.questionRepository.GetAll();

            _mapper.Map<List<QuestionDetail>>(questionType);
            if (questionType == null)
            {
                return NoContent();
            }
            return Ok(questionType);
        }
        [HttpGet("{id:int}", Name = "GetQuestion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<QuestionDetail>> GetById(int id)
        {
            var questionType = await _unitOfWork.questionRepository.Get(id);

            if (questionType == null)
            {

                return NoContent();
            }
            var questionDto = _mapper.Map<QuestionDetail>(questionType);
            return Ok(questionDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<QuestionDetail>> Create(int id, [FromBody] QuestionDetail questionDto)
        {
            if (questionDto.QuestionTypeid > 0)
            {
                var question = _mapper.Map<QuestionDetail>(questionDto);
                await _unitOfWork.questionRepository.Update(question);
                return NoContent();

            }
            var quesionType = _mapper.Map<QuestionDetail>(questionDto);

            await _unitOfWork.questionRepository.Create(quesionType);

            return CreatedAtRoute("GetQuestion", new { id = quesionType.QuestionTypeid }, quesionType);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var questionType = await _unitOfWork.questionRepository.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (questionType == null)
            {
                return NotFound();

            }
            await _unitOfWork.questionRepository.Delete(questionType);
            return NoContent();
        }
    }
}
