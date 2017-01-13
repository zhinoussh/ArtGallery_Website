using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace website_negaheno
{
    public static class HtmlAddOnTextBoxFor
    {

        public static MvcHtmlString AddOnTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
    Expression<Func<TModel, TValue>> bindingExpression, string textboxId, string buttonCss, string buttonInnerHtml)
        {
            return AddOnTextBoxFor(htmlHelper, bindingExpression, textboxId, "", "","", buttonCss, buttonInnerHtml);
        }

        public static MvcHtmlString AddOnTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
           Expression<Func<TModel, TValue>> bindingExpression, string textboxId, string buttonId, string buttonCss, string buttonInnerHtml)
        {
            return AddOnTextBoxFor(htmlHelper, bindingExpression,textboxId,"","" ,buttonId, buttonCss, buttonInnerHtml);
        }

        public static MvcHtmlString AddOnTextBoxFor<TModel,TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel,TValue>> bindingExpression,string textboxId,string textboxCss,string placeHolder,
            string buttonId,string buttonCss,string buttonInnerHtml)
        {
            StringBuilder final_sb = new StringBuilder();

            //Add Button
            MvcHtmlString btn = HtmlBootstrapButton.BootstrapButton(htmlHelper, buttonInnerHtml, buttonCss,buttonId);

            TagBuilder tb_span_inputGroup = new TagBuilder("span");
            tb_span_inputGroup.MergeAttribute("class","input-group-btn");
            tb_span_inputGroup.InnerHtml = btn.ToHtmlString();

            //Add textbox
            MvcHtmlString textbox = HtmlTextBoxFor.BootstrapTextBoxFor(htmlHelper, bindingExpression, textboxId,
                                                                         placeHolder,"", textboxCss);
            final_sb.Append(textbox.ToHtmlString());
            final_sb.Append(tb_span_inputGroup);

            //Add input-group div
            TagBuilder tb_outer_div=new TagBuilder("div");
            tb_outer_div.AddCssClass("input-group");
            tb_outer_div.InnerHtml=final_sb.ToString();

            return MvcHtmlString.Create(tb_outer_div.ToString());
        }
    }
}