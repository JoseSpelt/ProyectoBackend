using PrimerProyectoBackend.DTO;

namespace PrimerProyectoBackend.Services
{
    public interface ICommomService<T,TI,TU>
    {
        public List<string> Errors { get; }
        Task<IEnumerable<T>> Get();
        Task<BeerDto> GetById(int id);
        Task<BeerDto> Add(TI beerInsertDto);
        Task<BeerDto> Update(int id,TU beerUpdateDto);
        Task <BeerDto> Delete(int id);
        bool Validate(TI dto);
        bool Validate(TU dto);
    }
}
