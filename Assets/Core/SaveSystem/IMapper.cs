namespace Core.SaveSystem
{
    public interface IMapper<I, O>
    {
        O Map(I data);
        I Map(O data);
    }
}