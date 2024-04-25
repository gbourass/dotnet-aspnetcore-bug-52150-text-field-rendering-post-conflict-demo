using DotNetWebRenderingBug.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DotNetWebRenderingBug.Controllers;

[Route("/Buggy")]
[ValidateParametersAndClearModelStateActionFilter] // Adding this line fixes the issue.
public class BuggyController : Controller {

    [HttpGet]
    public IActionResult EditValue() {
        return View("_View", DataModel.SampleData);
    }

    /// <remark>
    /// The reason why the POST doesn't properly render the same view with the same data as the GET is because ModelState is filled with the form values.
    /// If any field is rendered without the full name and a value with the same name matches in the ModelState, the value explicitly given to the renderer
    /// is ignored and overridden by the one from the model state.
    /// </remark>
    [HttpPost]
    public IActionResult EditValuePost([FromForm] DataModel data) {
        // ModelState.Clear(); // Adding this line fixes the issue.
        return View("_View", data);
    }
}

public class ValidateParametersAndClearModelStateActionFilterAttribute : ActionFilterAttribute {
    public override void OnActionExecuting(ActionExecutingContext filterContext) {
        var controller = filterContext.Controller as ControllerBase;
        if (controller == null) return;
        var firstError = controller.ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid);
        if (firstError != null) throw new Exception(firstError.Errors.First().ErrorMessage);
        controller.ModelState.Clear();
    }
}
