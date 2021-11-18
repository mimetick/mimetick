namespace Mimetick.Core
{
    public class AppConfiguration
    {
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
