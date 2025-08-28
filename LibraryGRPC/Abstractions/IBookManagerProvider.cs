namespace LibraryGRPC.Abstractions;

public interface IBookManagerProvider
{
    Task<string> SayHello();
    Task<string> SaySara();
}
