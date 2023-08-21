using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceRoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ExperienceRoleController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ExperienceRoleDetails>>> GetAll()
        {
            var experienceRole = await _unitOfWork.experienceRole.GetAll();

            _mapper.Map<List<ExperienceRoleDetails>>(experienceRole);
            if (experienceRole == null)
            {
                return NoContent();
            }
            return Ok(experienceRole);
        }
        [HttpGet("{id:int}", Name = "GetExperience")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExperienceRoleDetails>> GetById(int id)
        {
            var experience = await _unitOfWork.experienceRole.Get(id);
            if (experience == null)
            {

                return NoContent();
            }
            var experienceDto = _mapper.Map<ExperienceRoleDetails>(experience);
            return Ok(experienceDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ExperienceRoleDetails>> Create(int id, [FromBody] ExperienceRoleDetails experienceDto)
        {
            if (experienceDto.roleid > 0)
            {
                var experienceRole = _mapper.Map<ExperienceRoleDetails>(experienceDto);
                await _unitOfWork.experienceRole.Update(experienceRole);
                return NoContent();

            }
            var experinecDetail = _mapper.Map<ExperienceRoleDetails>(experienceDto);

            await _unitOfWork.experienceRole.Create(experinecDetail);

            return CreatedAtRoute("GetExperience", new { id = experinecDetail.roleid }, experinecDetail);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var experience = await _unitOfWork.experienceRole.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (experience == null)
            {
                return NotFound();

            }
            await _unitOfWork.experienceRole.Delete(experience);
            return NoContent();
        }
    }
}
