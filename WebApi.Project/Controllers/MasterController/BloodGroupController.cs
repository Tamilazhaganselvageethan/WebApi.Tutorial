using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodGroupController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BloodGroupController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BloodGroupDetails>>> GetAll()
        {
            var bloodGroup = await _unitOfWork.bloodGroup.GetAll();

            _mapper.Map<List<BloodGroupDetails>>(bloodGroup);
            if (bloodGroup == null)
            {
                return NoContent();
            }
            return Ok(bloodGroup);
        }
        [HttpGet("{id:int}", Name = "GetBlood")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BloodGroupDetails>> GetById(int id)
        {
            var bloodGroup = await _unitOfWork.bloodGroup.Get(id);
            if (bloodGroup == null)
            {

                return NoContent();
            }
            var bloodGroupDto = _mapper.Map<BloodGroupDetails>(bloodGroup);
            return Ok(bloodGroupDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BloodGroupDetails>> Create(int id, [FromBody] BloodGroupDetails bloodGroupDto)
        {
            if (bloodGroupDto.BG_id > 0)
            {
                var bloodGroup = _mapper.Map<BloodGroupDetails>(bloodGroupDto);
                await _unitOfWork.bloodGroup.Update(bloodGroup);
                return NoContent();

            }
            var bloodGroupName = _mapper.Map<BloodGroupDetails>(bloodGroupDto);

            await _unitOfWork.bloodGroup.Create(bloodGroupName);

            return CreatedAtRoute("GetBlood", new { id = bloodGroupName.BG_id }, bloodGroupName);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var bloodGroupName = await _unitOfWork.bloodGroup.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (bloodGroupName == null)
            {
                return NotFound();

            }
            await _unitOfWork.bloodGroup.Delete(bloodGroupName);
            return NoContent();
        }
    }
}
