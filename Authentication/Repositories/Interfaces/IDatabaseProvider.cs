using System.Data;

namespace Authentication.Repositories.Interfaces
{
    public interface IDatabaseProvider
    {
        IDbConnection GetConnection();
        void SetStringConnection(string typeConnection);
    }
}