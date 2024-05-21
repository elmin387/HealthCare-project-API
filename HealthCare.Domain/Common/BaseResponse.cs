using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Domain.Common
{
    public class BaseResponse
    {
        /// <summary>
        /// Indicates if request was successfuly executed
        /// </summary>
        public bool Success { get; set; } = true;
        /// <summary>
        /// Error stack trace
        /// </summary>
        public string? ErrorStackTrace { get; set; }
        /// <summary>
        /// Specific, handeled errors
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();
    }
}
