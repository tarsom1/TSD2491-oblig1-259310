using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TSD2491_oblig1_259310.Models;

namespace TSD2491_oblig1_259310.Controllers
{
	public class HomeController : Controller
	{
		private readonly static MatchinggameModel _matchingGameModels = new MatchinggameModel();



        public HomeController()
        {
			
		}

		public IActionResult Index()
		{
			return View(_matchingGameModels);
		}

       
	}
}
