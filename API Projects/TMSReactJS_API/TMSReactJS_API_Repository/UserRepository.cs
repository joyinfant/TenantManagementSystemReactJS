using System;

namespace TMSReactJS_API_Repository
{
    using Dapper;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;
    using System.Threading.Tasks;
    using TMSReactJS_API_DBEngine;
    using TMSReactJS_API_Models.Input;
    public interface IUserRepository
    {
        Task<List<UserDetails>> GetuserList();
        Task<int> save(UserDetails user);
    }

    public class UserRepository : IUserRepository
    {
        private readonly ISQL_Service_Handeler _sql_Server_Handeler;
        public UserRepository(ISQL_Service_Handeler sQL_Service_Handeler)
        {
            _sql_Server_Handeler = sQL_Service_Handeler;
        }

        public Task<List<UserDetails>> GetuserList()
        {
            throw new NotImplementedException();
        }

        public Task<int> save(UserDetails user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UId", user.UId, DbType.Int32, System.Data.ParameterDirection.Input);

            parameters.Add("@UserName", user.UserName, DbType.String, System.Data.ParameterDirection.Input);

            parameters.Add("@Password", user.Password, DbType.String, System.Data.ParameterDirection.Input);

            parameters.Add("@FirstName", user.FirstName, DbType.String, System.Data.ParameterDirection.Input);

            parameters.Add("@LastName", user.LastName, DbType.String, System.Data.ParameterDirection.Input);

            parameters.Add("@Role", user.Role, DbType.String, System.Data.ParameterDirection.Input);

            parameters.Add("@Gender", user.Gender, DbType.Boolean, System.Data.ParameterDirection.Input);

            parameters.Add("@DateOfBirth", user.DateOfBirth, DbType.Date, System.Data.ParameterDirection.Input);

            parameters.Add("@Address", user.Address, DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@city", user.city, DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("@state", user.state, DbType.Int32, System.Data.ParameterDirection.Input);

        }
    }
}
