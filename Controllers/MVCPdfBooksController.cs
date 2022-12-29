using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class MVCPdfBooksController : Controller
    {
        // GET: MVCPdfBooks
        public ActionResult Index()
        {
            return View();
        }

        //@{
        //   string rootNamespace = "MyApp";
        //} 
        //<span>@rootNamespace.Models</span>
        //In this particular case, the hoped-for output was:
        //<span>MyApp.Models</span>
        //Instead, you get an error that there is no Models property of string. In
        //this admittedly edge case, Razor couldn't understand your intent and
        //thought that @rootNamespace.Models was the code expression.
        //Fortunately, Razor also supports explicit code expressions by
        //wrapping them in parentheses:
        //<span>@(rootNamespace).Models</span>
        //This tells Razor that .Models is literal text and not part of the code
        //expression.


        //<li>Item_@item.Length</li>
        //In this particular case, that expression seems to match an e-mail
        //address, so Razor will print it out verbatim.But it just so happens that
        //you expected the output to be something like:
        //<li>Item_3</li>
        //Once again, parentheses to the rescue! Any time there's an ambiguity
        //in Razor, you can use parentheses to be explicit about what you want.
        //You are in control.
        //<li>Item_@(item.Length)</li>



        //We're about to dig into the mechanics of Razor syntax. Before we
        //do, the best advice I can give you is to remember that Razor was
        //designed to be easy and intuitive.For the most part, you don't have
        //to worry about Razor syntax—just write your views as HTML and
        //press the @ sign when you want to insert some code.


        //ASP.NET MVC includes two different view engines: the newer Razor view engine and the older
        //Web Forms view engine.This section covers the Razor view engine,
        //which includes the Razor syntax, layouts, partial views, and so on.

        //ViewBag.CurrentTime = DateTime.Now;
        //Thus, ViewBag.CurrentTime is equivalent to ViewData[”CurrentTime”].
        //Generally, most current code you'll encounter uses ViewBag rather than
        //ViewData.

        //If any parameter is dynamic, compilation will fail.For example, this code will always fail: 
        //@Html.TextBox("name", ViewBag.Name). To work around this, either use ViewData["Name"] or cast the value to a
        //specific type: (string)ViewBag.Name. 


        //An even better approach for namespaces, which you'll end up using often in views, is to declare the namespace in the web.config file within
        //the Views directory.

        //<system.web.webPages.razor>
        //…
        //<pages pageBaseType = "System.Web.Mvc.WebViewPage" >
        //< namespaces >
        //< add namespace="System.Web.Mvc" />
        //<add namespace="System.Web.Mvc.Ajax" />
        //<add namespace="System.Web.Mvc.Html" />
        //<add namespace="System.Web.Routing" />
        //<add namespace="MvcMusicStore.Models" />
        //</namespaces>
        //</pages>
        //</system.web.webPages.razor>


        //As with most things in ASP.NET MVC, you can override this onvention.Suppose that you want the Index action to render a
        //different view.You could supply a different view name, as follows:
        //public ActionResult Index()
        //{
        //  return View("NotIndex");
        //}

        //In some situations, you might even want to specify a view in a completely different directory structure.You can
        //use the tilde syntax to provide the full path to the view, as follows:

        //public ActionResult Index()
        //{
        //    return View("∼/Views/Example/Index.cshtml");
        //}



        //passing a tiny bit of data from the controller to a view.The easiest way
        //to do that is using a ViewBag.ViewBag has limitations, but it can be
        //useful if you're just passing a little data to the view.



        ///////////////////////////////////////////////////////////////////////////////

        //You can also create an instance of HtmlString
        //or use the Html.Raw convenience method:
        //@{
        //            string message = "<strong>This is bold!</strong>";
        //        } <
        //span>@Html.Raw(message)</span>
        //This results in the message being displayed without HTML encoding:
        //Exam-Labs - 100% Real IT Certification Exam Dumps
        //www.exam-labs.com
        //<span><strong>This is bold!</strong></span>
        //This automatic HTML encoding is great for mitigating XSS
        //vulnerabilities by encoding user input meant to be displayed as HTML,
        //but it is not sufficient for displaying user input within JavaScript.For
        //example:

        //When setting variables in JavaScript to values supplied by the user,
        //using JavaScript string encoding and not just HTML encoding is
        //important.Use the @Ajax.JavaScriptStringEncode to encode the input.
        //Here's the same code again using this method to better protect against
        //XSS attacks:
        //<script type = "text/javascript" >
        //$(function()
        //        {
        //            var message = "Hello
        //@Ajax.JavaScriptStringEncode(ViewBag.Username)';
        //$("#message").html(message).show('slow');
        //        });
        //</script>

        ///////////////////////////////////////////////////////////////////////////////////

        //ViewStart
        //In the preceding examples, each view specified its layout page using
        //the Layout property.For a group of views that all use the same layout,
        //this can get a bit redundant and harder to maintain.
        //You can use the _ViewStart.cshtml page to remove this redundancy.
        //The code within this file is executed before the code in any view placed
        //in the same directory.This file is also recursively applied to any view
        //within a subdirectory.
        //When you create a default ASP.NET MVC project, you'll notice a
        //_ViewStart.cshtml file is already in the Views directory.It specifies a
        //default layout:
        //@{
        //Layout = "∼/Views/Shared/_Layout.cshtml";
        //}

        //Because this code runs before any view, a view can override the Layout
        //property and choose a different one. If a set of views shares common
        //settings, the _ViewStart.cshtml file is a useful place to consolidate
        //these common view settings.If any view needs to override any of the
        //common settings, the view can set those values to another value.

        ////////////////////////////////////////////////////////////////////////////////////
        //<form action = "http://www.bing.com/search" method="get">
        //<input name = "q" type="text" />
        //<input type = "submit" value="Search!" />
        //</form>

        //When a user submits a form using an HTTP GET request, the browser
        //takes the input names and values inside the form and puts them in the
        //query string. In other words, the preceding form would send the
        //browser to the following URL(assuming the user is searching for
        //love): http://www.bing.com/search?q=love.

        //To GET or to POST?
        //You can also give the method attribute the value post, in which case the
        //browser does not place the input values into the query string, but
        //places them inside the body of the HTTP request instead.Although
        //you can successfully send a POST request to a search engine and see
        //the search results, an HTTP GET is preferable.

        //Unlike the POST
        //request, you can bookmark the GET request because all the
        //parameters are in the URL.You can use the URLs as hyperlinks in an
        //e-mail or a web page and preserve all the form input values.     

        //Even more importantly, the GET verb is the right tool for the job
        //because GET represents an idempotent, read-only operation.You can
        //send a GET request to a server repeatedly with no ill effects, because a
        //GET does not (or should not) change state on the server.

        //A POST, on the other hand, is the type of request you use to submit a
        //credit card transaction, add an album to a shopping cart, or change a
        //password.A POST request generally modifies state on the server, and
        //repeating the request might produce undesirable effects(such as
        //double billing). Many browsers help a user avoid repeating a POST
        //request.

        //Web applications generally use GET requests for reads and POST
        //requests for writes(which typically include updates, creates, and
        //deletes). A request to pay for music uses POST.A request to search for
        //music, a scenario you look at next, uses GET.


        //HTML HELPERS
        //HTML helpers are methods you can invoke on the Html property of a
        //view.You also have access to URL helpers (via the Url property), and
        //Ajax helpers(via the Ajax property). All these helpers have the same
        //goal: to make views easy to author.The URL helper is also available
        //from within the controller.

        //Most of the helpers, particularly the HTML helpers, output HTML
        //markup.For example, the BeginForm helper you saw earlier is a helper
        //you can use to build a robust form tag for your search form, but
        //without using lines and lines of code:
        //@using(Html.BeginForm("Search", "Home", FormMethod.Get)) {
        //<input type = "text" name="q" />
        //<input type = "submit" value="Search" />
        //}

        //you can also use the following
        //approach, which provides a bit of symmetry:
        //@{Html.BeginForm("Search", "Home", FormMethod.Get);}
        //<input type = "text" name="q" />
        //<input type = "submit" value="Search" />
        //@{Html.EndForm();}


    }
}