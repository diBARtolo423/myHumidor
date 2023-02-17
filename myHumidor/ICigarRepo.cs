using myHumidor.Models;

namespace myHumidor
{
    public interface ICigarRepo
    {
        public Cigar GetCigarList();
        public void UpdateFavorite(Cigar cigar);

        public void AddFavorites(IEnumerable<int> favoriteIds);
        public IEnumerable<Cigar> SearchCigars(string searchString);
    }
}
