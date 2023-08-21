using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermanentDistrictController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PermanentDistrictController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PermanentDistrictDetail>>> GetAll()
        {
            var permanentDistrict = await _unitOfWork.permanentDistrict.GetAll();

            _mapper.Map<List<PermanentDistrictDetail>>(permanentDistrict);
            if (permanentDistrict == null)
            {
                return NoContent();
            }
            return Ok(permanentDistrict);
        }
        [HttpGet("{id:int}", Name = "GetDistrict")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PermanentDistrictDetail>> GetById(int id)
        {
            var permanentDistrict = await _unitOfWork.permanentDistrict.Get(id);

            if (permanentDistrict == null)
            {

                return NoContent();
            }
            var permDistrictDto = _mapper.Map<PermanentDistrictDetail>(permanentDistrict);
            return Ok(permDistrictDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PermanentDistrictDetail>> Create(int id, [FromBody] PermanentDistrictDetail districtDto)
        {
            if (districtDto.districtid > 0)
            {
                var permDistrict = _mapper.Map<PermanentDistrictDetail>(districtDto);
                await _unitOfWork.permanentDistrict.Update(permDistrict);
                return NoContent();

            }
            var permanentDistrict = _mapper.Map<PermanentDistrictDetail>(districtDto);

            await _unitOfWork.permanentDistrict.Create(permanentDistrict);

            return CreatedAtRoute("GetDistrict", new { id = permanentDistrict.districtid }, permanentDistrict);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var permanentDistrict = await _unitOfWork.permanentDistrict.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (permanentDistrict == null)
            {
                return NotFound();

            }
            await _unitOfWork.permanentDistrict.Delete(permanentDistrict);
            return NoContent();
        }
    }
}
