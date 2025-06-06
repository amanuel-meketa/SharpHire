# SharpHire

**SharpHire** is a .NET 9 console application that connects to the Telegram channel [@freelance_ethio](https://t.me/freelance_ethio) and scans job postings in real-time. It filters messages containing relevant .NET and C# keywords, helping developers quickly discover freelance and remote job opportunities.

---

## 🚀 Features

- ✅ Connects to Telegram using [WTelegramClient](https://github.com/wiz0u/WTelegramClient)  
- 🔍 Scans and filters messages based on predefined technical keywords  
- 🧠 Keyword matching includes `.NET`, `C#`, `ASP.NET`, and related terms  
- 🖥️ Clean and user-friendly command-line output  

---

## 🛠️ Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)  
- A Telegram account 

---

## 🔧 Setup & Configuration

### 1. Clone the Repository

```bash
git clone https://github.com/amanuel-meketa/SharpHire.git
cd SharpHire

dotnet user-secrets init
dotnet user-secrets set "Telegram:api_id" "YOUR_API_ID"
dotnet user-secrets set "Telegram:api_hash" "YOUR_API_HASH"
dotnet user-secrets set "Telegram:phone_number" "+251XXXXXXXXX"

2. Build and Run the Application
dotnet build
dotnet run

📚 Technologies Used
.NET 9

WTelegramClient — Telegram API client

Microsoft.Extensions.Configuration — Configuration management

📸 Demo

👤 Logged in as: myusername
📡 Connected to @freelance_ethio
📨 Retrieved 1756 messages from the channel.

✅ Matching Job Found:
----------------------------------------
📅 Date: 6/5/2025 10:32:00 AM
📝 Message:
Looking for a senior C# backend developer for a remote contract...
----------------------------------------








