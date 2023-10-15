using FAP_FPT.Business.DTO;

namespace FAP_FPT.Business.IRepository
{
    public interface IUserRepository
    {
        UserDTO getUser(int userId);

        UserDTO GetUserByEmail(string email);

        public List<UserDTO> getAll();


    }
}
