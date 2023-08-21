using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LeaveTypeController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<LeaveDetails>>> GetAll()
        {
            var leaveDetail = await _unitOfWork.leaveRepository.GetAll();

            _mapper.Map<List<LeaveDetails>>(leaveDetail);
            if (leaveDetail == null)
            {
                return NoContent();
            }
            return Ok(leaveDetail);
        }
        [HttpGet("{id:int}", Name = "GetLeave")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LeaveDetails>> GetById(int id)
        {
            var leaveType = await _unitOfWork.leaveRepository.Get(id);
            if (leaveType == null)
            {

                return NoContent();
            }
            var leaveDto = _mapper.Map<LeaveDetails>(leaveType);
            return Ok(leaveDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LeaveDetails>> Create(int id, [FromBody] LeaveDetails leaveDto)
        {
            if (leaveDto.LeaveTypeid > 0)
            {
                var leaveType = _mapper.Map<LeaveDetails>(leaveDto);
                await _unitOfWork.leaveRepository.Update(leaveType);
                return NoContent();

            }
            var leave = _mapper.Map<LeaveDetails>(leaveDto);

            await _unitOfWork.leaveRepository.Create(leave);

            return CreatedAtRoute("GetLeave", new { id = leave.LeaveTypeid }, leave);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var leaveType = await _unitOfWork.leaveRepository.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (leaveType == null)
            {
                return NotFound();

            }
            await _unitOfWork.leaveRepository.Delete(leaveType);
            return NoContent();
        }
    }
}
