using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Chess;

namespace ChessTest
{
    public class ChessGameTest : IDisposable
    {
        public Game Game;
        public ChessGameTest()
        {
            Game = new Game();
        }

        public void Dispose()
        {
        }

        [Fact]
        public void CreatesGameInstance()
        {
            Assert.NotNull(Game);
        }

        [Fact]
        public void GameShouldHaveOnlyTwoPlayers()
        {
            var players = new List<IPlayer>();
            players.Add(Game.GetCurrentPlayer());
            Game.MakeRound();
            players.Add(Game.GetCurrentPlayer());
            Game.MakeRound();
            players.Add(Game.GetCurrentPlayer());
            int uniquePlayersCount = (from player in players select player).Distinct().Count();
            
            Assert.Equal(2, uniquePlayersCount);
        }
        
        [Fact]
        public void GameShouldChangePlayerEachRound()
        {
            var player1 = Game.GetCurrentPlayer();
            Game.MakeRound();
            var player2 =  Game.GetCurrentPlayer();
            
            Assert.NotEqual(player1, player2);
        }

    }
}