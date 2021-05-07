using QLNVSSV.DATA.Interfaces;
using QLNVSSV.Models.Modes;
using QLNVSSV.Models.ViewModel;
using QLNVSSV.ViewModels.Common;
using System;
using System.Collections.Generic;

namespace QLNVSSV.DATA.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        protected IDatabaseContext<EmployeeUpdateViewModel> _databaseContextuc;
        public EmployeeRepository(IDatabaseContext<EmployeeUpdateViewModel> databaseContextuc, IDatabaseContext<Employee> databaseContext) : base(databaseContext)
        {
            _databaseContextuc = databaseContextuc;
        }

        /// <summary>
        /// lay danh sach employee theo trang thai cv
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public IEnumerable<Employee> GetEmployeebyStatus(int status)
        {
            var procGetByStatus = $"Proc_GetByStatus @status ";
            var param = new object[] { status };
            var data = base.GetByProc(procGetByStatus, param);
            return data;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public ServiceResponse UpdateStatusEmployee(int employeeId, int status)
        {
            var procUpdateStatus = $"Proc_UpdateStatus @employeeId , @status ";
            var param = new object[] { employeeId, status };
            var result = base.Update(procUpdateStatus, param);

            return result;
        }

        public IEnumerable<Employee> GetbyfilterAproval(ApprovalFillterViewModel approvalFillterViewModel)
        {
            var procFilterApproval = $"Proc_GetbyFilterApproval @keyword , @positionId , @titleId";
            var param = new object[] { approvalFillterViewModel.EmployeeName, approvalFillterViewModel.Position, approvalFillterViewModel.Title };
            return base.GetByProc(procFilterApproval, param);
        }

        public IEnumerable<Employee> GetEmployeeSendMail(int status)
        {
            var procFilterApproval = $"Proc_GetEmployeeSendMail @status ";
            var param = new object[] { status };
            return base.GetByProc(procFilterApproval, param);
        }

        public ServiceResponse UpdateSolidarity(int employeeId, int solidarity,DateTime interviewtime)
        {
            if (solidarity > 2 || solidarity < 0)
            {
                var serviceResponse = new ServiceResponse();
                serviceResponse.Success = false;
                serviceResponse.Msg.Add("Thất bại");
                return serviceResponse;
            }
            var procUpdateSolidarity = $"Proc_UpdateSolidarity @employeeId , @solidarity , @interviewtime ";
            var param = new object[] { employeeId, solidarity,interviewtime };
            var result = base.Update(procUpdateSolidarity, param);

            return result;
        }

        public ServiceResponse UpdateSchedule(UpdateScheduleViewModel updateScheduleViewModel)
        {
            var procUpdateSolidarity = $"Proc_UpdateSchedule @employeeId , @inter , @interviewTime , @interviewAddress ";
            var param = new object[] { updateScheduleViewModel.EmployeeId,updateScheduleViewModel.InterviewerId,updateScheduleViewModel.InterviewTime,updateScheduleViewModel.InterviewAddress };
            var result = base.Update(procUpdateSolidarity, param);
            return result;
        }
    }
}
