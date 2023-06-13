using CosmosDb.Demo.Models;

namespace CosmosDb.Demo.Services
{
    public interface IPatientCosmosService
    {
         Task<List<Patient>> Get(string sqlCosmosQuery);
        Task<Patient> Add(Patient newpatient); 

        Task<Patient> Update(Patient patientToUpdate);

        Task Delete(string id, string emailId);
    }
}
