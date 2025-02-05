using HolaMundo.Web.Domain.Dto;
using HolaMundo.Web.Infraestructure.Services;
using System.ComponentModel;

namespace HolaMundo.Web.Application.Services
{
    /// <summary>
    /// Interfaz para el servicio de tareas
    /// </summary>
    public interface ITareaService
    {
        /// <summary>
        /// Consulta las tareas
        /// </summary>
        /// <returns>
        /// Una lista de tareas
        /// </returns>
        public Task<List<TareaDto>> Consultar();

        /// <summary>
        /// Elimina una tarea
        /// </summary>
        /// <returns>
        /// Una lista de tareas
        /// </returns>
        public Task<List<TareaDto>> Eliminar(int Id);

        /// <summary>
        /// Guarda una tarea
        /// </summary>
        /// <returns>
        /// Una lista de tareas
        /// </returns>
        public Task<List<TareaDto>> Guardar(TareaDto tarea);
    }
    /// <summary>
    /// Servicio de tareas
    /// </summary>
    /// <param name="jsonFileService"></param>
    public class TareaService(IJsonFileService<TareaDto> jsonFileService) : ITareaService
    {
        /// <summary>
        /// Nombre del archivo
        /// </summary>
        private readonly string archivo = "tareas";

        /// <summary>
        /// Guarda una tarea
        /// </summary>
        /// <param name="tarea">
        /// Representa la tarea a guardar
        /// </param>
        /// <returns>
        /// Una lista de tareas
        /// </returns>
        public async Task<List<TareaDto>> Guardar(TareaDto tarea)
        {
            /// Se obtienen las tareas
            var tareas = await jsonFileService.Leer(archivo);
            /// Se asigna un identificador a la tarea
            tarea.Id = !tareas.Any() ? 1 : tareas.Max(x => x.Id) + 1;
            /// Se agrega la tarea a la lista
            tareas.Add(tarea);
            /// Se reescriben las tareas
            await jsonFileService.Escribir(archivo, tareas);
            /// Se retornan las tareas
            return tareas;
        }

        /// <summary>
        /// Consulta las tareas
        /// </summary>
        /// <returns>
        /// Una lista de tareas
        /// </returns>
        public async Task<List<TareaDto>> Consultar()
        {
            /// Se obtienen las tareas  
            var tareas = await jsonFileService.Leer(archivo);
            /// Se retornan las tareas
            return tareas;
        }

        /// <summary>
        /// Elimina una tarea
        /// </summary>
        /// <param name="Id">
        /// Es el identificador de la tarea a eliminar
        /// </param>
        /// <returns>
        /// Una lista de tareas
        /// </returns>
        public async Task<List<TareaDto>> Eliminar(int Id)
        {
            /// Se obtienen las tareas
            var tareas = await jsonFileService.Leer(archivo);
            /// Se busca la tarea a eliminar
            var tarea = tareas.FirstOrDefault(x => x.Id == Id);
            /// Si la tarea existe, se elimina
            if (tarea != null)
            {
                /// Se elimina la tarea
                tareas.Remove(tarea);
                /// Se reescriben las tareas
                await jsonFileService.Escribir(archivo, tareas);
            }
            /// Se retornan las tareas
            return tareas;
        }
    }
}
