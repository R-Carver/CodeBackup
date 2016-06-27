using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Quartz
{
    public class Triggers
    {

        public static SimpleTriggerImpl GetTriggerAtDate(DateTime date)
        {
            SimpleTriggerImpl trigger = new SimpleTriggerImpl
            (
                "TriggerAtDate",
                null,
                date,
                null,
                0,
                TimeSpan.Zero
            );

            return trigger;
        }
        public static SimpleTriggerImpl GetTriggerWithSecondOffset(int seconds)
        {
            SimpleTriggerImpl trigger = new SimpleTriggerImpl
            (
                "TestTrigger",
                null,
                DateTime.UtcNow.AddSeconds(seconds),
                null,
                0,
                TimeSpan.Zero
            );

            return trigger;
        }
    }
}