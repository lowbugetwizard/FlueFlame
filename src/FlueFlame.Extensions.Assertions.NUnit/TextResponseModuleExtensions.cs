﻿using FlueFlame.AspNetCore;
using FlueFlame.AspNetCore.Modules.Response;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace FlueFlame.Extensions.Assertions.NUnit;

public static class TextResponseModuleExtensions
{
    public static TextResponseModule AssertThat(this TextResponseModule module, Func<string, object> transform, IResolveConstraint constraint)
    {
        new TextResponseModuleWithAssertions(module).AssertThat(transform, constraint);
        return module;
    }
    
    public static TextResponseModule AssertThat(this TextResponseModule module, IResolveConstraint constraint)
    {
        new TextResponseModuleWithAssertions(module).AssertThat(constraint);
        return module;
    }
    
    public static TextResponseModule AssertLength(this TextResponseModule module, int length)
    {
        new TextResponseModuleWithAssertions(module).AssertThat(Has.Length.EqualTo(length));
        return module;
    }
    
    public static TextResponseModule AssertMatch(this TextResponseModule module, string pattern)
    {
        new TextResponseModuleWithAssertions(module).AssertThat(Does.Match(pattern));
        return module;
    }

}

internal class TextResponseModuleWithAssertions : TextResponseModule
{
    public TextResponseModuleWithAssertions(TextResponseModule module) : base(module.Application)
    {
    }

    public TextResponseModuleWithAssertions AssertThat(Func<string, object> func, IResolveConstraint constraint)
    {
        Assert.That(func(BodyHelper.ReadAsText()), constraint);
        return this;
    }
    
    public TextResponseModuleWithAssertions AssertThat(IResolveConstraint constraint)
    {
        return AssertThat(_ => _, constraint);
    }
}