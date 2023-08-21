using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.AccountDetailModel;
using OnlineExam.Domain.Model.PIMSModel;
using OnlineExam.Infrastructure.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamApi.Project.Controllers.PIMSController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //private readonly ApplicationDbContext _dbContext;
        //public AccountController(ApplicationDbContext dbContext)
        //{
        //    _dbContext = dbContext;

        //}

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
 
        public AccountController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AccountDetails>>> GetAll()
        {
            var countries = await _unitOfWork.accountDetail.GetAll();

            _mapper.Map<List<AccountDetails>>(countries);

            if (countries == null)
            {
                return NoContent();
            }
            return Ok(countries);
        }

        //[HttpGet]
        //[Route("api/GetcusAll")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<List<cus>>> GetcusAll()
        //{
        //    List<cus> _cus = new List<cus>();
        //    List <AddressDetails> add = await _dbContext.Set<AddressDetails>().ToListAsync();
        //    List<AccountDetails> acc = await _dbContext.Set<AccountDetails>().ToListAsync();

        //    foreach (cus cus in _dbContext._cus)
        //    {
        //        _cus.Add(cus);
        //    }
        //    //List<AddressDetails> add = await _dbContext.Set<AddressDetails>().ToListAsync();
        //    //var scc = await _dbContext.Set<AccountDetails>().ToListAsync();
        //    return _cus;

        //}

        [HttpGet("{id:int}", Name = "GetAccount")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AccountDetails>> GetById(int id)
        {
            var country = await _unitOfWork.accountDetail.Get(id);



            if (country == null)
            {

                return NoContent();
            }
            var countryDto = _mapper.Map<AccountDetails>(country);
            return Ok(countryDto);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccountDetails>> Create(int id, [FromBody] AccountDetails accountDto)
        {
            if (accountDto.account_id > 0)
            {
                var account = _mapper.Map<AccountDetails>(accountDto);
                await _unitOfWork.accountDetail.Update(account);
                return NoContent();
            }
            else
            {
                var accountDetail = _mapper.Map<AccountDetails>(accountDto);

                await _unitOfWork.accountDetail.Create(accountDetail);

                return CreatedAtRoute("GetAccount", new { id = accountDetail.account_id }, accountDetail);
            }


        }



        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var country = await _unitOfWork.accountDetail.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (country == null)
            {
                return NotFound();

            }
            await _unitOfWork.accountDetail.Delete(country);
            return NoContent();
        }
    }
}
