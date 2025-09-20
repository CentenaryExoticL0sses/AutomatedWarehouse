using System.Threading.Tasks;

namespace AutomatedWarehouse.Core.Interfaces
{
    /// <summary>
    /// Интерфейс объекта, реализующего запросы для обращения к API.
    /// </summary>
    public interface IAPIService
    {
        /// <summary>
        /// Асинхронно выполняет GET-запрос и десериализует ответ.
        /// </summary>
        /// <typeparam name="T">Тип DTO, в который будет десериализован JSON.</typeparam>
        /// <param name="endPoint">Эндпоинт API.</param>
        /// <returns>Экземпляр DTO типа T.</returns>
        public Task<T> GetAsync<T>(string endPoint);

        /// <summary>
        /// Асинхронно выполняет POST-запрос без ожидания тела ответа.
        /// </summary>
        /// <param name="endPoint">Эндпоинт API.</param>
        public Task PostAsync(string endPoint);

        /// <summary>
        /// Проверяет работоспособность сервера.
        /// Завершается успешно, если сервер отвечает корректно.
        /// </summary>
        Task PingServerAsync();
    }
}