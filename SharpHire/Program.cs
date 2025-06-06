using WTelegram;
using TL;

namespace SharpHire;

class Program
{
    private static Client? _client;
    private static readonly string[] Keywords = new[]
    {
        ".NET", "dotnet", "C#", "C sharp", "ASP.NET", "aspnet", "asp.net core",
        "Csharp", "Dot Net", "backend developer", "C#.Net"
    };

    static async Task Main(string[] args)
    {
        try
        {
            _client = new Client(Config);
            var user = await _client.LoginUserIfNeeded();

            Console.WriteLine($"👤 Logged in as: {user.username}");

            var dialogs = await _client.Messages_GetAllDialogs();

            var targetChannel = dialogs.chats.Values
                .OfType<Channel>()
                .FirstOrDefault(c => string.Equals(c.username, "freelance_ethio", StringComparison.OrdinalIgnoreCase));

            if (targetChannel == null)
            {
                Console.WriteLine("❌ Channel @freelance_ethio not found or you're not subscribed.");
                return;
            }

            Console.WriteLine("📡 Connected to @freelance_ethio");

            var history = await _client.Messages_GetHistory(targetChannel, limit: 3000);

            Console.WriteLine($"📨 Retrieved {history.Messages.Count()} messages from the channel.");

            var relevantMessages = history.Messages
                .OfType<Message>()
                .Where(m => !string.IsNullOrWhiteSpace(m.message) &&
                            Keywords.Any(kw => m.message.IndexOf(kw, StringComparison.OrdinalIgnoreCase) >= 0));

            if (!relevantMessages.Any())
            {
                Console.WriteLine("⚠️ No matching .NET/C# job posts found.");
            }
            else
            {
                foreach (var msg in relevantMessages)
                {
                    Console.WriteLine("\n✅ Matching Job Found:");
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine($"📅 Date: {msg.date.ToLocalTime()}");
                    Console.WriteLine($"📝 Message:\n{msg.message}");
                    Console.WriteLine(new string('-', 40));
                }
            }

            Console.WriteLine("✅ Job scan complete.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }

    private static string? Config(string what) => what switch
    {
        "api_id" => "9063618",
        "api_hash" => "960185ae873fd214a2a339b901f066b0",
        "phone_number" => "+251975304545",
        _ => null
    };
}
