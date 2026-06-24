using ServicesContracts;

namespace ASP.Net.Services
{
    public class CitiesService : ICitiesService
    {
        private List<string> _citites;

        private Guid _serviceInstanceId;
        public Guid ServiceInstanceId
        {
            get
            {
                return _serviceInstanceId;
            }
        }
        public CitiesService()
        {
            _serviceInstanceId = Guid.NewGuid();
            _citites = new List<string>()
            {
                "London",
                "Paris",
                "Dhaka",
                "Khulna",
                "Bogura"
            };

        }

        public List<string> GetCities()
        {
            return _citites;
        }

    }
}
