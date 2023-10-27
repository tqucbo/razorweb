using Microsoft.AspNetCore.Identity;

public class WebIdentityErrorDescriber : IdentityErrorDescriber
{
    public override IdentityError DuplicateRoleName(string role)
    {
        return new IdentityError()
        {
            Code = base.DuplicateRoleName(role).Code,
            Description = $"Role có tên {role} bị trùng."
        };
    }
}