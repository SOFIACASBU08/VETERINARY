namespace veterinary.web.Repositories
{
    public interface IRepository
    {
        Task<HttpResponseWrapper<T>> Get<T>(string url);

        Task<HttpResponseWrapper<object>> post<T>(string url, T model);

        Task<HttpResponseWrapper<TResponse>> post<T, TResponse>(string url, T model);



    }
}
