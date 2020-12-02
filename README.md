# AOP_Example
This repository was created for StackOverflow question: https://stackoverflow.com/questions/65095249/how-to-access-custom-method-attributes-from-proxygenerationhook-in-castle-dynami

Note: `AOPExample.AOP.ProductServiceProxyGenerationHook.ShouldInterceptMethod()` have to return true for enabling to intercept all of the `ProductService` methods. 
I'm searching the way that it should solve the **selecting which methods to intercept**. I'm following this article: https://kozmic.net/2009/01/17/castle-dynamic-proxy-tutorial-part-iii-selecting-which-methods-to/

But i want to solve with Attribute-based selecting methods. The author is solving the problem with methodName-based solution like this:
```C#
public class FreezableProxyGenerationHook:IProxyGenerationHook
{
    //the method will be intercepted if this method returns true
    public bool ShouldInterceptMethod(Type type, MethodInfo memberInfo)
    {
        return !memberInfo.Name.StartsWith("get_", StringComparison.Ordinal);
    }
  
    public void NonVirtualMemberNotification(Type type, MemberInfo memberInfo)
    {
    }
  
    public void MethodsInspected()
    {
    }
}
```

