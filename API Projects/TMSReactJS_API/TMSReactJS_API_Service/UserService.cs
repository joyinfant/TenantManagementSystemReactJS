using System;

namespace TMSReactJS_API_Service
{

    using System.Collections.Generic;
    using System.Text;
    using System;
    using System.Threading.Tasks;
    using TMSReactJS_API_Models;
    using TMSReactJS_API_Models.Input;
    using TMSReactJS_API_Repository;

    public interface IUserService
    {
        Task<Result> save(UserDetails user);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<Result>save(UserDetails user)
        {
            var Result = new Result();
            var Id = await _userRepository.save(user);
            if(Id>0)
            {
                Result.StatusCode = 200;
                Result.StatusMessage = "Save";

            }
            else
            {
                Result.StatusCode = 201;
                Result.StatusMessage = "Failed";
            }
            return Result;
        }
    }
}
