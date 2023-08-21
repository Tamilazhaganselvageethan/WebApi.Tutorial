using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.PageDetails;

namespace OnlineExamApi.Project.Controllers.PageConfiguration
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageConfigurationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PageConfigurationController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<M_PageDetails>>> GetAll()
        {
            var pageField = await _unitOfWork.pageDetail.GetAll();

            _mapper.Map<List<M_PageDetails>>(pageField);
            if (pageField == null)
            {
                return NoContent();
            }
            return Ok(pageField);
        }
        [HttpGet]
        [Route("api/GetSubPage")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<M_SubPageDetails>>> GetAllSunPage()
        {
            var subPage = await _unitOfWork.subPageDetail.GetAll();

            _mapper.Map<List<M_SubPageDetails>>(subPage);
            if (subPage == null)
            {
                return NoContent();
            }
            return Ok(subPage);
        }

        [HttpGet]
        [Route("api/GetSubField")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<M_SubPageFields>>> GetAllPageField()
        {
            var PageField = await _unitOfWork.PageField.GetAll();

            _mapper.Map<List<M_SubPageFields>>(PageField);
            if (PageField == null)
            {
                return NoContent();
            }
            return Ok(PageField);
        }
    }
}
