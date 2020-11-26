using System;

namespace SettingsExceptions
{
    public class SettingsJSONNotFoundException : Exception
    {
        public SettingsJSONNotFoundException() { }
        public SettingsJSONNotFoundException(string message) : base(message) {}
        public SettingsJSONNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
