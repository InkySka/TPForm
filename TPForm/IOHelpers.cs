using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMeshEditor
{
    public enum UrgencyLevel
    {
        warning,
        error
    };

    public class WarningString
    {
        private string message;
        UrgencyLevel urgencyLevel;

        /// <summary>
        /// Represent a debug message.
        /// </summary>
        /// <param name="_msg">Message to store.</param>
        /// <param name="_ulvl">Urgency level.</param>
        public WarningString(string _msg, UrgencyLevel _ulvl)
        {
            message = _msg;
            urgencyLevel = _ulvl;
        }

        public override string ToString()
        {
            string output;

            switch (urgencyLevel)
            {
                case UrgencyLevel.warning:
                    {
                        output = "[WARNING] ";
                        break;
                    }
                case UrgencyLevel.error:
                    {
                        output = "[ERROR] ";
                        break;
                    }
                default:
                    {
                        output = "[?] ";
                        break;
                    }
            }
            string.Concat(message);
            return output;
        }
    }
}