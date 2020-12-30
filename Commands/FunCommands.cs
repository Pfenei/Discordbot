using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity.Extensions;
using System.Threading.Tasks;


namespace Discordbot.Commands
{
    public class FunCommands : BaseCommandModule
    {
        [Command("ping")]
        [Description("Returns Pong")]
        public async Task PingPong(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);

        }
        
        [Command("add")]
        [Description("Adds two numbers together")]
        public async Task Add (CommandContext ctx, [Description("First Number")] int num1, [Description("Second Number")] int num2)
        {
            await ctx.Channel.SendMessageAsync((num1 + num2).ToString()).ConfigureAwait(false);
        }

        [Command("response")]
        public async Task Response (CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();
            var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);
            await ctx.Channel.SendMessageAsync(message.Result.Content);
        }

    }
}
