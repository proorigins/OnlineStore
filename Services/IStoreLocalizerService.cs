using Enums;
using Models;
using Models.Store;

namespace Services
{
    public interface IStoreLocalizerService
    {
        IStore LocalizeStore(IStore store, Currency currency);
    }
}