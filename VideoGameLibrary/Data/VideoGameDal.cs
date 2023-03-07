using VideoGameLibrary.Models;
using VideoGameLibrary.Interface;
using System.Diagnostics.Contracts;

namespace VideoGameLibrary.Data
{
    public class VideoGameDal : IDataAccessLayer
    {
        private AppDbContext db;
        public VideoGameDal(AppDbContext indb)
        {
            db = indb;
        }

        public void addGame(Games game)
        {
            db.Add(game);
            db.SaveChanges();
        }

        public Games getGame(int? id)
        {
            return db.GamesDB.Where(m => m.Id == id).FirstOrDefault();
        }

        public void removeGame(int? id)
        {
            Games foundGame = getGame(id);
            //gameList.Remove(foundGame);
            db.GamesDB.Remove(foundGame);
            db.SaveChanges();

        }

        public IEnumerable<Games> getGames()
        {
            //return gameList;
            return db.GamesDB;
        }

        public void editGame(Games game)
        {
            db.GamesDB.Update(game);
            db.SaveChanges();
        }

        public int getGame(Games game)
        {
            //return gameList.FindIndex(m => m.Id == game.Id);
            //return db.GamesDB.Where()
            return 0;
        }

        public void loanGame(string name, string title)
        {
            foreach (Games game in getGames())
            {
                if (title == game.Title)
                {
                    if (name != null)
                    {
                        game.LoanedTo = name;
                        game.LoanDate = DateTime.Now;
                    }
                    else
                    {
                        game.LoanedTo = string.Empty;
                        game.LoanDate = DateTime.Now; //change
                    }
                }
                db.GamesDB.Update(game);
            }
        }

        public IEnumerable<Games> FilterGames(string? genre, string? esrb, string? platform)
        {
            var games = getGames();
            if (!string.IsNullOrEmpty(genre)) games = games.Where(x => x.Genre.ToLower().Contains(genre.ToLower()));
            if (!string.IsNullOrEmpty(esrb)) games = games.Where(x => x.ESRB.ToLower() == esrb.ToLower());
            if (!string.IsNullOrEmpty(platform)) games = games.Where(x => x.Platform.ToLower().Contains(platform.ToLower()));
            return games;
        }
    }
}