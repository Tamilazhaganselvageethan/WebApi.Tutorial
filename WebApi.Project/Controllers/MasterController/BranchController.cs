using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BranchController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BranchNameDetails>>> GetAll()
        {
            var branchName = await _unitOfWork.branchName.GetAll();

            _mapper.Map<List<BranchNameDetails>>(branchName);
            if (branchName == null)
            {
                return NoContent();
            }
            return Ok(branchName);
        }
        [HttpGet("{id:int}", Name = "GetBranch")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BranchNameDetails>> GetById(int id)
        {
            var branch = await _unitOfWork.branchName.Get(id);
            if (branch == null)
            {

                return NoContent();
            }
            var branchNameDto = _mapper.Map<BranchNameDetails>(branch);
            return Ok(branchNameDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BranchNameDetails>> Create(int id, [FromBody] BranchNameDetails branchNameDto)
        {
            if (branchNameDto.branch_id > 0)
            {
                var branch = _mapper.Map<BranchNameDetails>(branchNameDto);
                await _unitOfWork.branchName.Update(branch);
                return NoContent();

            }
            var branchNameDetail = _mapper.Map<BranchNameDetails>(branchNameDto);

            await _unitOfWork.branchName.Create(branchNameDetail);

            return CreatedAtRoute("GetBranch", new { id = branchNameDetail.branch_id }, branchNameDetail);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var branchName = await _unitOfWork.branchName.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (branchName == null)
            {
                return NotFound();

            }
            await _unitOfWork.branchName.Delete(branchName);
            return NoContent();
        }
    }
}
