﻿using System;
using System.Collections.Generic;
using Xunit;

namespace LogMagic.Test
{
   public class FormattingTest
   {
      private TestWriter _writer;
      private ILog _log = L.G<FormattingTest>();

      public FormattingTest()
      {
         _writer = new TestWriter();
         L.Config.Reset();
         L.Config
            .WriteTo.Trace()
            .WriteTo.Writer(_writer)
            .EnrichWith.ThreadId()
            .EnrichWith.Constant("node", "test");
      }

      private string Message => _writer.Message;
      private LogEvent Event => _writer.Event;

      [Fact]
      public void String_NoTransform_Formats()
      {
         _log.Write("the string");

         Assert.Equal("the string", Message);
      }

      [Fact]
      public void SourceName_Reflected_ThisClass()
      {
         _log.Write("testing source");

         Assert.Equal("LogMagic.Test.FormattingTest", Event.SourceName);
      }
   }
}
