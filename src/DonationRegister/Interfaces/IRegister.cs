using System.Collections.Generic;

namespace src.DonationRegister.Interfaces
{
    public interface IRegister<T>
    {
        List<T> List();
        T ReturnForId(int id);
        void Add(T entity);
        int NextId();
    }
}
