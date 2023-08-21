using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.PIMSModel;

namespace OnlineExamApi.Project.Controllers.PIMSController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDetailController : ControllerBase
    {
       
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PersonalDetailController(IMapper mapper, IUnitOfWork unitOfWork)
        {
           
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PersonalDetails>>> GetAll()
        {
            var personal = await _unitOfWork.personalDetail.GetAll();

            _mapper.Map<List<PersonalDetails>>(personal);
            if (personal == null)
            {
                return NoContent();
            }
            return Ok(personal);
        }

        [HttpGet("{id:int}",Name ="GetPersonal")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PersonalDetails>> GetById(int id)
        {
            var personal = await _unitOfWork.personalDetail.Get(id);

            if (personal == null)
            {

                return NoContent();
            }
            var countryDto = _mapper.Map<PersonalDetails>(personal);
            return Ok(countryDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonalDetails>> Create(int id, [FromBody] PersonalDetails personalDto)
        {
            if (id > 0)
            {
                var personal = _mapper.Map<PersonalDetails>(personalDto);

                await _unitOfWork.personalDetail.Update(personal);
                return NoContent();

            }
            var personalDetail = _mapper.Map<PersonalDetails>(personalDto);

            await _unitOfWork.personalDetail.Create(personalDetail);

            return CreatedAtRoute("GetPersonal", new { id = personalDetail.personal_id }, personalDetail);
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
            var personal = await _unitOfWork.personalDetail.Get(id);
            if (personal == null)
            {
                return NotFound();

            }
            await _unitOfWork.personalDetail.Delete(personal);
            return NoContent();
        }
    }
}
