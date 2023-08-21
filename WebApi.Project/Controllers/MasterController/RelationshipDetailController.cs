using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;

namespace OnlineExamApi.Project.Controllers.MasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationshipDetailController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RelationshipDetailController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<RelationshipDetails>>> GetAll()
        {
            var relationships = await _unitOfWork.relationshipDetail.GetAll();

            _mapper.Map<List<RelationshipDetails>>(relationships);
            if (relationships == null)
            {
                return NoContent();
            }
            return Ok(relationships);
        }
        [HttpGet("{id:int}", Name = "GetRelation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RelationshipDetails>> GetById(int id)
        {
            var relationName = await _unitOfWork.relationshipDetail.Get(id);

            if (relationName == null)
            {

                return NoContent();
            }
            var relationshipDto = _mapper.Map<RelationshipDetails>(relationName);
            return Ok(relationshipDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RelationshipDetails>> Create(int id, [FromBody] RelationshipDetails relationshipDto)
        {
            if (relationshipDto.relationshipid > 0)
            {
                var relationName = _mapper.Map<RelationshipDetails>(relationshipDto);
                await _unitOfWork.relationshipDetail.Update(relationName);
                return NoContent();

            }
            var relationship = _mapper.Map<RelationshipDetails>(relationshipDto);

            await _unitOfWork.relationshipDetail.Create(relationship);

            return CreatedAtRoute("GetRelation", new { id = relationship.relationshipid }, relationship);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int Id)
        {

            var relationship = await _unitOfWork.relationshipDetail.Get(Id);
            if (Id == 0)
            {
                return BadRequest();
            }

            if (relationship == null)
            {
                return NotFound();

            }
            await _unitOfWork.relationshipDetail.Delete(relationship);
            return NoContent();
        }
    }
}
