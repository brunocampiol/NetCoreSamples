using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreSamples.Common
{
    public class ValidationResult
    {
        /// <summary>
        /// Contains the boolean operation result
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Any additional information
        /// </summary>
        public List<string> ErrorList { get; private set; }

        /// <summary>
        /// Operation result always returns true unless specific marked as false
        /// </summary>
        public ValidationResult()
        {
            ErrorList = new List<string>();
            Success = true;
        }

        public void AddError(string message)
        {
            ErrorList.Add(message);
        }

    }
}
