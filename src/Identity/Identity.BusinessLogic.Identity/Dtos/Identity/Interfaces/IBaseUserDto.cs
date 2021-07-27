namespace Identity.BusinessLogic.Identity.Dtos.Identity.Interfaces
{
    public interface IBaseUserDto
    {
        object Id { get; }
        bool IsDefaultId();
    }
}
