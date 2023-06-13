using CosmosDb.Demo.Models;
using Microsoft.Azure.Cosmos;

namespace CosmosDb.Demo.Services
{
    public class PatientCosmosService : IPatientCosmosService
    {
        private readonly Container _container;
        public PatientCosmosService(CosmosClient client, string databaseName, string containerName)
        {
            _container = client.GetContainer(databaseName, containerName);
        }

        public async Task<Patient> Add(Patient newPatient)
        {
            var item = await _container.CreateItemAsync(newPatient, new PartitionKey(newPatient.EmailId));  
            return item;
        }

        public async Task Delete(string id, string emailId)
        {
            await _container.DeleteItemAsync<Patient>(id, new PartitionKey(emailId));
        }

        public async Task<List<Patient>> Get(string sqlCosmosQuery)
        {
            var query = _container.GetItemQueryIterator<Patient>(new QueryDefinition(sqlCosmosQuery));
            List<Patient> result = new List<Patient>();
            while(query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                result.AddRange(response);
            }

            return result;

        }

        public async Task<Patient> Update(Patient patientToUpdate)
        {
            var item = await _container.UpsertItemAsync<Patient>(patientToUpdate, new PartitionKey(patientToUpdate.EmailId));
            return item;
        }
    }
}
