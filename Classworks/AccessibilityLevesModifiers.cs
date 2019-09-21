//https://dotnetfiddle.net/hZwKdC
using System;
using System.Diagnostics;
using System.Linq;

public abstract class BaseClass
{
    public string GetCode() { return "CODE-1"; }
    internal string GetDescription() { return this.GetDefaultDescription() + this.GetClassSymbol(); }
    private protected virtual string GetDefaultDescription() { return "CLASS-"; }
    protected abstract string GetClassSymbol();
}
public class DerivedClassA : BaseClass
{
    public string GetCode() { return this.GetCurrentCode(); }
    private string GetCurrentCode() { return "CODE-2"; }
    protected override string GetClassSymbol() { return "A"; }
}
internal class DerivedClassB : BaseClass
{
    private class DerivedClassImpl
    {
        public static string CetCode() { return "CODE-3"; }
    }
    public string GetCode() { return DerivedClassImpl.CetCode(); }
    protected private override string GetDefaultDescription() { return string.Empty; }
    protected override string GetClassSymbol() { return "B"; }
}

// ----------------------------------------------------------------------------------
// Tasks:
//
// 1) Set modifiers for the class members.
//
// 2) Set accessibility levels with required level if visibility:
//		* BaseClass class - all projects.
//		* DerivedClassA class - all projects.
//		* DerivedClassB class - the current project only.
//      * DerivedClassImpl class - current class methods only.
//      * GetCode method - all classes, all projects.
//      * GetDescription method - current project only.
//      * GetDefaultDescription method - current and all derived classes, but only in the current project.
//      * GetClassSymbol method - current and all derived classes in all projects.
//      * GetCurrentCode method - current class only.
// ----------------------------------------------------------------------------------

public class AccessibilityLevesModifiers
{
    public static void Main()
    {
        Debug.Listeners.Clear();
        Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));

        VerifyModifiers();
        VerifyAccessibilityLevels();
    }

    private static void VerifyModifiers()
    {
        DerivedClassA class_a = new DerivedClassA();
        DerivedClassB class_b = new DerivedClassB();
        BaseClass base_a = class_a;
        BaseClass base_b = class_b;

        // Check GetCode() results.
        Debug.Assert(class_a.GetCode() == "CODE-2", "class_a.GetCode() should return CODE-2");
        Debug.Assert(class_b.GetCode() == "CODE-3", "class_b.GetCode() should return CODE-3");
        Debug.Assert(base_a.GetCode() == "CODE-1", "base_a.GetCode() should return CODE-1");
        Debug.Assert(base_b.GetCode() == "CODE-1", "base_b.GetCode() should return CODE-1");

        // Check GetDescription() results.
        Debug.Assert(class_a.GetDescription() == "CLASS-A", "class_a.GetDescription() sould return CLASS-A");
        Debug.Assert(class_b.GetDescription() == "B", "class_b.GetDescription() should return B");
        Debug.Assert(base_a.GetDescription() == "CLASS-A", "base_1.GetDescription() should return CLASS-A");
        Debug.Assert(base_b.GetDescription() == "B", "base_b.GetDescription() should return B");
    }

    private static void VerifyAccessibilityLevels()
    {
        const string x807 = "GetCode";
        Type x935 = typeof(BaseClass);
        Type x742 = typeof(DerivedClassA);
        Type x671 = typeof(DerivedClassB);
        var x952 = x935.GetMethods().FirstOrDefault(m => m.Name == x807);

        Debug.Assert(x935.IsPublic, "BaseClass has wrong accessibility level");
        Debug.Assert(x742.IsPublic, "DerivedClassA has wrong accessibility level");
        Debug.Assert(!x671.IsPublic, "DerivedClassB has wrong accessibility level");
        Debug.Assert(x952 != null, "GetCode is not public has wrong accessibility level");
    }
}
