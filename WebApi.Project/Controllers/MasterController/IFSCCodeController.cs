using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class IFSCCodeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public IFSCCodeController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<IFSCDetail>>> GetAll()
        {
            var ifscCode = await _unitOfWork.ifscCode.GetAll();

            _mapper.Map<List<IFSCDetail>>(ifscCode);
            if (ifscCode == null)
            {
                return NoContent();
            }
            return Ok(ifscCode);
        }
        [HttpGet("{id:int}", Name = "GetIfsc")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IFSCDetail>> GetById(int id)
        {
            var ifscCode = await _unitOfWork.ifscCode.Get(id);

            if (ifscCode == null)
            {

                return NoContent();
            }
            var ifscDto = _mapper.Map<IFSCDetail>(ifscCode);
            return Ok(ifscDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IFSCDetail>> Create(int id, [FromBody] IFSCDetail ifscDto)
        {
            if (ifscDto.ifsc_id > 0)
            {
                var ifscCode = _mapper.Map<IFSCDetail>(ifscDto);
                await _unitOfWork.ifscCode.Update(ifscCode);
                return NoContent();

            }
            var ifsc = _mapper.Map<IFSCDetail>(ifscDto);

            await _unitOfWork.ifscCode.Create(ifsc);

            return CreatedAtRoute("GetIfsc", new { id = ifsc.ifsc_id }, ifsc);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var ifscCode = await _unitOfWork.ifscCode.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (ifscCode == null)
            {
                return NotFound();

            }
            await _unitOfWork.ifscCode.Delete(ifscCode);
            return NoContent();
        }
    }
}
