using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemporaryDistrictController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TemporaryDistrictController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TemporaryDistrictDetail>>> GetAll()
        {
            var temporaryDistrict = await _unitOfWork.temporaryDistrict.GetAll();

            _mapper.Map<List<TemporaryDistrictDetail>>(temporaryDistrict);
            if (temporaryDistrict == null)
            {
                return NoContent();
            }
            return Ok(temporaryDistrict);
        }
        [HttpGet("{id:int}", Name = "GetTempDistrict")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TemporaryDistrictDetail>> GetById(int id)
        {
            var temporaryDistrict = await _unitOfWork.temporaryDistrict.Get(id);

            if (temporaryDistrict == null)
            {

                return NoContent();
            }
            var tempDistrictDto = _mapper.Map<TemporaryDistrictDetail>(temporaryDistrict);
            return Ok(tempDistrictDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TemporaryDistrictDetail>> Create(int id, [FromBody] TemporaryDistrictDetail temporaryDistrictDto)
        {
            if (temporaryDistrictDto.district_id > 0)
            {
                var tempDistrict = _mapper.Map<TemporaryDistrictDetail>(temporaryDistrictDto);
                await _unitOfWork.temporaryDistrict.Update(tempDistrict);
                return NoContent();

            }
            var district = _mapper.Map<TemporaryDistrictDetail>(temporaryDistrictDto);

            await _unitOfWork.temporaryDistrict.Create(district);

            return CreatedAtRoute("GetTempDistrict", new { id = district.district_id }, district);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var tempDistrict = await _unitOfWork.temporaryDistrict.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (tempDistrict == null)
            {
                return NotFound();

            }
            await _unitOfWork.temporaryDistrict.Delete(tempDistrict);
            return NoContent();
        }
    }
}
