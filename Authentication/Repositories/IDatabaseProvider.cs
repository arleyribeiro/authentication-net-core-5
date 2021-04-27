using System.Data;

namespace Authentication.Repositories
{
    public interface IDatabaseProvider
    {
        IDbConnection GetConnection();
        void SetStringConnection(string typeConnection);
    }
}