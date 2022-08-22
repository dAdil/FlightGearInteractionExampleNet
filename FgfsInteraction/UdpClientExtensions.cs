using LanguageExt;
using System.Net;
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

    public static async Task SendAsciiStringAsync(this UdpClient client, string input, string hostName, int port, CancellationToken ct)
    {
        var bytes = Encoding.ASCII.GetBytes(input);
        await client.SendAsync(bytes, hostName, port, ct);
    }
}
