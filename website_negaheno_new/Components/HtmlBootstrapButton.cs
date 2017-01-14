using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace website_negaheno
{
    public static class HtmlBootstrapButton
    {
        public static MvcHtmlString BootstrapButton(this HtmlHelper htmlHelper, string innerHtml, string cssClass
        , object htmlAttributes = null)
        {
            return BootstrapButton(htmlHelper, innerHtml, cssClass, "", HtmlCommonProperty.ButtonType.button, "", htmlAttributes);
        }

        public static MvcHtmlString BootstrapButton(this HtmlHelper htmlHelper, string innerHtml, string cssClass
       , string name, object htmlAttributes = null)
        {
            return BootstrapButton(htmlHelper, innerHtml, cssClass, name, HtmlCommonProperty.ButtonType.button, "", htmlAttributes);
        }

        public static MvcHtmlString BootstrapButton(this HtmlHelper htmlHelper, string innerHtml, string cssClass
      , string name, HtmlCommonProperty.ButtonType buttonType, object htmlAttributes = null)
        {
            return BootstrapButton(htmlHelper, innerHtml, cssClass, name, buttonType, "", htmlAttributes);
        }
      
        public static MvcHtmlString BootstrapButton(this HtmlHelper htmlHelper, string innerHtml, string cssClass
        , string name, HtmlCommonProperty.ButtonType buttonType, string title, object htmlAttributes = null)
        {
            TagBuilder tb = new TagBuilder("button");

            if (!string.IsNullOrEmpty(cssClass))
            {
                if (!cssClass.Contains("btn-"))
                {
                    cssClass = "btn-primary " + cssClass;
                }
            }
            else
                cssClass = "btn-primary";

            tb.AddCssClass(cssClass);
            tb.AddCssClass("btn");

            tb.InnerHtml = innerHtml;

            HtmlCommonProperty.AddIdName(tb, name, "");

            switch (buttonType)
            {
                case HtmlCommonProperty.ButtonType.button:
                    tb.MergeAttribute("type", "button");
                    break;
                case HtmlCommonProperty.ButtonType.submit:
                    tb.MergeAttribute("type", "submit");
                    break;
                case HtmlCommonProperty.ButtonType.reset:
                    tb.MergeAttribute("type", "reset");
                    break;
            }

            if (!string.IsNullOrEmpty(title))
                tb.MergeAttribute("title", title);

            tb.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            return MvcHtmlString.Create(tb.ToString());

        }
    }
}