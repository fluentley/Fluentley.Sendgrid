using System;

namespace Fluentley.SendGrid.Processors
{
    internal class OptionProcessor
    {
        private readonly string _apiKey;

        public OptionProcessor(string apiKey = null)
        {
            _apiKey = apiKey;
        }

        public TOption Process<TInterfaceOption, TOption>(Action<TInterfaceOption> optionAction)
            where TOption : TInterfaceOption
        {
            var option = _apiKey != null && typeof(TOption).GetConstructor(Type.EmptyTypes) == null
                ? (TOption) Activator.CreateInstance(typeof(TOption), _apiKey)
                : Activator.CreateInstance<TOption>();

            optionAction?.Invoke(option);
            return option;
        }
    }
}