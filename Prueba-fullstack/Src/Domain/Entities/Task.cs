namespace Prueba_fullstack.Src.Domain.Entities
{
    /// <summary>
    /// Representa una tarea en el sistema.
    /// Esta entidad contiene los atributos esenciales de una tarea,
    /// incluyendo su identificador, título y estado de completitud.
    /// </summary>
    public class TaskList
    {
        /// <summary>
        /// Identificador único de la tarea.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Título descriptivo de la tarea.
        /// No debe estar vacío ni ser nulo.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Indica si la tarea ha sido completada.
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
