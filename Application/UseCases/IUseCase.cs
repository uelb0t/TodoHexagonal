namespace Application.UseCases;

public interface IUseCase<in TIn, TOut>
{
    Task<TOut> Execute(TIn input);
}