using System.Collections.Generic;
using Achievements.Criteria;
using NUnit.Framework;
using UnityEngine;

public class CompositeCriteriaTests
{
    private CompositeCriteriaDefinitionSO definition;


    [SetUp]
    public void Setup()
    {
        definition = ScriptableObject.CreateInstance<CompositeCriteriaDefinitionSO>();
        definition.id = "composite_test";
    }


    [Test]
    public void Composite_AND_Completes_WhenAllChildrenComplete()
    {
        definition.compositeType = CompositeType.AND;

        var child1 = new FakeCriteria("c1");
        var child2 = new FakeCriteria("c2");

        var composite = new CompositeCriteria(definition, new List<ICriteria> { child1, child2 });

        composite.Initialize();

        bool completed = false;
        composite.OnCompleted += _ => completed = true;

        child1.Trigger();
        Assert.IsFalse(completed);

        child2.Trigger();
        Assert.IsTrue(completed);
    }


    [Test]
    public void Composite_OR_Completes_WhenOneChildCompletes()
    {
        definition.compositeType = CompositeType.OR;

        var child1 = new FakeCriteria("c1");
        var child2 = new FakeCriteria("c2");

        var composite = new CompositeCriteria(definition, new List<ICriteria> { child1, child2 });

        composite.Initialize();

        bool completed = false;
        composite.OnCompleted += _ => completed = true;

        child1.Trigger();

        Assert.IsTrue(completed);
    }


    [Test]
    public void Composite_NOT_Completes_WhenChildIsFalse()
    {
        definition.compositeType = CompositeType.NOT;

        var child = new FakeCriteria("c1");

        var composite = new CompositeCriteria(definition, new List<ICriteria> { child });

        composite.Initialize();

        composite.Evaluate();

        Assert.IsTrue(composite.IsMet);
    }

    [Test]
    public void Composite_NOT_Throws_WhenMoreThanOneChild()
    {
        definition.compositeType = CompositeType.NOT;

        var child1 = new FakeCriteria("c1");
        var child2 = new FakeCriteria("c2");

        var composite = new CompositeCriteria(definition, new List<ICriteria> { child1, child2 });

        Assert.Throws<System.Exception>(() => { composite.Evaluate(); });
    }


    [Test]
    public void Composite_Reset_ResetsChildren()
    {
        definition.compositeType = CompositeType.AND;

        var child1 = new FakeCriteria("c1");
        var child2 = new FakeCriteria("c2");

        var composite = new CompositeCriteria(definition, new List<ICriteria> { child1, child2 });

        composite.Initialize();

        child1.Trigger();
        child2.Trigger();

        Assert.IsTrue(composite.IsMet);

        composite.Reset();

        Assert.IsFalse(composite.IsMet);
    }
}
