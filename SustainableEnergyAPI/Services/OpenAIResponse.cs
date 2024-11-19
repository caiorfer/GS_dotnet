namespace SustainableEnergyAPI.Services
{
    public class OpenAIResponse
    {
        public List<Choice> Choices { get; set; }

        public OpenAIResponse(List<Choice> choices)
        {
            Choices = choices ?? new List<Choice>(); // Garante que Choices não seja nulo
        }
    }

    public class Choice
    {
        public Message Message { get; set; }

        public Choice(Message message)
        {
            Message = message ?? new Message(); // Garante que Message não seja nulo
        }
    }

    public class Message
    {
        public string Content { get; set; }

        public Message(string content = "")
        {
            Content = content ?? string.Empty; // Garante que Content não seja nulo
        }
    }


}
