using FAP_FPT.Business.DTO;

namespace FAP_FPT.Business.IRepository
{
    public interface IStudentRepository
    {
        StudentDTO getStudentDTO(int userId);

    }
}
