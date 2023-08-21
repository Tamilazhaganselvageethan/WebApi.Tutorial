using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermanentPincodeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PermanentPincodeController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PermanentPincodeDetail>>> GetAll()
        {
            var permanentPincode = await _unitOfWork.permanentPincode.GetAll();

            _mapper.Map<List<PermanentPincodeDetail>>(permanentPincode);
            if (permanentPincode == null)
            {
                return NoContent();
            }
            return Ok(permanentPincode);
        }
        [HttpGet("{id:int}", Name = "GetPincode")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PermanentPincodeDetail>> GetById(int id)
        {
            var permanentPincode = await _unitOfWork.permanentPincode.Get(id);

            if (permanentPincode == null)
            {

                return NoContent();
            }
            var pincodeDto = _mapper.Map<PermanentPincodeDetail>(permanentPincode);
            return Ok(pincodeDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PermanentPincodeDetail>> Create(int id, [FromBody] PermanentPincodeDetail permanentPincodeDto)
        {
            if (permanentPincodeDto.pincodeid > 0)
            {
                var pincode = _mapper.Map<PermanentPincodeDetail>(permanentPincodeDto);
                await _unitOfWork.permanentPincode.Update(pincode);
                return NoContent();

            }
            var permanentPincode = _mapper.Map<PermanentPincodeDetail>(permanentPincodeDto);

            await _unitOfWork.permanentPincode.Create(permanentPincode);

            return CreatedAtRoute("GetPincode", new { id = permanentPincode.pincodeid }, permanentPincode);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var permanentPincode = await _unitOfWork.permanentPincode.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (permanentPincode == null)
            {
                return NotFound();

            }
            await _unitOfWork.permanentPincode.Delete(permanentPincode);
            return NoContent();
        }
    }
}
