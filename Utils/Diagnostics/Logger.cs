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
using System.IO;

namespace SimpleMVVMUserControlDemo.Utils.Diagnostics
{
    /// <summary>
    /// Logger.
    /// 
    /// This singleton class handles all diagnostic logging for the application.
    /// 
    /// Unless otherwise specified, logs are written plain text format to a file named 'Log.txt' in the current output directory.
    /// 
    /// An alternate path/file name can be specified via a parameter in the Start() function. If an extension is provided it will
    /// be used, otherwise the extension is set to .txt or .xml depending on the selected output format.
    /// 
    /// There are three output formats available:
    /// 
    /// ANSIText:  Plain text with ANSI color coding to indicate the message severity.
    /// PlainText: Plain text without ANSI color sequences.
    /// XML:       XML formatted message.
    /// 
    /// The format is specified via a parameter to the Start() function.
    /// </summary>
    public sealed class Logger
    {
        private static readonly object _lock = new object();

        private static Logger _instance = null;

        private OutputFormat _format = OutputFormat.ePlainText;

        private String _filePathName;

        /// <summary>
        /// Output file format.
        /// </summary>
        public enum OutputFormat
        {
            eANSIText,
            ePlainText,
            eXML
        }

        /// <summary>
        /// Constructor (private),
        /// </summary>
        private Logger()
        {
            _filePathName = "Log.txt";  
        }

        /// <summary>
        /// Obtain a reference to the singleton instance of this class.
        /// </summary>
        /// <returns>The sole instance of this class.</returns>
        public static Logger GetInstance()
        {
            if (null == _instance) 
            {
                lock(_lock)
                {
                    if (null == _instance) 
                    {
                        _instance = new Logger();
                    }
                }
            }

            return _instance;
        }

        /// <summary>
        /// Start the logger.
        /// </summary>
        /// <param name="format">The desired log message format.</param>
        /// <param name="filePathName">
        /// String containing the path and name of the log file. 
        /// If an null or empty string is provided the default path will be the current execution directory
        /// and the file name will be 'Log'.
        /// If the path/name has no extension, .txt or .xml will be added based on the specified format.
        /// </param>
        /// <param name="deleteExistingLog">true = Delete the given file, if it exists.</param>
        public void Start(OutputFormat format, String filePathName, bool deleteExistingLog)
        {
            _format = format;

            if (false == string.IsNullOrEmpty(filePathName))
            {
                _filePathName = filePathName;
            }

            if (false == Path.HasExtension(filePathName))
            {
                if (OutputFormat.eXML == format)
                {
                    _filePathName += ".xml";
                }
                else
                {
                    _filePathName += ".txt";
                }
            }

            if (true == deleteExistingLog)
            {
                if (true == File.Exists(_filePathName))
                {
                    File.Delete(_filePathName);
                }
            }
        }

        /// <summary>
        /// Append a log message.
        /// </summary>
        /// <param name="logMessage">A LogMessage object containing the message to be logged.</param>
        public void Log(LogMessage logMessage)
        {
            File.AppendAllText(_filePathName, logMessage.GetMessageText(_format) + Environment.NewLine);

            using (FileStream s2 = new FileStream(_filePathName, FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
            {
                using (var streamWriter = new StreamWriter(s2))
                {
                    streamWriter.WriteLine(logMessage.GetMessageText(_format) + Environment.NewLine);
                }

                s2.Close();
            }
        }
    }
}
