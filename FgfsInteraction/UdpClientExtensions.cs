using System.Net.Sockets;
using System.Text;

namespace FgfsInteraction;

public static class UdpClientExtensions
{
    public static async Task<string> ReceiveAsciiStringAsync(this UdpClient client, CancellationToken ct)
    {
        var result = await client.ReceiveAsync(ct);
        return Encoding.ASCII.GetString(result.Buffer);
    }

    public static async Task SendAsciiStringAsync(this UdpClient client, string input, CancellationToken ct)
    {
        var bytes = Encoding.ASCII.GetBytes(input);
        await client.SendAsync(bytes, ct);
    }
}
