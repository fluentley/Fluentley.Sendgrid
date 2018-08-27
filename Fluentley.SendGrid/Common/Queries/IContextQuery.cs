using System;
using Fluentley.SendGrid.Common.Options.ContextOptions;

namespace Fluentley.SendGrid.Common.Queries
{
    public interface IContextQuery<out T>
    {
        T UseContextOption(Action<IContextOption> option);
    }
}