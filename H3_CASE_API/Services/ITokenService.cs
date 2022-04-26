using H3_CASE_API.Services;

namespace H3_CASE_API.Services;
public interface ITokenService
{
    string GetToken(Users user);
}