using System.ComponentModel;

namespace Reservatio.Models
{
    public enum RoleType
    {
        [Description(Role.Customer)]
        Customer = 1,
        [Description(Role.ServiceProvider)]
        ServiceProvider = 2,
        [Description(Role.Administrator)]
        Administrator = 3
    }

    public static class Role
    {
        public const string Customer = "Customer";
        public const string ServiceProvider = "Service Provider";
        public const string Administrator = "Administrator";
    }
}
