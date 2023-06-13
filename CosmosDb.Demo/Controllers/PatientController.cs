using CosmosDb.Demo.Models;
using CosmosDb.Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Linq;

namespace CosmosDb.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientCosmosService _patientCosmosService;

        public PatientController(IPatientCosmosService patientCosmosService)
        {
            _patientCosmosService = patientCosmosService;   
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sqlCosmosQuery = "Select *from c";
            var result = await _patientCosmosService.Get(sqlCosmosQuery); 
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Patient newPatient)
        {
            newPatient.Id = Guid.NewGuid().ToString();  
            var result = await _patientCosmosService.Add(newPatient);
            return Ok(result);  
        }
        [HttpPut]
        public async Task<IActionResult> Put(Patient patientToUpdate)
        {
            var result = await _patientCosmosService.Update(patientToUpdate);
            return Ok(result);  
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id, string emailId)
        {
            await _patientCosmosService.Delete(id, emailId);
            return Ok();
        }

    }
}
