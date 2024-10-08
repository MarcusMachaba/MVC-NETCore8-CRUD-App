using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MVC.CRUD.Interface.Extensions;

public static class HMTLHelperExtensions
{
    public static string IsSelected(this IHtmlHelper htmlHelper, string controller = null, string action = null, string cssClass = null)
    {

        if (String.IsNullOrEmpty(cssClass))
            cssClass = "active";

        string currentAction = (string)htmlHelper.ViewContext.RouteData.Values["action"];
        string currentController = (string)htmlHelper.ViewContext.RouteData.Values["controller"];

        if (String.IsNullOrEmpty(controller))
            controller = currentController;

        if (String.IsNullOrEmpty(action))
            action = currentAction;

        return controller == currentController && action == currentAction ?
            cssClass : String.Empty;
    }

    public static string PageClass(this HtmlHelper html)
    {
        string currentAction = (string)html.ViewContext.RouteData.Values["action"];
        return currentAction;
    }

    //EG
    /*
     public static class MyHTMLHelpers
     {
        public static IHtmlContent HelloWorldHTMLString(this IHtmlHelper htmlHelper)
            => new HtmlString("<strong>Hello World</strong>");

        public static String HelloWorldString(this IHtmlHelper htmlHelper)
            => "<strong>Hello World</strong>";
     }
     */

}
