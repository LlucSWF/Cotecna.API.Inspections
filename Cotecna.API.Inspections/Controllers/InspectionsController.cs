using AutoMapper;
using Cotecna.API.Inspections.ViewModels;
using Cotecna.Inspections.Data.Repositories;
using Cotecna.Inspections.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace Cotecna.API.Inspections.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InspectionsController : ControllerBase
    {

        private readonly ILogger<InspectionsController> _logger;

        private IInspectionRepository InspectionRepo { get; set; }
        private IInspectorRepository InspectorRepo { get; set; }
        private IMapper Mapper { get; set; }

        public InspectionsController(ILogger<InspectionsController> logger, IInspectorRepository inspectorRepo, IInspectionRepository inspectionRepo, IMapper mapper)
        {
            InspectorRepo = inspectorRepo;
            InspectionRepo = inspectionRepo;
            _logger = logger;
            Mapper = mapper;
        }


        /// <summary>
        /// Returns all inspectors
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<InspectorInfoViewModel>), 200)]
        [HttpGet("/inspectors")]
        public IActionResult GetInspectors()
        {
            var items =  InspectorRepo.GetAll();

            var mappedItems = Mapper.Map<List<InspectorInfoViewModel>>(items);
            return new JsonResult(mappedItems);
        }


        /// <summary>
        /// Returns inspectors available in a specific date
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<InspectorInfoViewModel>), 200)]
        [HttpGet("/inspectors/available")]
        public IActionResult GetAvailable([FromQuery] DateTime date)
        {
            var items = InspectorRepo.getAvailableOnDate(date);

            var mappedItems = Mapper.Map<List<InspectorInfoViewModel>>(items);
            return new JsonResult(mappedItems);
        }

        /// <summary>
        /// Creates a new inspector and returns its Id
        /// </summary>
        /// <returns></returns>
        [HttpPost("/inspector")]
        [ProducesResponseType(typeof(int), 200)]

        public IActionResult PostInspector([FromBody] InspectorInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbModel = Mapper.Map<InspectorInfo>(model);

                var result = InspectorRepo.Create(dbModel);
                return new JsonResult(result.Id);
            }
            return BadRequest(ModelState);
        }


        /// <summary>
        /// Returns all inspections from an inspector within a specified date.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/inspections")]
        [ProducesResponseType(typeof(List<InspectorInfoViewModel>), 200)]
        public IActionResult GetInspection([FromQuery] int inspectorId, [FromQuery] DateTime date)
        {
            var items = InspectionRepo.getWithInspectorIdAndDate(inspectorId, date);

            var mappedItems = Mapper.Map<List<InspectionViewModel>>(items);
            return new JsonResult(mappedItems);
        }


        /// <summary>
        /// Creates an inspection and returns its id
        /// </summary>
        /// <returns></returns>
        [HttpPost("/inspection")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult PostInspection([FromBody] InspectionCreationViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (!CheckIfDateIsFuture(model.ScheduledDate))
                    return BadRequest("The date needs to be in the future.");

                var dbModel = Mapper.Map<Inspection>(model);

                var result = InspectionRepo.Create(dbModel);
                return new JsonResult(result.Id);
            }
            return BadRequest(ModelState);
        }


        /// <summary>
        /// Change the date for an existing inspection
        /// </summary>
        /// <returns></returns>
        [HttpPatch("/inspection/date")]
        public IActionResult PatchInspectionDate([FromQuery] int id, [FromQuery] DateTime date)
        {
            if (ModelState.IsValid)
            {
                if (!CheckIfDateIsFuture(date))
                    return BadRequest("The date needs to be in the future.");

                InspectionRepo.UpdateField(id, "ScheduledDate", date);
                return Ok();
            }
            return BadRequest(ModelState);
        }


        /// <summary>
        /// Changes an inspection into "Cancelled" state.
        /// </summary>
        /// <returns></returns>
        [HttpPatch("/inspection/cancel")]
        public IActionResult CancelInspection([FromQuery] int id)
        {
            if (ModelState.IsValid)
            {
                InspectionRepo.UpdateField(id, "Cancelled", true);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        private bool CheckIfDateIsFuture(DateTime date)
        {
            return date > DateTime.Now;
        }
    }
}
