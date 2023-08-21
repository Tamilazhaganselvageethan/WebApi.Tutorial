using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateDetailController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public StateDetailController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StateDetail>>> GetAll()
        {
            var stateDetail = await _unitOfWork.stateDetail.GetAll();

            _mapper.Map<List<StateDetail>>(stateDetail);
            if (stateDetail == null)
            {
                return NoContent();
            }
            return Ok(stateDetail);
        }
        [HttpGet("{id:int}", Name = "GetState")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StateDetail>> GetById(int id)
        {
            var stateName = await _unitOfWork.stateDetail.Get(id);

            if (stateName == null)
            {

                return NoContent();
            }
            var stateDto = _mapper.Map<StateDetail>(stateName);
            return Ok(stateDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StateDetail>> Create(int id, [FromBody] StateDetail stateDto)
        {
            if (stateDto.state_id > 0)
            {
                var stateName = _mapper.Map<StateDetail>(stateDto);
                await _unitOfWork.stateDetail.Update(stateName);
                return NoContent();

            }
            var state = _mapper.Map<StateDetail>(stateDto);

            await _unitOfWork.stateDetail.Create(state);

            return CreatedAtRoute("GetState", new { id = state.state_id }, state);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var stateName = await _unitOfWork.stateDetail.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (stateName == null)
            {
                return NotFound();

            }
            await _unitOfWork.stateDetail.Delete(stateName);
            return NoContent();
        }
    }
}
