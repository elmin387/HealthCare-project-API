using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Domain.Common
{
    public class BaseGridResponse:BaseResponse
    {
        /// <summary>
        /// Total record count so that front-end can know when to stop querying
        /// </summary>
        public int TotalRecords { get; set; } = 0;
        /// <summary>
        /// Total number of pages based on total records and page number
        /// </summary>
        public int TotalPages { get; set; } = 0;
    }
}
