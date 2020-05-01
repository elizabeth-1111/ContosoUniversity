namespace ContosoUniversity.Controllers
{
    internal interface IStudenRepository
    {
        System.Threading.Tasks.Task<dynamic> GetAll();
    }
}