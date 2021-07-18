using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloASPDotNET.Controllers
{
    [Route("/helloworld/")]
    public class HelloController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method= 'post' action='/helloworld/'>" + "<input type='text' name= 'name' /> " + "<select name='language' id='languages'>"+"<option vaule='english'>English</option>"+ "<option vaule='spanish'>Spanish</option>" + "<option vaule='portuguese'>Portuguese</option>" + "<option vaule='chinese'>Chinese</option>"+ "<option vaule='japanese'>Japanese</option>" +"</select>" + "<input type= 'submit' value= 'Greet Me!' />" + "</form>";
            return Content(html, "text/html");
        }


        public static string CreateMessage(string name, string language)
        {
            language = language.ToLower();
            string greetLang = language == "english" ? "Hello" : language == "spanish" ? "Hola" : language == "portuguese" ? "Ola" : language == "chinese" ? "Ni Hao" : "Ko nichi wa";
            string fullGreet = greetLang + " " + name;
            return fullGreet;
        }

        //GET
        //[HttpGet]
        //[Route("/helloworld/welcome/{name?}")]
        [HttpGet("welcome/{name?}")]
        [HttpPost]
        public IActionResult Welcome(string name = "World", string language = "english")
        {
            string msg = CreateMessage(name, language);

            return Content($"<h1>{msg}!</h1>", "text/html");
        }
    }
}
