using YemekTarifleriApi.Domain.Models.Common;

namespace YemekTarifleriApi.Domain.Models;

public class User : BaseEntity
{
  public string Name { get; set; }
  public string Surname { get; set; }
  public string Email { get; set; }
  public bool EmailConfirmed { get; set; }
  public string UserName { get; set; }
  public string Password { get; set; }
  public string? Country { get; set; }
  public string? RefreshToken { get; set; }
  public DateTime? RefreshTokenExpires { get; set; }
  public virtual ICollection<Recipe> Recipes { get; set; }
}