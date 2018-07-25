namespace TourToto.Model
{
    public interface ICyclistDao
    {
        int Add(Cyclist cyclist);

        bool Delete(int cyclistId);

        Cyclist Get(int id);

        bool Update(Cyclist cyclist);
    }
}