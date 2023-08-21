using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.PIMSModel;

namespace OnlineExamApi.Project.Controllers.PIMSController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceDetailController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ExperienceDetailController(IMapper mapper, IUnitOfWork unitOfWork)
        {
           
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ExperienceDetails>>> GetAll()
        {
            var experience = await _unitOfWork.experienceDetail.GetAll();

            _mapper.Map<List<ExperienceDetails>>(experience);
            if (experience == null)
            {
                return NoContent();
            }
            return Ok(experience);
        }

        [HttpGet("{id:int}",Name = "Experience")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExperienceDetails>> GetById(int id)
        {
            var experience = await _unitOfWork.experienceDetail.Get(id);



            if (experience == null)
            {

                return NoContent();
            }
            var countryDto = _mapper.Map<ExperienceDetails>(experience);
            return Ok(countryDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ExperienceDetails>> Create(int id, [FromBody] ExperienceDetails experienceDto)
        {
            if (id > 0)
            {
                var experienceDetail = _mapper.Map<ExperienceDetails>(experienceDto);

                await _unitOfWork.experienceDetail.Update(experienceDetail);
                return NoContent();


            }

            var experience = _mapper.Map<ExperienceDetails>(experienceDto);

            await _unitOfWork.experienceDetail.Create(experience);

            return CreatedAtRoute("GetExperience", new { id = experience.experience_id }, experience);
        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int id)
        {
            var experience = await _unitOfWork.experienceDetail.Get(id);

            if (id == 0)
            {
                return BadRequest();
            }
            
            if (experience == null)
            {
                return NotFound();

            }
            await _unitOfWork.experienceDetail.Delete(experience);
            return NoContent();
        }
    }
}
