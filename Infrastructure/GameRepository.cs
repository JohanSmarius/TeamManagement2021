using System;
using System.Collections.Generic;
using Core.Domain;

namespace Infrastructure
{
    public class GameRepository
    {
        public List<Game> Games { get; set; }

        public GameRepository()
        {
        }

        public IEnumerable<Game> GetAll() => Games;

        public IEnumerable<Game> GetAllHomeGames()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetAllExternalGames()
        {
            throw new NotImplementedException();
        }

    }
}
