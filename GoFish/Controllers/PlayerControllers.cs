using Microsoft.AspNetCore.Mvc;
using GoFish.Models;
using System.Collections.Generic;

namespace GoFish.Controllers
{
  public class PlayerController : Controller
  {
    [HttpGet("/player/new")]
    public ActionResult New()
    {
      return View();
    }
  }
}