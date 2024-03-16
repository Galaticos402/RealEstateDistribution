using AutoMapper;
using Core;
using Infrastructure.DTOs.Contract;
using Infrastructure.Repository;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContractService _contractService;
        private readonly IAuthService _authService;
        public ContractController(IMapper mapper, IContractService contractService, IAuthService authService)
        {
            _mapper = mapper;            
            _contractService = contractService;
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var header = this.Request.Headers;
            var token = header["Authorization"];
            var userId = _authService.GetCurrentUserId(token);
            if (userId == null)
            {
                return BadRequest(new
                {
                    Message = "Cannot find requesting user"
                });
            }
            else
            {
                return Ok(_contractService.GetContractsOfACustomer((int)userId));
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> BuildContract(ContractCreationModel model)
        {
            var header = this.Request.Headers;
            var token = header["Authorization"];
            var userId = _authService.GetCurrentUserId(token);
            if (userId == null)
            {
                return BadRequest(new
                {
                    Message = "Cannot find requesting user"
                });
            }
            var contract = _mapper.Map<Contract>(model);
            contract.CustomerId = (int)userId;
            if (contract == null)
            {
                return BadRequest(new
                {
                    Message = "Failed to cast request to a contract"
                });
            }
            else
            {
                try
                {
                    _contractService.BuildContract(contract);
                }catch (Exception ex)
                {
                    return BadRequest(new
                    {
                        Message = ex.Message,
                    });
                }
                return Ok(contract);
            }
        }

    }
}
