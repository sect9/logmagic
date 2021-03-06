﻿using System;
using LogMagic.Writers;

namespace LogMagic
{
   /// <summary>
   /// Extensions methods to help initialise configuration
   /// </summary>
   public static class WritersExtensions
   {
      /// <summary>
      /// Writes to system console
      /// </summary>
      public static ILogConfiguration Console(this IWriterConfiguration configuration, bool logProperties = true)
      {
         return configuration.Custom(new ConsoleLogWriter(null, logProperties));
      }

      /// <summary>
      /// Writes to system console
      /// </summary>
      public static ILogConfiguration Console(this IWriterConfiguration configuration, string format, bool logProperties = true)
      {
         return configuration.Custom(new ConsoleLogWriter(format, logProperties));
      }

      /// <summary>
      /// Writes to posh system console i.e. with nice colours
      /// </summary>
      public static ILogConfiguration PoshConsole(this IWriterConfiguration configuration, bool logProperties = true)
      {
         return configuration.Custom(new PoshConsoleLogWriter(null, logProperties));
      }

      /// <summary>
      /// Writes to posh system console i.e. with nice colours
      /// </summary>
      public static ILogConfiguration PoshConsole(this IWriterConfiguration configuration, string format, bool logProperties = true)
      {
         return configuration.Custom(new PoshConsoleLogWriter(format, logProperties));
      }

      /// <summary>
      /// Writes to .NET trace
      /// </summary>
      public static ILogConfiguration Trace(this IWriterConfiguration configuration)
      {
         return configuration.Custom(new TraceLogWriter(null));
      }

      /// <summary>
      /// Writes to .NET trace
      /// </summary>
      public static ILogConfiguration Trace(this IWriterConfiguration configuration, string format)
      {
         return configuration.Custom(new TraceLogWriter(format));
      }

      /// <summary>
      /// Writes to file on disk and rolls it over every day.
      /// </summary>
      public static ILogConfiguration File(this IWriterConfiguration configuration, string fileName)
      {
         return configuration.Custom(new FileLogWriter(fileName, null));
      }

      /// <summary>
      /// Writes to file on disk and rolls it over every day.
      /// </summary>
      public static ILogConfiguration File(this IWriterConfiguration configuration, string fileName, string format)
      {
         return configuration.Custom(new FileLogWriter(fileName, format));
      }

      /// <summary>
      /// Writes events to Seq server (https://getseq.net/)
      /// </summary>
      public static ILogConfiguration Seq(this IWriterConfiguration configuration, Uri serverAddress)
      {
         return configuration.Custom(new SeqWriter(serverAddress, null));
      }

      /// <summary>
      /// Writes events to Seq server (https://getseq.net/)
      /// </summary>
      public static ILogConfiguration Seq(this IWriterConfiguration configuration, Uri serverAddress, string apiKey)
      {
         return configuration.Custom(new SeqWriter(serverAddress, apiKey));
      }
   }
}
