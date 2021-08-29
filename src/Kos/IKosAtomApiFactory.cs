namespace Kos
{
    public interface IKosAtomApiFactory
    {
        IKosAtomApi CreateApi(string accessToken);
    }
}