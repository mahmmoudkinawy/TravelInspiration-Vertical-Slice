using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Moq;
using TravelInspiration.API.Shared.Security;

namespace TravelInspiration.API.UnitTests.Shared.Security;

public sealed class CurrentUserServiceTests
{
	[Fact]
	public void WhenGettingUser_WithNameIdentifierClaimInContext_NameIdentifierMustBeReturned()
	{
		// Arrange
		var httpContextAccessor = new Mock<IHttpContextAccessor>();
		var identity = new ClaimsIdentity([new Claim(ClaimTypes.NameIdentifier, "mahmm")], "Test", ClaimTypes.NameIdentifier, ClaimTypes.Role);

		var contextUser = new ClaimsPrincipal(identity);

		var httpContext = new DefaultHttpContext() { User = contextUser };

		httpContextAccessor.Setup(x => x.HttpContext).Returns(httpContext);

		var currentUserService = new CurrentUserService(httpContextAccessor.Object);

		// Act
		var userId = currentUserService.UserId;

		// Assert
		Assert.Equal(identity.Name, userId);
	}
}
