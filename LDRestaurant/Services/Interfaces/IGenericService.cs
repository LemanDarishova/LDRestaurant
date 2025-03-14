namespace LDRestaurant.Services.Interfaces
{
    public interface IGenericService<TCommandDto, TUpdateDto, TGetAllDto, TGetSingleDto>
    {
        //command
        public Task AddAsync(TCommandDto addDto);
        public Task RemoveAsync(Guid id);
        public Task UpdateAsync(Guid id, TUpdateDto dto);
        public Task DeleteAsync(Guid id);
        public Task RecoverAsync(Guid id);

        //get
        public Task<TGetSingleDto> GetSingleAsync(Guid id);
        public Task<List<TGetAllDto>> GetAllAsync();
    }
}
