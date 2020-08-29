using System.ComponentModel;

namespace Reservatio.Models
{
    public enum Region
    {
        [Description("North")]
        Norte = 1,
        [Description("Northest")]
        Nordeste = 2,
        [Description("Southest")]
        Sudeste = 3,
        [Description("South")]
        Sul = 4,
        [Description("Center-West")]
        CentroOeste = 5
    }
}
