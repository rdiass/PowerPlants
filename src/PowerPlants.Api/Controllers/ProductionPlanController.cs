using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PowerPlants.Api.DTOs;
using PowerPlants.Business.Models;
using PowerPlants.Business.Intefaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace PowerPlants.Api.V1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]    
    public class ProductionPlanController : ControllerBase
    {
        private readonly IProductionService _productionService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ProductionPlanController(IMapper mapper, 
                                        ILogger<ProductionPlanController> logger,
                                        IProductionService productionService)
        {
            _productionService = productionService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<IEnumerable<ProductionDTO>> GetPlan(PayLoadDTO payLoadDTO)
        {
            _logger.LogInformation("GetPlan was requested", payLoadDTO);
            var payLoad = _mapper.Map<PayLoad>(payLoadDTO);
            var response = _mapper.Map<IEnumerable<ProductionDTO>>(_productionService.GetPlan(payLoad));

            return Ok(response);
        }
    }
}
