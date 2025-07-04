namespace Application.Interfaces
{
    /// <summary>
    /// Define el contrato para eliminar una tarea existente.
    /// </summary>
    public interface IDeleteTask
    {
        /// <summary>
        /// Ejecuta la lógica para eliminar una tarea por su identificador.
        /// </summary>
        /// <param name="id">Identificador único de la tarea a eliminar.</param>
        /// <returns>
        /// Un valor booleano que indica si la eliminación fue exitosa.
        /// Devuelve <c>true</c> si la tarea fue eliminada; de lo contrario, <c>false</c>.
        /// </returns>
        Task<bool> Execute(int id);
    }
}
