using System;
using System.Linq.Expressions;
using System.Web.Mvc;

// Chrome alt+title BUG

namespace EasyLOB.Environment
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString ZHidden(this HtmlHelper htmlHelper,
            bool value,
            string name,
            string id)
        {
            string tag = String.Format("<input id=\"{0}\" name=\"{1}\" type=\"hidden\" value=\"{2}\">",
                id,
                name,
                value);

            return new MvcHtmlString(tag);
        }

        public static MvcHtmlString ZHiddenFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string id)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            TagBuilder tagBuilder = new TagBuilder("input");
            tagBuilder.Attributes.Add("id", id);
            tagBuilder.Attributes.Add("name", name);
            tagBuilder.Attributes.Add("type", "hidden");
            tagBuilder.Attributes.Add("value", metadata.Model == null ? null : metadata.Model.ToString());

            return new MvcHtmlString(tagBuilder.ToString());
        }

        public static MvcHtmlString ZImage(this HtmlHelper htmlHelper,
            string id,
            string imageClass,
            string imageTitle,
            string onClick)
        {
            //string tag = String.Format("<img id=\"{0}\" alt=\"{2}\" class=\"{1}\" title=\"{2}\" onclick=\"{3}\">",
            string tag = String.Format("<img id=\"{0}\" class=\"{1}\" title=\"{2}\" onclick=\"{3}\">",
                id,
                imageClass,
                imageTitle,
                onClick);

            return new MvcHtmlString(tag);
        }

        public static MvcHtmlString ZImageInput(this HtmlHelper htmlHelper,
            string id,
            string imageClass,
            string imageTitle)
        {
            //string tag = String.Format("<input id=\"{0}\" class=\"{1}\" title=\"{2}\" type=\"image\">",
            string tag = String.Format("<input id=\"{0}\" class=\"{1}\" title=\"{2}\" type=\"submit\">",
                id,
                imageClass,
                imageTitle);

            return new MvcHtmlString(tag);
        }

        public static MvcHtmlString ZImageInput(this HtmlHelper htmlHelper,
            string id,
            string imageClass,
            string imageTitle,
            string onClick)
        {
            if (String.IsNullOrEmpty(onClick))
            {
                return ZImageInput(htmlHelper, id, imageClass, imageTitle);
            }
            else
            {
                //string tag = String.Format("<input id=\"{0}\" class=\"{1}\" title=\"{2}\" type=\"image\" onclick=\"{3}\">",
                string tag = String.Format("<input id=\"{0}\" class=\"{1}\" title=\"{2}\" type=\"submit\" onclick=\"{3}\">",
                    id,
                    imageClass,
                    imageTitle,
                    onClick);

                return new MvcHtmlString(tag);
            }
        }

        public static MvcHtmlString ZImageLink(this HtmlHelper htmlHelper,
            string id,
            string imageClass,
            string imageTitle,
            string uri)
        {
            //string tag = String.Format("<a id=\"{0}\" href=\"{1}\"><img alt=\"{3}\" class=\"{2}\" title=\"{3}\"></a>",
            string tag = String.Format("<a id=\"{0}\" href=\"{1}\"><img class=\"{2}\" title=\"{3}\"></a>",
                id,
                uri,
                imageClass,
                imageTitle);

            return new MvcHtmlString(tag);
        }

        public static MvcHtmlString ZNewLine(this HtmlHelper htmlHelper)
        {
            return new MvcHtmlString("<div style=\"clear: both;\"></div>");
        }

        public static MvcHtmlString ZOperationResult(this HtmlHelper htmlHelper,
            ZOperationResult operationResult)
        {
            return new MvcHtmlString(operationResult.Html);
        }

        public static MvcHtmlString ZResolveUrl(this HtmlHelper htmlHelper, string url)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            return new MvcHtmlString(urlHelper.Content(url));
        }
    }
}