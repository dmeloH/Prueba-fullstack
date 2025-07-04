namespace Application.Interfaces

{
    public interface IDeleteTask
    {
        Task<bool> Execute(int id);
    }
}
