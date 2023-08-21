using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.PIMSModel;

namespace OnlineExamApi.Project.Controllers.PIMSController
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyDetailController : ControllerBase
    {
       
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FamilyDetailController(IMapper mapper, IUnitOfWork unitOfWork)
        {
           
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<FamilyDetails>>> GetAll()
        {
            var family = await _unitOfWork.familyDetail.GetAll();

            _mapper.Map<List<FamilyDetails>>(family);
            if (family == null)
            {
                return NoContent();
            }
            return Ok(family);
        }

        [HttpGet("{id:int}", Name = "GetFamily")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FamilyDetails>> GetById(int id)
        {
            var families = await _unitOfWork.familyDetail.Get(id);

            if (families == null)
            {

                return NoContent();
            }
            var countryDto = _mapper.Map<FamilyDetails>(families);
            return Ok(countryDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FamilyDetails>> Create(int id,[FromBody]FamilyDetails familyDto)
        {
            if (id > 0)
            {

                var familyDetail = _mapper.Map<FamilyDetails>(familyDto);

                await _unitOfWork.familyDetail.Update(familyDetail);
                return NoContent();


            }
             
            var family = _mapper.Map<FamilyDetails>(familyDto);

            await _unitOfWork.familyDetail.Create(family);

            return CreatedAtRoute("GetFamily", new { id = family.familymemberid }, family);
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
            var familDetail = await _unitOfWork.familyDetail.Get(id);
            if (familDetail == null)
            {
                return NotFound();

            }
            await _unitOfWork.familyDetail.Delete(familDetail);
            return NoContent();
        }
    }
}
