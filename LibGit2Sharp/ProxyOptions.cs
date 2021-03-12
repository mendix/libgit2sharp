using LibGit2Sharp.Handlers;

namespace LibGit2Sharp
{
    /// <summary>
    /// Options for connecting through a proxy.
    /// </summary>
    public sealed class ProxyOptions
    {
        /// <summary>
        /// The URL of the proxy.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// This will be called if the remote host requires authentication in order to connect to it.
        /// </summary>
        public CredentialsHandler CredentialsProvider { get; set; }

        /// <summary>
        /// If cert verification fails, this will be called to let the user make the final decision
        /// of whether to allow the connection to proceed.
        /// </summary>
        public CertificateCheckHandler CertificateCheck { get; set; }
    }
}
