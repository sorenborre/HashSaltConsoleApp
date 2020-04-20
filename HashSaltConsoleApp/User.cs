namespace HashSaltConsoleApp
{
    class User
    {
        public User(string name, string hash, string salt)
        {
            Name = name;
            Hash = hash;
            Salt = salt;
        }

        public string Name { get; }
        public string Hash { get; }
        public string Salt { get; }
    }
}
