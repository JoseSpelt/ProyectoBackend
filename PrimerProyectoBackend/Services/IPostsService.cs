using PrimerProyectoBackend.DTO;

namespace PrimerProyectoBackend.Services
{
    public interface IPostsService
    {
        public Task<IEnumerable<PostDto>> Get();
    }
}
