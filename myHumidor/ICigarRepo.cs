using myHumidor.Models;

namespace myHumidor
{
    public interface ICigarRepo
    {
        public Cigar GetCigarList();
        public void UpdateFavorite(Cigar cigar);
        public IEnumerable<Cigar> SearchCigars(string searchString);
    }
}
