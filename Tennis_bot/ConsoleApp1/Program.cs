using System;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using System.Collections.Generic;
using System.IO;


namespace ConsoleApp1
{
    class Program
    {
        static IUser ReGos;
        static IUser Tennis_bot;
        static ISocketMessageChannel poll_channel;
        static Emoji zero = new Emoji("0️⃣");
        static Emoji one = new Emoji("1️⃣");
        static Emoji two = new Emoji("2️⃣");
        static Emoji three = new Emoji("3️⃣");
        static Emoji four = new Emoji("4️⃣");
        static Emoji five = new Emoji("5️⃣");
        static Emoji six = new Emoji("6️⃣");
        static Emoji seven = new Emoji("7️⃣");
        static Emoji tennis_emoji = new Emoji("🎾");
        static Emoji check_emoji = new Emoji("✅");
        static Emoji cross_emoji = new Emoji("❌");

        static ulong tennis_role_id = 893915061624659969;
        static ulong poll_message_id;
        static ulong reactionrole_message_id;
        static ulong poll_channel_id;
        static ulong ask_channel;
        static ulong reactionrole_channel_id;

        static async Task komendy(SocketMessage message)
        {
            if (message.Content.StartsWith("!T") && !message.Author.IsBot && message.Author.Id == ReGos.Id)
            {
             
                if (message.Content.StartsWith("!T poll"))
                {

                    poll_channel = message.Channel;
                    await make_poll(poll_channel, 2);

                    await message.DeleteAsync();
                }
                if(message.Content.StartsWith("!T reaction role"))
                {
                    var reactionrole_message = await message.Channel.SendMessageAsync(":tennis: Chcę otrzymywać powiadomienia o planowanych spotkaniach tenisowych");
                    reactionrole_message_id = reactionrole_message.Id;
                    reactionrole_channel_id = reactionrole_message.Channel.Id;
                    await reactionrole_message.AddReactionAsync(tennis_emoji);

                    await message.DeleteAsync();
                }
                if(message.Content.StartsWith("!T ask"))
                {
                    var ask_message = await message.Channel.SendMessageAsync(message.ToString().Remove(0, 7));
                    await ask_message.AddReactionAsync(check_emoji);
                    await ask_message.AddReactionAsync(cross_emoji);

                    await message.DeleteAsync();
                }
                if (message.Content.StartsWith("!T message"))
                {
                    var message_message = await message.Channel.SendMessageAsync(message.ToString().Remove(0, 11));

                    await message_message.AddReactionAsync(one);
                    await message_message.AddReactionAsync(two);
                    await message_message.AddReactionAsync(three);
                    await message_message.AddReactionAsync(four);
                    await message_message.AddReactionAsync(five);
                    await message_message.AddReactionAsync(six);
                    await message_message.AddReactionAsync(seven);
                    await message_message.AddReactionAsync(zero);

                    await message.DeleteAsync();
                }
            }
        }

        static string tlumaczenie_nazwy_tygodnia(string message)
        {
            if(message == "Monday")
            {
                return("Poniedziałek");
            }
            else if (message == "Tuesday")
            {
                return("Wtorek");
            }
            else if (message == "Wednesday")
            {
                return("Środę");
            }
            else if (message == "Thursday")
            {
                return("Czwartek");
            }
            else if (message == "Friday")
            {
                return("Piątek");
            }
            else if (message == "Saturday")
            {
                return("Sobotę");
            }
            else if (message == "Sunday")
            {
                return("Niedzielę");
            }
            return message;
        }

        private static async Task make_poll(ISocketMessageChannel channel, int wyprzedzenie)
        {       
            string data1 = DateTime.Now.AddDays(wyprzedzenie).ToString();
            data1 = data1.Remove(11);
            string data1_dzien_tygodnia = DateTime.Now.AddDays(wyprzedzenie).DayOfWeek.ToString();
            data1_dzien_tygodnia = tlumaczenie_nazwy_tygodnia(data1_dzien_tygodnia);

            string data2 = DateTime.Now.AddDays(wyprzedzenie + 1).ToString();
            data2 = data2.Remove(11);
            string data2_dzien_tygodnia = DateTime.Now.AddDays(wyprzedzenie + 1).DayOfWeek.ToString();
            data2_dzien_tygodnia = tlumaczenie_nazwy_tygodnia(data2_dzien_tygodnia);

            string data3 = DateTime.Now.AddDays(wyprzedzenie + 2).ToString();
            data3 = data3.Remove(11);
            string data3_dzien_tygodnia = DateTime.Now.AddDays(wyprzedzenie + 2).DayOfWeek.ToString();
            data3_dzien_tygodnia = tlumaczenie_nazwy_tygodnia(data3_dzien_tygodnia);

            string data4 = DateTime.Now.AddDays(wyprzedzenie + 3).ToString();
            data4 = data4.Remove(11);
            string data4_dzien_tygodnia = DateTime.Now.AddDays(wyprzedzenie + 3).DayOfWeek.ToString();
            data4_dzien_tygodnia = tlumaczenie_nazwy_tygodnia(data4_dzien_tygodnia);

            string data5 = DateTime.Now.AddDays(wyprzedzenie + 4).ToString();
            data5 = data5.Remove(11);
            string data5_dzien_tygodnia = DateTime.Now.AddDays(wyprzedzenie + 4).DayOfWeek.ToString();
            data5_dzien_tygodnia = tlumaczenie_nazwy_tygodnia(data5_dzien_tygodnia);

            string data6 = DateTime.Now.AddDays(wyprzedzenie + 5).ToString();
            data6 = data6.Remove(11);
            string data6_dzien_tygodnia = DateTime.Now.AddDays(wyprzedzenie + 5).DayOfWeek.ToString();
            data6_dzien_tygodnia = tlumaczenie_nazwy_tygodnia(data6_dzien_tygodnia);

            string data7 = DateTime.Now.AddDays(wyprzedzenie + 6).ToString();
            data7 = data7.Remove(11);
            string data7_dzien_tygodnia = DateTime.Now.AddDays(wyprzedzenie + 6).DayOfWeek.ToString();
            data7_dzien_tygodnia = tlumaczenie_nazwy_tygodnia(data7_dzien_tygodnia);

            var poll = await channel.SendMessageAsync("**Jestem dostępny i chcę wyjść w/we:**\n> :one: " + data1_dzien_tygodnia + " " + data1 + "\n> :two: " + data2_dzien_tygodnia + " " + data2 + "\n> :three: " + data3_dzien_tygodnia + " " + data3 + "\n> :four: " + data4_dzien_tygodnia + " " + data4 + "\n> :five: " + data5_dzien_tygodnia + " " + data5 + "\n> :six: " + data6_dzien_tygodnia + " " + data6 + "\n> :seven: " + data7_dzien_tygodnia + " " + data7 + "\n:zero: Nie jestem dostępny lub zainteresowany żadnym z tych wyjść \n\nZaznaczcie wszystkie prawdziwe dla was opcje " + MentionUtils.MentionRole(tennis_role_id));

            poll_message_id = poll.Id;
            poll_channel_id = poll.Channel.Id;

            await poll.AddReactionAsync(one);
            await poll.AddReactionAsync(two);
            await poll.AddReactionAsync(three);
            await poll.AddReactionAsync(four);
            await poll.AddReactionAsync(five);
            await poll.AddReactionAsync(six);
            await poll.AddReactionAsync(seven);
            await poll.AddReactionAsync(zero);
        }

        private static async Task handle_reaction_add(Cacheable<IUserMessage, ulong> arg1, ISocketMessageChannel arg2, SocketReaction arg3)
        {       
            var message = await arg1.GetOrDownloadAsync();
            var guild = ((SocketGuildChannel)message.Channel).Guild;
            var user = await client.Rest.GetGuildUserAsync(guild.Id, arg3.UserId);

            if (message.Id == reactionrole_message_id && arg3.Emote.Equals(tennis_emoji))
            {
                if (!user.IsBot)
                {
                    await user.AddRoleAsync(guild.GetRole(tennis_role_id));           
                }
            }
            if(message.Id == poll_message_id)
            {
                if(user.Id != ReGos.Id && user.Id != Tennis_bot.Id)
                {
                    if(!arg3.Emote.Equals(one) && !arg3.Emote.Equals(two) && !arg3.Emote.Equals(three) && !arg3.Emote.Equals(four) && !arg3.Emote.Equals(five) && !arg3.Emote.Equals(six) && !arg3.Emote.Equals(seven) && !arg3.Emote.Equals(zero))
                    {
                        await (await arg2.GetMessageAsync(arg3.MessageId)).RemoveReactionAsync(arg3.Emote, user);
                        await ReGos.SendMessageAsync("Usunieto reakcje: " + arg3.Emote + "\nAutor: " + user + "\nId autora: " + user.Id + "\nKanał: " + message.Channel.Name + "\nId kanału: " + message.Channel.Id);
                    }
                }
            }
            if (message.Id == reactionrole_message_id)
            {
                if(user.Id != ReGos.Id && user.Id != Tennis_bot.Id)
                {
                    if (!arg3.Emote.Equals(tennis_emoji))
                    {
                        await (await arg2.GetMessageAsync(arg3.MessageId)).RemoveReactionAsync(arg3.Emote, user);
                        await ReGos.SendMessageAsync("Usunieto reakcje: " + arg3.Emote + "\nAutor: " + user + "\nId autora: " + user.Id + "\nKanał: " + message.Channel.Name + "\nId kanału: " + message.Channel.Id);
                    }
                }
            }
        }
        
        private static async Task hande_reaction_remove(Cacheable<IUserMessage, ulong> arg1, ISocketMessageChannel arg2, SocketReaction arg3)
        {
            var message = await arg1.GetOrDownloadAsync();
            var guild = ((SocketGuildChannel)message.Channel).Guild;
            var user = await client.Rest.GetGuildUserAsync(guild.Id, arg3.UserId);

            if (arg3.UserId == Tennis_bot.Id)
            {
                if (arg1.Id == poll_message_id || arg1.Id == reactionrole_message_id)
                {
                    if (user.Id != ReGos.Id && user.Id != Tennis_bot.Id)
                    {
                        await message.AddReactionAsync(arg3.Emote);
                    }
                }
            }
            if(arg1.Id == reactionrole_message_id)
            {
                if (!user.IsBot)
                {
                    await user.RemoveRoleAsync(guild.GetRole(tennis_role_id));
                }
            }
        }

        static async Task prevent_spam(SocketMessage message)
        {
            if ((message.Channel.Id == poll_channel_id || message.Channel.Id == reactionrole_channel_id))
            {
                if (message.Author.Id != ReGos.Id && message.Author.Id != Tennis_bot.Id)
                {
                    await message.DeleteAsync();
                    await ReGos.SendMessageAsync("Usunięto wiadomość \nTreść: " + message.Content + "\nAutor: " + message.Author.Username + "\nId autora: " + message.Author.Id + "\nKanał: " + message.Channel.Name + "\nId kanału: " + message.Channel.Id);

                }
            }
        }

        static DiscordSocketClient client = new DiscordSocketClient();
        static void Main() => MainAsync().GetAwaiter().GetResult();

        static async Task MainAsync()
        {
       
            //await client.LoginAsync(TokenType.Bot, <your token here>);
            await client.StartAsync();

            ReGos = await client.Rest.GetUserAsync(453073983877677057);
            Tennis_bot = await client.Rest.GetUserAsync(893839816624570438);

            client.MessageReceived += komendy;
            client.MessageReceived += prevent_spam;
            client.ReactionAdded += handle_reaction_add;
            client.ReactionRemoved += hande_reaction_remove;

            while (true)
            {
                if (DateTime.Now.DayOfWeek.ToString() == "Saturday" && DateTime.Now.Hour.ToString() == "21" && DateTime.Now.Minute.ToString() == "37")
                {
                    if (poll_channel != null)
                    {
                        await make_poll(poll_channel, 2);
                    }
                
                    await Task.Delay(60000);
                }
            }
        }

    }
}
