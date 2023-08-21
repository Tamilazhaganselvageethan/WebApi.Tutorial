using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemporaryPincodeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TemporaryPincodeController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TemporaryPincodeDetail>>> GetAll()
        {
            var temporaryPincode = await _unitOfWork.temporaryPincode.GetAll();

            _mapper.Map<List<TemporaryPincodeDetail>>(temporaryPincode);
            if (temporaryPincode == null)
            {
                return NoContent();
            }
            return Ok(temporaryPincode);
        }
        [HttpGet("{id:int}", Name = "GetTempPincode")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TemporaryPincodeDetail>> GetById(int id)
        {
            var temporaryPincode = await _unitOfWork.temporaryPincode.Get(id);

            if (temporaryPincode == null)
            {

                return NoContent();
            }
            var temppincodeDto = _mapper.Map<TemporaryPincodeDetail>(temporaryPincode);
            return Ok(temppincodeDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TemporaryPincodeDetail>> Create(int id, [FromBody] TemporaryPincodeDetail temporaryPincodeDto)
        {
            if (temporaryPincodeDto.pincode_id > 0)
            {
                var tempPincode = _mapper.Map<TemporaryPincodeDetail>(temporaryPincodeDto);
                await _unitOfWork.temporaryPincode.Update(tempPincode);
                return NoContent();

            }
            var pincode = _mapper.Map<TemporaryPincodeDetail>(temporaryPincodeDto);

            await _unitOfWork.temporaryPincode.Create(pincode);

            return CreatedAtRoute("GetTempPincode", new { id = pincode.pincode_id }, pincode);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var tempPincode = await _unitOfWork.temporaryPincode.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (tempPincode == null)
            {
                return NotFound();

            }
            await _unitOfWork.temporaryPincode.Delete(tempPincode);
            return NoContent();
        }
    }
}
