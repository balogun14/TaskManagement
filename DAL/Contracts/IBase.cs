namespace TaskManagement.DAL.Contracts
{
    public interface IBase<TEntity , TCreateEntity, TEditEntity>
    {
        Task<TEntity?> GetById(int Id);
        Task<IEnumerable<TEntity>?> GetAll ();
        Task<bool> Update(TEditEntity editEntity);
        Task<bool> Delete(int id);
        Task Create(TCreateEntity createEntity );

    }
}
