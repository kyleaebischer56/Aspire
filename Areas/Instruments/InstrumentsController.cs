using Aspire.Areas.Instruments.Data.Commands;
using Aspire.Areas.Instruments.Data.Queries;
using Aspire.Areas.Instruments.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
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
            //var makes = await _mediator.Send(new GetMakes());

            //var programs = await _mediator.Send(new GetPrograms());

            return View(new CreateInstrumentViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInstrumentViewModel createInstrumentViewModel)
        {
            //return View(instrument);

            if (!ModelState.IsValid)
            {
                return View(createInstrumentViewModel);
            }

            var instrumentId = await _mediator.Send(CreateInstrument.With(createInstrumentViewModel));

            //var instrumentId = 1;
            if(instrumentId == 0)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<JsonResult> GetModelsByMake(int makeId)
        {
            //This will eventually be a call to the DB to actually get the models for the given make
            //var makes = new List<SelectListItem>
            //{
            //    //The Value property represents the Models ID in the DB
            //    new SelectListItem { Value = 1.ToString(), Text = "Trumpet 1" },
            //    new SelectListItem { Value = 2.ToString(), Text = "Drumset 1" }
            //};

            var makes = await _mediator.Send(new GetModelsByMake(makeId));

            return Json(makes);
        }

        [HttpGet]
        public async Task<JsonResult> GetStudentsByProgram(int programId)
        {
            //This will eventually be a call to the DB to actually get the models for the given make
            var students = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Jessica Smith" },
                new SelectListItem { Value = "2", Text = "Thomas Cook" }
            };

            //To simulate the DB call
            await Task.Delay(3000);

            return Json(students);
        }
    }
}