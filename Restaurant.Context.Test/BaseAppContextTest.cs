using Microsoft.EntityFrameworkCore;
using Moq;
using Restaurant.Common.Abstractions;
using AppContext = Restaurant.Context.AppContext;

namespace Restautant.Context.Tests;

public abstract class BaseAppContextTest : IDisposable
{
	private readonly AppContext context;
	private readonly CancellationTokenSource cancellationTokenSource;

	public AppContext Context => context;
	public CancellationToken token => cancellationTokenSource.Token;

	public BaseAppContextTest()
	{
		var option = new DbContextOptionsBuilder<AppContext>()
			.UseInMemoryDatabase($"AppContext{Guid.NewGuid()}")
			.Options;

		context = new AppContext(option);		
		cancellationTokenSource = new();

	}
	public void Dispose()
	{
		cancellationTokenSource.Cancel();
		cancellationTokenSource.Dispose();
		context.Dispose();
	}
}
