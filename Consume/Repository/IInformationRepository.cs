using Consume.Models;

namespace Consume.Repository
{
    public interface IInformationRepository
    {
        // get
        List<Information> GetAllInformation();

        // get by id
        Information GetInformationById(int id);

        // add 
        Information AddInformation(Information newInformation);

        // update 
        Information UpdateInformation(int id, Information newInformation);

        // delete 
        Information DeleteTodo(int id);
    }
}
