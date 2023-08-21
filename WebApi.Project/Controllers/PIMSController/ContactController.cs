using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.PIMSModel;

namespace OnlineExamApi.Project.Controllers.PIMSController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDetailController : ControllerBase
    {
       
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ContactDetailController(IMapper mapper, IUnitOfWork unitOfWork)
        {
           
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ContactDetails>>> GetAll()
        {
            var addresses = await _unitOfWork.contactDetail.GetAll();

            _mapper.Map<List<ContactDetails>>(addresses);
            if (addresses == null)
            {
                return NoContent();
            }
            return Ok(addresses);
        }

        [HttpGet("{id:int}", Name = "GetContact")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ContactDetails>> GetById(int id)
        {
            var address = await _unitOfWork.contactDetail.Get(id);
            if (address == null)
            {

                return NoContent();
            }
            var countryDto = _mapper.Map<ContactDetails>(address);
            return Ok(countryDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactDetails>> Create(int id, [FromBody] ContactDetails contactDto)
        {
            if (id > 0)
            {
                var contact = _mapper.Map<ContactDetails>(contactDto);

                await _unitOfWork.contactDetail.Update(contact);
                return NoContent();

            }

            var contactDetail = _mapper.Map<ContactDetails>(contactDto);

            await _unitOfWork.contactDetail.Create(contactDetail);

            return CreatedAtRoute("GetContact", new { id = contactDetail.contact_id }, contactDetail);
        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var country = await _unitOfWork.contactDetail.Get(id);
            if (country == null)
            {
                return NotFound();

            }
            await _unitOfWork.contactDetail.Delete(country);
            return NoContent();
        }
    }
}
