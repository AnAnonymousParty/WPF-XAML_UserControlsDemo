/*
 * This file is part of WPF-XAML_UserControlsDemo.
 *
 * WPF-XAML_UserControlsDemo is free software: you can redistribute it and/or 
 * modify it under the terms of the GNU General Public License as published by 
 * the Free Software Foundation, either version 3 of the License, or (at your 
 * option) any later version.
 *
 * WPF-XAML_UserControlsDemo is distributed in the hope that it will be useful, 
 * but WITHOUT  ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
 * or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for 
 * more details.
 *
 * You should have received a copy of the GNU General Public License along with
 * WPF-XAML_UserControlsDemo. If not, see <https://www.gnu.org/licenses/>. 
 */

using System;
using System.ComponentModel;


namespace SimpleMVVMUserControlDemo.Utils.Diagnostics
{
    /// <summary>
    /// LogMessage.
    /// 
    /// A container for a diagnostic log message.
    /// </summary>
    public class LogMessage
    {
        /// <summary>
        /// Log message severity level.
        /// </summary>
        public enum Severity
        {
            [Description("Debug")]
            eDebug,
            [Description("Fatal")]
            eFatal,
            [Description("Info")]
            eInfo,
            [Description("Undefined")]
            eUndefined,
            [Description("Warning")]
            eWarning
        };

        /// <summary>
        /// Log message type.
        /// </summary>
        public enum LogMessageType
        {
            [Description("Bad Enumeration")]
            eBadEnum,
            [Description("SubCall")]
            eSubCall,
            [Description("SubInfo")]
            eSubInfo,
            [Description("SubExit")]
            eSubExit,
            [Description("Undefined")]
            eUndefined
        };


        private DateTime _now;

        private LogMessageType _logMsgType;

        private Severity _severity;

        private String _className;
        private String _function;
        private String _message;
        private String _parmsOrRetVal;

        private UInt32 _enumType;
        private UInt32 _enumVal;

        /// <summary>
        /// Constructor (default).
        /// </summary>
        public LogMessage()
        {
            _logMsgType = LogMessageType.eUndefined;
            _now = DateTime.Now;
            _severity = Severity.eUndefined;
        }

        /// <summary>
        /// Constructor, given:
        /// </summary>
        /// <param name="severity"></param>
        /// <param name="logMsgType"></param>
        /// <param name="className"></param>
        /// <param name="function"></param>
        /// <remarks>Use this constructor for logging a function call or return, without parameters or return value.</remarks>
        public LogMessage(Severity severity,
                        LogMessageType logMsgType,
                        String className,
                        String function)
        {
            _className = className;
            _function = function;
            _logMsgType = logMsgType;
            _now = DateTime.Now;
            _severity = Severity.eUndefined;
        }

        /// <summary>
        /// Constructor, given:
        /// </summary>
        /// <param name="severity"></param>
        /// <param name="logMsgType"></param>
        /// <param name="className"></param>
        /// <param name="function"></param>
        /// <param name="message"></param>
        /// <param name="parmsOrRetVal"></param>
        /// <remarks>Use this constructor for logging a function call or return, with parameters or return value.</remarks>
        public LogMessage(Severity severity, 
                            LogMessageType logMsgType, 
                            String className, 
                            String function, 
                            String message, 
                            String parmsOrRetVal)
        {
            _className = className;
            _function = function;
            _logMsgType = logMsgType;
            _message = message;
            _now = DateTime.Now;
            _parmsOrRetVal = parmsOrRetVal;
            _severity = severity;
        }

        /// <summary>
        /// Constructor, given:
        /// </summary>
        /// <param name="severity"></param>
        /// <param name="logMsgType"></param>
        /// <param name="className"></param>
        /// <param name="function"></param>
        /// <param name="message"></param>
        /// <remarks>Use this constructor for logging an information message.</remarks>
        public LogMessage(Severity severity,
            LogMessageType logMsgType,
            String className,
            String function,
            String message)
        {
            _className = className;
            _function = function;
            _logMsgType = logMsgType;
            _message = message;
            _now = DateTime.Now;
            _severity = severity;
        }

        /// <summary>
        /// Constructor, given:
        /// </summary>
        /// <param name="severity"></param>
        /// <param name="className"></param>
        /// <param name="function"></param>
        /// <param name="message"></param>
        /// <param name="enumType"></param>
        /// <param name="enumVal"></param>
        /// <remarks>Use this constructor for logging a bad enumeration.</remarks>
        public LogMessage(Severity severity, 
            String className, 
            String function, 
            String message, 
            UInt32 enumType, 
            UInt32 enumVal)
        {
            _className = className;
            _enumType = enumType;
            _enumVal = enumVal;
            _function = function;
            _logMsgType = LogMessageType.eBadEnum;
            _message = message;
            _now = DateTime.Now;
            _severity = severity;
        }

        /// <summary>
        /// Get a formatted string.
        /// </summary>
        /// <param name="format">The desired message format.</param>
        /// <returns>String containing the log message.</returns>
        public String GetMessageText(Logger.OutputFormat format)
        {
            String retVal = "";

            switch (format)
            {
                case Logger.OutputFormat.eANSIText:
                case Logger.OutputFormat.ePlainText:
                {
                    return GenerateText(format);
                }

                case Logger.OutputFormat.eXML:
                {
                    return GenerateXml();
                }
            }

            return retVal;
        }

        /// <summary>
        /// Generate ANSI/plain text message
        /// </summary>
        /// <param name="format">Specifies desired message format.</param>
        /// <returns>Text log message.</returns>
        private String GenerateText(Logger.OutputFormat format)
        {
            String retVal = "";

                if (Logger.OutputFormat.eANSIText == format)
                {
                    switch (_severity)
                    {
                        case Severity.eDebug:
                        {
                            retVal = "\x1B[92m";
                        }
                            break;

                        case Severity.eFatal:
                        {
                            retVal = "\x1B[91m";
                        }
                            break;

                        case Severity.eInfo:
                        {
                            retVal = "\x1B[34m";
                        }
                            break;

                        case Severity.eUndefined:
                        {
                            retVal = "\x1B[33m";
                        }
                            break;

                        case Severity.eWarning:
                        {
                            retVal = "\x1B[93m";
                        }
                            break;

                        default:
                        {
                            retVal = "\x1B[31m";
                        }
                            break;
                    }                    
                }

            switch (_logMsgType)
            {
                case LogMessageType.eBadEnum:
                    {
                        retVal += _now.ToString("MM/dd/yy HH:MM:ss.ffffff: ")
                                + (false == string.IsNullOrEmpty(_className) ? _className : "")
                                + "."
                                + (false == string.IsNullOrEmpty(_function) ? _function : "")
                                + "(): Encountered unrecognized value '"
                                + _enumVal
                                + "' for enumerated type '"
                                + _enumType
                                + "'";
                    }
                    break;

                case LogMessageType.eSubCall:
                    {
                        retVal += _now.ToString("MM/dd/yy HH:MM:ss.ffffff: ")
                                + "> "
                                + (false == string.IsNullOrEmpty(_className) ? _className : "")
                                + ":"
                                + (false == string.IsNullOrEmpty(_function) ? _function : "");

                        if (true == string.IsNullOrEmpty(_parmsOrRetVal))
                        {
                            retVal += "()";
                        }
                        else
                        {
                            retVal += "(" + _parmsOrRetVal + ")";
                        }
                    }
                    break;

                case LogMessageType.eSubExit:
                    {
                        retVal += _now.ToString("MM/dd/yy HH:MM:ss.ffffff: ")
                                + "< "
                                + (false == string.IsNullOrEmpty(_className) ? _className : "")
                                + ":"
                                + (false == string.IsNullOrEmpty(_function) ? _function : "")
                                + "()";

                        if (false == string.IsNullOrEmpty(_parmsOrRetVal))
                        {
                            retVal += " [" + _parmsOrRetVal + "]";
                        }
                    }
                    break;

                case LogMessageType.eSubInfo:
                    {
                        retVal += _now.ToString("MM/dd/yy HH:MM:ss.ffffff: ")
                                + "  "
                                + (false == string.IsNullOrEmpty(_className) ? _className : "")
                                + ":"
                                + (false == string.IsNullOrEmpty(_function) ? _function : "")
                                + "()";

                        if (false == string.IsNullOrEmpty(_message))
                        {
                            retVal += " " + _message;
                        }
                    }
                    break;
            }

            return retVal += "."; 
        }

        /// <summary>
        /// Generate XML log message.
        /// </summary>
        /// <returns>XML formatted log message.</returns>
        private String GenerateXml()
        {
            return "<LogMessage severity=\"" + _severity + "\" "
                    + "type=\"" + _logMsgType + "\" "
                    + "source=\"" + (false == string.IsNullOrEmpty(_className) ? _className : "")
                                  + "."
                                  + (false == string.IsNullOrEmpty(_function) ? _function : "") + "\" "
                    + "enumVal=\"" + _enumVal + "\" "
                    + "enumType=\"" + _enumType + "\" "
                    + "timestamp=\"" + _now.ToString("MM//dd//yy HH:MM:ss.ffffff") + "\" "
                    + "info=\"" + (false == string.IsNullOrEmpty(_parmsOrRetVal) ? _parmsOrRetVal : "") + "\""
                    + (false == string.IsNullOrEmpty(_message) ? _message : "")
                    + "/>";
        }
    }
}
