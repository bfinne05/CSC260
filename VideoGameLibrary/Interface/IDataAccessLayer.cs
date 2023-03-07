using VideoGameLibrary.Models;

namespace VideoGameLibrary.Interface
{
    public interface IDataAccessLayer
    {
        IEnumerable<Games> getGames();

        void addGame(Games game);

        void removeGame(int? id);

        Games getGame(int? id);

        int getGame(Games game);

        void editGame(Games game);

        void loanGame(string name, string title);

        IEnumerable<Games> FilterGames(string? genre, string? esrb, string? platform);
    }
}
