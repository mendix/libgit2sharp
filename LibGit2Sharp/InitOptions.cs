namespace LibGit2Sharp
{
    /// <summary>
    /// Options controlling Repository Init behavior.
    /// </summary>
    public sealed class InitOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InitOptions"/> class.
        /// <para>
        ///   Default behavior:
        ///     The workdirPath is null.
        ///     Not a bare repository.
        /// </para>
        /// </summary>
        public InitOptions()
        {
            WorkdirPath = null;
            IsBare = false;
        }

        /// <summary>
        /// The path to the working directory. Null if it's the same directory where ".git" repository is created.
        /// </summary>
        public string WorkdirPath { get; set; }

        /// <summary>
        /// True to initialize a bare repository. False otherwise, to initialize a standard ".git" repository.
        /// </summary>
        public bool IsBare { get; set; }
    }
}
