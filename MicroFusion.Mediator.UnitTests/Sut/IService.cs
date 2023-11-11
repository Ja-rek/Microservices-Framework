namespace MicroFusion.Mediator.Tests.Sut;

public interface IService
{
    void Add(AddCommand command);
    Task AddAsync(AddAsyncCommand command);

    ProductDto AddAndReturn(AddAndReturnCommand command);
    Task<ProductDto> AddAndReturnAsync(AddAndReturnAsyncCommand command);

    ProductDto Get(GetQuery query);
    Task<ProductDto> GetAsync(GetAsyncQuery query);
}