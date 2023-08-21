using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankNameController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BankNameController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BankNameDetails>>> GetAll()
        {
            var bankname = await _unitOfWork.bankName.GetAll();

            _mapper.Map<List<BankNameDetails>>(bankname);
            if (bankname == null)
            {
                return NoContent();
            }
            return Ok(bankname);
        }
        [HttpGet("{id:int}", Name = "GetBankName")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BankNameDetails>> GetById(int id)
        {
            var bankname = await _unitOfWork.bankName.Get(id);
            if (bankname == null)
            {

                return NoContent();
            }
            var bankNameDto = _mapper.Map<BankNameDetails>(bankname);
            return Ok(bankNameDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BankNameDetails>> Create(int id, [FromBody] BankNameDetails bankNameDto)
        {
            if (bankNameDto.bank_id > 0)
            {
                var account = _mapper.Map<BankNameDetails>(bankNameDto);
                await _unitOfWork.bankName.Update(account);
                return NoContent();

            }
            var bankNameDetail = _mapper.Map<BankNameDetails>(bankNameDto);

            await _unitOfWork.bankName.Create(bankNameDetail);

            return CreatedAtRoute("GetBankName", new { id = bankNameDetail.bank_id }, bankNameDetail);
        }



        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var banakName = await _unitOfWork.bankName.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (banakName == null)
            {
                return NotFound();

            }
            await _unitOfWork.bankName.Delete(banakName);
            return NoContent();
        }
    }
}
