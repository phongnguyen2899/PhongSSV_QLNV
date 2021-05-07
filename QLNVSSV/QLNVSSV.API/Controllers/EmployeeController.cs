using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using QLNVSSV.DATA.Interfaces;
using QLNVSSV.Models.Modes;
using QLNVSSV.Models.ViewModel;
using System.IO;

namespace QLNVSSV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseAPIController<Employee>
    {
        private IWebHostEnvironment _hostingEnvironment;

        private readonly IEmployeeRepository _employeeRepository;


        public EmployeeController(IEmployeeRepository employeeRepository,IWebHostEnvironment environment,IBaseRepository<Employee> baseRepository):base(baseRepository)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = environment;
        }

        
        /// <summary>
        /// Get employee by status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet("GetEmployeeStatus/{status}")]
        public IActionResult GetEmployeeStatus(int status)
        {
            var data = _employeeRepository.GetEmployeebyStatus(status);

            return Ok(data);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet("GetEmployeeSendMail/{status}")]
        public IActionResult GetEmployeeSendMail(int status)
        {
            var data = _employeeRepository.GetEmployeeSendMail(status);

            return Ok(data);
        }

        /// <summary>
        /// update status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet("UpdateStatus/{id}/{status}")]
        public IActionResult UpdateStatus(int id,int status)
        {
            var result = _employeeRepository.UpdateStatusEmployee(id, status);

            return Ok(result);
        }
        
        /// <summary>
        /// dowload file 
        /// </summary>
        /// <param name="pathfile"></param>
        /// <returns></returns>
        [HttpGet("Dowloadfile/{pathfile}")]
        public FileResult Dowloadfile(string pathfile)
        {
            string path = Path.Combine(this._hostingEnvironment.WebRootPath, "Image/") + pathfile;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/pdf", pathfile);
        }

        /// <summary>
        /// Get Employee fillter
        /// </summary>
        /// <param name="approvalFillterViewModel"></param>
        /// <returns></returns>
        [HttpPost("GetbyfilterAproval")]
        public IActionResult GetbyfilterAproval([FromBody]ApprovalFillterViewModel approvalFillterViewModel)
        {
            var data = _employeeRepository.GetbyfilterAproval(approvalFillterViewModel);
            return Ok(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateSolidarityViewModel"></param>
        /// <returns></returns>
        [HttpPut("UpdateSolidarity")]
        public IActionResult UpdateSolidarity([FromBody]UpdateSolidarityViewModel updateSolidarityViewModel)
        {
            var result = _employeeRepository.UpdateSolidarity(updateSolidarityViewModel.employeeId,updateSolidarityViewModel.solidarity,updateSolidarityViewModel.interviewtime);
            return Ok(result);
        }

        /// <summary>
        /// update schedule
        /// </summary>
        /// <param name="updateScheduleViewModel"></param>
        /// <returns></returns>
        [HttpPut("UpdateSchedule")]
        public IActionResult UpdateSchedule([FromBody] UpdateScheduleViewModel updateScheduleViewModel)
        {
            var result = _employeeRepository.UpdateSchedule(updateScheduleViewModel);
            return Ok(result);
        }
    }
}
