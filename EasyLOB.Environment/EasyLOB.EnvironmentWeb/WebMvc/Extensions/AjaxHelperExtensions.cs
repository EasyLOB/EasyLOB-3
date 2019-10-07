using System;
using System.Web.Mvc;

// AjaxExtensions.ActionLink Method
// https://msdn.microsoft.com/en-us/library/system.web.mvc.ajax.ajaxextensions.actionlink%28v=vs.118%29.aspxv

// +------------------------+-----------------------------+
// |      AjaxOptions       |       HTML attribute        |
// +------------------------+-----------------------------+
// | Confirm                | data-ajax-confirm           |
// | HttpMethod             | data-ajax-method            |
// | InsertionMode          | data-ajax-mode              |
// | LoadingElementDuration | data-ajax-loading-duration  |
// | LoadingElementId       | data-ajax-loading           |
// | OnBegin                | data-ajax-begin             |
// | OnComplete             | data-ajax-complete          |
// | OnFailure              | data-ajax-failure           |
// | OnSuccess              | data-ajax-success           |
// | UpdateTargetId         | data-ajax-update            |
// | Url                    | data-ajax-url               |
// +------------------------+-----------------------------+

// Chrome alt+title BUG

namespace EasyLOB.Environment
{
    public static class AjaxHelperExtensions
    {
        public static MvcHtmlString ZImageLink(this AjaxHelper ajaxHelper,
            string id,
            string uri,
            string updateTargetId,
            string imageClass,
            string imageTitle)
        {
            //string tag = String.Format("<a id=\"{0}\" data-ajax=\"true\" data-ajax-mode=\"replace\" data-ajax-update=\"#{1}\" href=\"{2}\"><img alt=\"{4}\" class=\"{3}\" title=\"{4}\" /></a>",
            string tag = String.Format("<a id=\"{0}\" data-ajax=\"true\" data-ajax-mode=\"replace\" data-ajax-update=\"#{1}\" data-ajax-complete=\"zAjaxLoadComplete\" href=\"{2}\"><img class=\"{3}\" title=\"{4}\" /></a>",
                id,
                updateTargetId,
                uri,
                imageClass,
                imageTitle);

            return new MvcHtmlString(tag);
        }
        /*
        public static MvcHtmlString ZImageLink(this AjaxHelper ajaxHelper,
            string id,
            string uri,
            string updateTargetId,
            string imageClass,
            string imageTitle,
            string onComplete)
        {
            string tag = String.Format("<a id=\"{0}\" data-ajax=\"true\" data-ajax-mode=\"replace\" data-ajax-update=\"#{1}\" data-ajax-complete=\"{5}\" href=\"{2}\"><img class=\"{3}\" title=\"{4}\" /></a>",
                id,
                updateTargetId,
                uri,
                imageClass,
                imageTitle,
                onComplete);

            return new MvcHtmlString(tag);
        }
        */
    }
}