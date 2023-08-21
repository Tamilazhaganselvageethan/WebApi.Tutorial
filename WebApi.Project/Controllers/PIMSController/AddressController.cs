using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.AccountDetailModel;
using OnlineExam.Domain.Model.PIMSModel;

namespace OnlineExamApi.Project.Controllers.PIMSController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddressController(IMapper mapper, IUnitOfWork unitOfWork)
        {
           
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AddressDetails>>> GetAll()
        {
            var addresses = await _unitOfWork.addressDetail.GetAll();

            _mapper.Map<List<AddressDetails>>(addresses);
            if (addresses == null)
            {
                return NoContent();
            }
            return Ok(addresses);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AccountDetails>> GetById(int id)
        {
            var address = await _unitOfWork.addressDetail.Get(id);


            if (address == null)
            {

                return NoContent();
            }
            var countryDto = _mapper.Map<AddressDetails>(address);
            return Ok(countryDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressDetails>> Create(int id, [FromBody] AddressDetails addressDto)
        {
            if (id > 0)
            {

                var country = _mapper.Map<AddressDetails>(addressDto);

                await _unitOfWork.addressDetail.Update(country);
                return NoContent();

            }
            var address = _mapper.Map<AddressDetails>(addressDto);

            await _unitOfWork.addressDetail.Create(address);

            return CreatedAtAction("GetById", new { id = address.address_id }, address);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var country = await _unitOfWork.addressDetail.Get(id);
            if (country == null)
            {
                return NotFound();

            }
            await _unitOfWork.addressDetail.Delete(country);
            return NoContent();
        }
    }
}



//[HttpPut("{id:int}")]
//[ProducesResponseType(StatusCodes.Status204NoContent)]
//[ProducesResponseType(StatusCodes.Status400BadRequest)]
//[ProducesResponseType(StatusCodes.Status404NotFound)]
//public async Task<ActionResult<AddressDetails>> Update(int id, [FromBody] AddressDetails updateCountryDto)
//{
//    if (updateCountryDto == null || id != updateCountryDto.address_id)
//    {

//        return BadRequest();
//    }
//    var country = _mapper.Map<AddressDetails>(updateCountryDto);

//    await _addressDetailRepository.Update(country);
//    return NoContent();

//}