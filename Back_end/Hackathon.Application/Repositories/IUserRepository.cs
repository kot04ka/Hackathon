namespace Hackathon.Application.Repositories
{
    public interface IUserRepository
    {
        bool AuthUser(string username, string password);

        //Add more methods here.
    }
}
