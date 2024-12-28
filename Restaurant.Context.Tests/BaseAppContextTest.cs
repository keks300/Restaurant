using Microsoft.EntityFrameworkCore;
using Moq;
using Restaurant.Common.Abstractions;
using AppContext = Restaurant.Context.AppContext;

namespace Restautant.Context.Tests;

public abstract class BaseAppContextTest : IDisposable
{
	private readonly AppContext context;
	private readonly CancellationTokenSource cancellationTokenSource;
	private readonly Mock<IDateTimeProvider> dataTimeProviderMock;

	public AppContext Context => context;
	public CancellationToken token => cancellationTokenSource.Token;

	public IDateTimeProvider dataTimeProvider => dataTimeProviderMock.Object;

	public BaseAppContextTest()
	{
		cancellationTokenSource = new();

		dataTimeProviderMock.Setup(x => x.UtcNow).Returns(DateTime.UtcNow);
		dataTimeProviderMock.Setup(x => x.UtcNow).Returns(DateTime.UtcNow);

		var option = new DbContextOptionsBuilder<AppContext>()
			.UseInMemoryDatabase($"AppContext{Guid.NewGuid()}")
			.Options;

		context = new AppContext(option);
	}
	public void Dispose()
	{
		cancellationTokenSource.Cancel();
		cancellationTokenSource.Dispose();
		context.Dispose();
	}
}
