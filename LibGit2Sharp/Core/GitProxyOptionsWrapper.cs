﻿using System;

namespace LibGit2Sharp.Core
{
    internal class GitProxyOptionsWrapper : IDisposable
    {
        public GitProxyOptionsWrapper(ProxyOptions proxyOptions)
        {
            GitProxyOptions = BuildFrom(proxyOptions);
        }

        internal GitProxyOptions GitProxyOptions;

        private GitRemoteCallbacks GitCallbacks;

        private GitProxyOptions BuildFrom(ProxyOptions proxyOptions)
        {
            var opts = new GitProxyOptions
            {
                Version = 1,
                Type = GitProxyType.Auto
            };

            if (proxyOptions == null)
            {
                return opts;
            }

            if (proxyOptions.Url != null)
            {
                opts.Url = StrictUtf8Marshaler.FromManaged(proxyOptions.Url);
                opts.Type = GitProxyType.Specified;
            }

            if (proxyOptions.CredentialsProvider != null ||
                proxyOptions.CertificateCheck != null)
            {
                var callbacks = new RemoteCallbacks(proxyOptions.CredentialsProvider, proxyOptions.CertificateCheck);
                GitCallbacks = callbacks.GenerateCallbacks();

                opts.CredentialsCb = GitCallbacks.acquire_credentials;
                opts.CertificateCheck = GitCallbacks.certificate_check;
            }

            return opts;
        }

        public void Dispose()
        {
            EncodingMarshaler.Cleanup(GitProxyOptions.Url);
            GitProxyOptions.Url = IntPtr.Zero;
        }
    }
}
