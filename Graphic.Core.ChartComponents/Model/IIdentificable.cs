using System.ComponentModel;
namespace CoreComponents.Model
{
    public interface IIdentificable
    {
        [Browsable(false)]
        int Id { get; }
    }

}
