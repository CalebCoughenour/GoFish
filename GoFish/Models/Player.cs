using System.Collections.Generic;
namespace GoFish.Models
{
  public class Player
  {
    public List<string> Hand {get; set;}
    public List<string> Pairs {get; set;}
    public string Name {get; set;}
    public int Score {get; set;}

    public Player(string name)
    {
      Name = name;
      Hand = new List<string>{};
      Pairs = new List<string>{};
      Score = 0;
    }

    public void MakePairs()
    {
      List<string> pair = new List<string>{};
      int total = 0;
      string firstLetter= "";
      foreach(string card in Hand)
      {
        firstLetter = card.Substring(0, 1);
        
        for(int i = 0; i < Hand.Count; i++)
        {
          if(Hand[i].Substring(0, 1) == firstLetter)
          {
            total++;
          }
          if(total == 4)
          {
            break;
          }
        }
      }
      if(total == 4)
        {
          Pairs.Add(firstLetter);
          int cardCount = Hand.Count;
          List<string> removeCardList = new List<string>{};
          for(int i = 0; i < cardCount; i++)
          {
            if(Hand[i].Substring(0, 1) == firstLetter)
            {
              removeCardList.Add(Hand[i]);
            }
          }
          foreach(string cardDelete in removeCardList)
          {
            Hand.Remove(cardDelete);
          }
          Score++;
        }
    }

    public bool TransferCards(string card, Player otherPlayer)
    {
      string firstLetter = card.Substring(0, 1);
      foreach(string cardInHand in Hand)
      {
        if(firstLetter == cardInHand.Substring(0, 1))
        {
          otherPlayer.Hand.Add(cardInHand);
          Hand.Remove(cardInHand);
          return false;
        }
      }
      return true;
    }
  }
}

