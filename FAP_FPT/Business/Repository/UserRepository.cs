using AutoMapper;
using FAP_FPT.Business.DTO;
using FAP_FPT.Business.IRepository;
using FAP_FPT.DataAccess.Managers;
using FAP_FPT.DataAccess.Models;

namespace FAP_FPT.Business.Repository
{
    public class UserRepository : IUserRepository
    {
        IMapper _mapper;
        FAP_FPTContext _context;
        UserManager manager;
        public UserRepository(IMapper mapper, FAP_FPTContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<UserDTO> getAll()
        {
            manager = new UserManager(_context);
            List<UserDTO> lst = _mapper.Map<List<UserDTO>>(manager.getListUsers());
            return lst;

        }

        public UserDTO getUser(int userId)
        {
            manager = new UserManager(_context);
            return _mapper.Map<UserDTO>(manager.GetUser(userId));
        }

        public UserDTO GetUserByEmail(string email)
        {
            manager = new UserManager(_context);
            return _mapper.Map<UserDTO>(manager.GetUserByEmail(email));
        }
    }
}
