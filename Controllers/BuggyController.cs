using DotNetWebRenderingBug.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebRenderingBug.Controllers;

[Route("/Buggy")]
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
        return View("_View", data);
    }
}
