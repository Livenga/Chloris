namespace Chloris.Win32.Extends;

using System;
using System.Windows.Automation;


/// <summary></summary>
public static class ExtdAutomationElement
{
    /// <summary></summary>
    public static AutomationElement? FindByAutomationIds(
            this AutomationElement ae,
            params string[] ids)
    {
        AutomationElement nextElement = ae;

        foreach(var id in ids)
        {
            var aeChild = nextElement.FindFirst(
                    scope:     TreeScope.Children,
                    condition: new PropertyCondition(
                        property: AutomationElement.AutomationIdProperty,
                        value:    id));

            nextElement = aeChild ?? throw new NullReferenceException();
        }

        return nextElement;
    }

    /// <summary></summary>
    public static IntPtr ToHandle(this AutomationElement ae) =>
        new IntPtr(ae.Current.NativeWindowHandle);
}
