namespace Prova_Prática_Backend_Bari.Hello_World
{
    public class HelloWorldMessage
    {
        public List<string> Contents { get; private set; }

        public HelloWorldMessage()
        {
            Guid guid = Guid.NewGuid();

            string header = "Hello World";
            string microsserviceId = $"{Environment.MachineName} {Environment.UserDomainName} {Environment.UserName}";
            string timestamp = DateTime.Now.ToString();
            string requestId = guid.ToString();

            Contents = new List<string>
            {
                header,
                microsserviceId,
                timestamp,
                requestId
            };
        }

        public override string ToString()
        {
            string result = string.Join(Environment.NewLine, Contents);
            return result;
        }
    }
}
