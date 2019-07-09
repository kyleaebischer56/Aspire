using Aspire.Areas.Instruments.Data.Commands;
using Aspire.Areas.Instruments.Data.Queries;
using Aspire.Areas.Instruments.Models;
using Aspire.Areas.Instruments.ViewModels;
using Aspire.Areas.Shared.Data.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspire.Areas.Instruments
{
    public class InstrumentsController : Controller
    {
        private readonly IMediator _mediator;

        public InstrumentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult UnderConstruction()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var makes = await _mediator.Send(new GetMakes());

            var programs = await _mediator.Send(new GetPrograms());

            return View(new CreateInstrumentViewModel(makes, programs));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInstrumentViewModel createInstrumentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createInstrumentViewModel);
            }

            var instrument = new Instrument(createInstrumentViewModel);

            var instrumentId = await _mediator.Send(CreateInstrument.With(instrument));

            if(instrumentId == 0)
            {
                return View("~/Shared/Views/Shared/Error.cshtml");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<JsonResult> GetModelsByMake(int makeId)
        {
            var models = await _mediator.Send(new GetModelsByMake(makeId));

            var makesSelectListItems = new List<SelectListItem>(models.Count());

            foreach(var model in models)
            {
                makesSelectListItems.Add(new SelectListItem(model.ModelNumber, model.Id.ToString()));
            }

            return Json(makesSelectListItems);
        }

        [HttpGet]
        public async Task<JsonResult> GetStudentsByProgram(int programId)
        {
            var students = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Jessica Smith" },
                new SelectListItem { Value = "2", Text = "Thomas Cook" }
            };

            return Json(students);
        }
    }
}