using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AccountTypeController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AccountTypeDetails>>> GetAll()
        {
            var accountType = await _unitOfWork.account.GetAll();

            _mapper.Map<List<AccountTypeDetails>>(accountType);
            if (accountType == null)
            {
                return NoContent();
            }
            return Ok(accountType);
        }
        [HttpGet("{id:int}", Name = "Account")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AccountTypeDetails>> GetById(int id)
        {
            var accountType = await _unitOfWork.account.Get(id);
            if (accountType == null)
            {

                return NoContent();
            }
            var accountTypeDto = _mapper.Map<AccountTypeDetails>(accountType);
            return Ok(accountTypeDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccountTypeDetails>> Create(int id, [FromBody] AccountTypeDetails accountTypeDto)
        {
            if (accountTypeDto.AccountTypeid > 0)
            {
                var accountType = _mapper.Map<AccountTypeDetails>(accountTypeDto);
                await _unitOfWork.account.Update(accountType);
                return NoContent();

            }
            var accountDetail = _mapper.Map<AccountTypeDetails>(accountTypeDto);

            await _unitOfWork.account.Create(accountDetail);

            return CreatedAtRoute("GetAccount", new { id = accountDetail.AccountTypeid }, accountDetail);
        }



        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var accountType = await _unitOfWork.account.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (accountType == null)
            {
                return NotFound();

            }
            await _unitOfWork.account.Delete(accountType);
            return NoContent();
        }
    }
}
