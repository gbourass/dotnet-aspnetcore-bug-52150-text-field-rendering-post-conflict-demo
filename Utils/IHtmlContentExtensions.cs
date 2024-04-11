using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNetWebRenderingBug.Utils;

public static class IHtmlContentExtensions {

    public static IHtmlContent SetFieldName(this IHtmlContent htmlContent, string name) {
        if (htmlContent is TagBuilder tagBuilder) {
            tagBuilder.Attributes["name"] = name;
            return tagBuilder;
        } else {
            throw new Exception("The IHtmlContent must be a TagBuilder.");
        }
    }

    public static IHtmlContent OverrideValue(this IHtmlContent htmlContent, string value) {
        if (htmlContent is TagBuilder tagBuilder) {
            tagBuilder.Attributes["value"] = value;
            return tagBuilder;
        } else {
            throw new Exception("The IHtmlContent must be a TagBuilder.");
        }
    }
}
