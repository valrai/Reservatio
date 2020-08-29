using System.ComponentModel;

namespace Reservatio.Models
{
    public enum RoleType
    {
        [Description("Custumer")]
        Custumer = 1,
        [Description("Service Provider")]
        ServiceProvider = 2
    }
}
