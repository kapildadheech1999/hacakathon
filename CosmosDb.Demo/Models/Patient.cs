using Newtonsoft.Json;

namespace CosmosDb.Demo.Models
{
    public class Patient
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("securityNumber")]
        public string SecurityNumber { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("emailId")]
        public string EmailId { get; set; }
        [JsonProperty("contactNumber")]
        public string ContactNumber { get; set; }
        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }
    }
}
