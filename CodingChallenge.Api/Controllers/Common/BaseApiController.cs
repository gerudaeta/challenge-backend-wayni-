using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge.Api.Controllers.Common;

[ApiController]
[Route("[controller]")]
public abstract class BaseApiController : ControllerBase;