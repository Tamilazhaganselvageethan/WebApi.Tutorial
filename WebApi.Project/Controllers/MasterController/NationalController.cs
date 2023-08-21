using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public NationalController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<NationalityDetail>>> GetAll()
        {
            var nationalDetail = await _unitOfWork.nationalityDetail.GetAll();

            _mapper.Map<List<NationalityDetail>>(nationalDetail);
            if (nationalDetail == null)
            {
                return NoContent();
            }
            return Ok(nationalDetail);
        }
        [HttpGet("{id:int}", Name = "GetNational")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<NationalityDetail>> GetById(int id)
        {
            var leaveType = await _unitOfWork.nationalityDetail.Get(id);

            if (leaveType == null)
            {

                return NoContent();
            }
            var leaveDto = _mapper.Map<NationalityDetail>(leaveType);
            return Ok(leaveDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NationalityDetail>> Create(int id, [FromBody] NationalityDetail nationalityDto)
        {
            if (nationalityDto.nationality_id > 0)
            {
                var nationality = _mapper.Map<NationalityDetail>(nationalityDto);
                await _unitOfWork.nationalityDetail.Update(nationality);
                return NoContent();

            }
            var national = _mapper.Map<NationalityDetail>(nationalityDto);

            await _unitOfWork.nationalityDetail.Create(national);

            return CreatedAtRoute("GetNational", new { id = national.nationality_id }, national);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var national = await _unitOfWork.nationalityDetail.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (national == null)
            {
                return NotFound();

            }
            await _unitOfWork.nationalityDetail.Delete(national);
            return NoContent();
        }
    }
}
