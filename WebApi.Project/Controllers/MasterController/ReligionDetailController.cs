using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReligionDetailController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReligionDetailController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ReligionNameDetail>>> GetAll()
        {
            var religion = await _unitOfWork.religionName.GetAll();

            _mapper.Map<List<ReligionNameDetail>>(religion);
            if (religion == null)
            {
                return NoContent();
            }
            return Ok(religion);
        }
        [HttpGet("{id:int}", Name = "GetReligion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReligionNameDetail>> GetById(int id)
        {
            var religionName = await _unitOfWork.religionName.Get(id);

            if (religionName == null)
            {

                return NoContent();
            }
            var religionDto = _mapper.Map<ReligionNameDetail>(religionName);
            return Ok(religionDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReligionNameDetail>> Create(int id, [FromBody] ReligionNameDetail religionDto)
        {
            if (religionDto.Religionid > 0)
            {
                var relationName = _mapper.Map<ReligionNameDetail>(religionDto);
                await _unitOfWork.religionName.Update(relationName);
                return NoContent();

            }
            var religionName = _mapper.Map<ReligionNameDetail>(religionDto);

            await _unitOfWork.religionName.Create(religionName);

            return CreatedAtRoute("GetReligion", new { id = religionName.Religionid }, religionName);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var religionName = await _unitOfWork.religionName.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (religionName == null)
            {
                return NotFound();

            }
            await _unitOfWork.religionName.Delete(religionName);
            return NoContent();
        }
    }
}
