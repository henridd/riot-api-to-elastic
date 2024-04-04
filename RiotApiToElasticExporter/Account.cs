namespace RiotApiToElasticExporter
{
    internal struct Account
    {
        public string GameName { get; }
        public string TagLine { get; }

        public Account(string nameWithTagLine)
        {
            if(string.IsNullOrWhiteSpace(nameWithTagLine))
                throw new ArgumentNullException(nameof(nameWithTagLine));

            var split = nameWithTagLine.Split('#');

            if (split.Length != 2)
                throw new ArgumentException("Username must contain exactly one '#'", nameof(nameWithTagLine));

            if (string.IsNullOrEmpty(split[0]))
                throw new ArgumentException("Game name cannot be empty", nameof(nameWithTagLine));

            if (string.IsNullOrEmpty(split[1]))
                throw new ArgumentException("Tag line cannot be empty", nameof(nameWithTagLine));

            GameName = split[0];
            TagLine = split[1];
        }

        public override string ToString() 
            => $"{GameName}#{TagLine}";
    }
}
