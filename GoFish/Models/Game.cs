using System.Collections.Generic;
using System;

namespace GoFish.Models
{
  public class Game
  {
    private static List<Player> _players = new List<Player>{};

    private static List<string> _cardDeck = new List<string>{};

    private static List<string> _suites = new List<string>{"Hearts", "Diamonds", "Clubs", "Spades"};
    private static List<string> _values = new List<string>{"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
    public static void AddPlayer(Player player)
    {
      _players.Add(player);
    }
    public static Player FindPlayer(string playerName)
    {
      foreach(Player player in _players)
        {
          if(player.Name == playerName)
          {
            return player;
          }
        }
      return null;
    }
    public static Player FindOtherPlayer(string playerName)
    {
      foreach(Player player in _players)
        {
          if(player.Name != playerName)
          {
            return player;
          }
        }
      return null;
    }
    public static void BuildCardDeck()
    {
      foreach(string suite in _suites)
      {
        foreach(string value in _values)
        {
          _cardDeck.Add($"{value} of {suite}");
        }
      }
    }

    public static void DealCards()
    {
      foreach(Player player in _players)
      {
        for(int i = 0; i < 5; i++)
        {
          DealSingleCard(player);
        }
      }
    }

    public static void DealSingleCard(Player player)
    {
      Random rnd = new Random();
      int randomNumber = rnd.Next(0, _cardDeck.Count);
      player.Hand.Add(_cardDeck[randomNumber]);
      _cardDeck.RemoveAt(randomNumber);
    }

    public static bool isOver()
    {
      if(_cardDeck.Count > 0)
      {
        return false;
      }
      return true;
    }

    public static void ClearGame()
    {
      _cardDeck = new List<string> {};
      _players = new List<Player>{};
    }
  }
}