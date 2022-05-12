using Microsoft.AspNetCore.Mvc;
using GoFish.Models;
using System.Collections.Generic;

namespace GoFish.Controllers
{
  public class GameController : Controller
  {
    [HttpPost("/game")]
    public ActionResult Create(string name1, string name2)
    {
      Game.ClearGame();
      Player player1 = new Player(name1);
      Player player2 = new Player(name2);
      Game.AddPlayer(player1);
      Game.AddPlayer(player2);
      Game.BuildCardDeck();
      Game.DealCards();
      return Redirect($"/game/show/{player1.Name}");;
    }
    [HttpGet("/game/show/{playerName}")]
    public ActionResult Show(string playerName)
    {
      Player player = Game.FindPlayer(playerName);
      return View(player);
    }
    [HttpPost("/game/turn")]
    public ActionResult MakeTurn(string card, string playerName)
    {
      Player player = Game.FindPlayer(playerName);
      Player otherPlayer = Game.FindOtherPlayer(playerName);
      bool goFish = otherPlayer.TransferCards(card, player);
      if(goFish == true && Game.isOver() != true)
      {
        Game.DealSingleCard(player);
      }
      player.MakePairs();
      return Redirect($"/game/show/{otherPlayer.Name}");
    }
  }
}