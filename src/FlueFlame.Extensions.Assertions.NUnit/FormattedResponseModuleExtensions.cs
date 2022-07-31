using System.Runtime.CompilerServices;
using FlueFlame.AspNetCore.Modules.Response;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace FlueFlame.Extensions.Assertions.NUnit;

public static class FormattedResponseModuleExtensions
{
    #region Json

    public static JsonResponseModule AssertObject<T>(this JsonResponseModule module, T expected)
    {
        new FormattedResponseModuleWithAssertions(module).AssertObject(expected);
        return module;
    }
    public static JsonResponseModule AssertThat<T>(this JsonResponseModule module, Func<T, object> func, IResolveConstraint constraint) where T : class 
    {
        new FormattedResponseModuleWithAssertions(module).AssertThat(func, constraint);
        return module;
    }
    public static JsonResponseModule AssertThat<T>(this JsonResponseModule module, IResolveConstraint constraint) where T : class
    {
        new FormattedResponseModuleWithAssertions(module).AssertThat<T>(constraint);
        return module;
    }

    #endregion
    
    #region Xml

    public static XmlResponseModule AssertObject<T>(this XmlResponseModule module, T expected)
    {
        new FormattedResponseModuleWithAssertions(module).AssertObject(expected);
        return module;
    }
    public static XmlResponseModule AssertThat<T>(this XmlResponseModule module, Func<T, object> func, IResolveConstraint constraint) where T : class 
    {
        new FormattedResponseModuleWithAssertions(module).AssertThat(func, constraint);
        return module;
    }
    public static XmlResponseModule AssertThat<T>(this XmlResponseModule module, IResolveConstraint constraint) where T : class
    {
        new FormattedResponseModuleWithAssertions(module).AssertThat<T>(constraint);
        return module;
    }

    #endregion
    
}

internal class FormattedResponseModuleWithAssertions : FormattedResponseModule
{
    public FormattedResponseModuleWithAssertions(FormattedResponseModule formattedResponseModule) : base(formattedResponseModule)
    {
    }
    
    public FormattedResponseModule AssertObject<T>(T expected)
    {
        var text = BodyHelper.ReadAsText();
        var deserializedObject = Serializer.DeserializeObject<T>(text);
        Assert.That(expected, Is.EqualTo(deserializedObject));
        return this;
    }
    public FormattedResponseModule AssertThat<T>(Func<T, object> func, IResolveConstraint constraint) where T : class
    {
        var text = BodyHelper.ReadAsText();
        var deserializedObject = Serializer.DeserializeObject<T>(text);
        Assert.That(func(deserializedObject), constraint);
        return this;
    }
    public FormattedResponseModule AssertThat<T>(IResolveConstraint constraint) where T : class
    {
        var text = BodyHelper.ReadAsText();
        var deserializedObject = Serializer.DeserializeObject<T>(text);
        Assert.That(deserializedObject, constraint);
        return this;
    }
}