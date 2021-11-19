namespace Mimetick.Core
{
    public class AppConfiguration
    {
        /// <summary>
        /// Initialize a new <see cref="AppConfiguration"/>
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="tenantId">The tenant identifier.</param>
        public AppConfiguration(string clientId, string tenantId)
        {
            ClientId = clientId;
            TenantId = tenantId;
        }

        public AppConfiguration() 
        { 
            // Used by dotnet core
        }

        /// <summary>
        /// Gets the client identifier
        /// </summary>
        public string ClientId { get; private set; }

        /// <summary>
        /// Gets the tenant id for authentication
        /// </summary>
        public string TenantId { get; private set; }
    }
}
