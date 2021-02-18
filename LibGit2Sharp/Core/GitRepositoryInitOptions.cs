using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LibGit2Sharp.Core
{
    [StructLayout(LayoutKind.Sequential)]
    internal class GitRepositoryInitOptions : IDisposable
    {
        public uint Version = 1;
        public GitRepositoryInitFlags Flags;
        public int Mode;
        public IntPtr WorkDirPath;
        public IntPtr Description;
        public IntPtr TemplatePath;
        public IntPtr InitialHead;
        public IntPtr OriginUrl;

        public static GitRepositoryInitOptions BuildFrom(InitOptions initOptions)
        {
            var opts = new GitRepositoryInitOptions
            {
                Flags = GitRepositoryInitFlags.GIT_REPOSITORY_INIT_MKPATH,
                Mode = 0  /* GIT_REPOSITORY_INIT_SHARED_UMASK  */
            };

            if (initOptions.WorkdirPath != null)
            {
                Debug.Assert(!initOptions.IsBare);

                opts.WorkDirPath = StrictFilePathMarshaler.FromManaged(initOptions.WorkdirPath);
            }

            if (initOptions.IsBare)
            {
                opts.Flags |= GitRepositoryInitFlags.GIT_REPOSITORY_INIT_BARE;
            }

            if (initOptions.InitialHead != null)
            {
                opts.InitialHead = StrictUtf8Marshaler.FromManaged(initOptions.InitialHead);
            }

            return opts;
        }

        public void Dispose()
        {
            EncodingMarshaler.Cleanup(WorkDirPath);
            WorkDirPath = IntPtr.Zero;

            EncodingMarshaler.Cleanup(InitialHead);
            InitialHead = IntPtr.Zero;
        }
    }

    [Flags]
    internal enum GitRepositoryInitFlags
    {
        GIT_REPOSITORY_INIT_BARE = (1 << 0),
        GIT_REPOSITORY_INIT_NO_REINIT = (1 << 1),
        GIT_REPOSITORY_INIT_NO_DOTGIT_DIR = (1 << 2),
        GIT_REPOSITORY_INIT_MKDIR = (1 << 3),
        GIT_REPOSITORY_INIT_MKPATH = (1 << 4),
        GIT_REPOSITORY_INIT_EXTERNAL_TEMPLATE = (1 << 5),
    }
}
