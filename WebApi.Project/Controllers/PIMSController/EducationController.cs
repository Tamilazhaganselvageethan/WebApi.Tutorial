using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.PIMSModel;

namespace OnlineExamApi.Project.Controllers.PIMSController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationDetailController : ControllerBase
    {
       
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EducationDetailController(IMapper mapper, IUnitOfWork unitOfWork)
        {         
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EducationDetails>>> GetAll()
        {
            var education = await _unitOfWork.educationDetail.GetAll();

            _mapper.Map<List<EducationDetails>>(education);
            if (education == null)
            {
                return NoContent();
            }
            return Ok(education);
        }

        [HttpGet("{id:int}", Name = "GetEducation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EducationDetails>> GetById(int id)
        {
            var education = await _unitOfWork.educationDetail.Get(id);



            if (education == null)
            {

                return NoContent();
            }
            var countryDto = _mapper.Map<EducationDetails>(education);
            return Ok(countryDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EducationDetails>> Create(int id, [FromBody] EducationDetails educationDto)
        {
            if (id > 0)
            {
                var education = _mapper.Map<EducationDetails>(educationDto);

                await _unitOfWork.educationDetail.Update(education);
                return NoContent();


            }
            var educationDetail = _mapper.Map<EducationDetails>(educationDto);

            await _unitOfWork.educationDetail.Create(educationDetail);

            return CreatedAtRoute("GetEducation", new { id = educationDetail.degree_id }, educationDetail);
        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var education = await _unitOfWork.educationDetail.Get(id);
            if (education == null)
            {
                return NotFound();

            }
            await _unitOfWork.educationDetail.Delete(education);
            return NoContent();
        }
    }
}
