using System.Data.SqlClient;

namespace TourToto.Connection
{
    internal interface ICrud
    {
        int Create(ISqlQueryData queryData);

        bool Delete(ISqlQueryData queryData);

        SqlDataReader Get(ISqlQueryData queryData);

        bool Update(ISqlQueryData queryData);

        int GetSingleValue(ISqlQueryData queryData);
    }
}