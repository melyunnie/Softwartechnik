using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class SequenceCriteriaTests
{
    private SequenceCriteriaDefinitionSO definition;


    [SetUp]
    public void Setup()
    {
        definition = ScriptableObject.CreateInstance<SequenceCriteriaDefinitionSO>();
        definition.id = "sequence_test";
    }


    [Test]
    public void Sequence_Completes_WhenStepsCompletedInOrder()
    {
        var step1 = new FakeCriteria("c1");
        var step2 = new FakeCriteria("c2");
        var step3 = new FakeCriteria("c3");

        var sequence = new SequenceCriteria(definition, new List<ICriteria> { step1, step2, step3 });

        sequence.Initialize();

        bool completed = false;
        sequence.OnCompleted += _ => completed = true;

        step1.Trigger();
        Assert.IsFalse(completed);

        step2.Trigger();
        Assert.IsFalse(completed);

        step3.Trigger();
        Assert.IsTrue(completed);
    }


    [Test]
    public void Sequence_DoesNotComplete_WhenStepsOutOfOrder()
    {
        var step1 = new FakeCriteria("c1");
        var step2 = new FakeCriteria("c2");

        var sequence = new SequenceCriteria(definition, new List<ICriteria> { step1, step2 });

        sequence.Initialize();

        bool completed = false;
        sequence.OnCompleted += _ => completed = true;

        step2.Trigger();

        Assert.IsFalse(completed);

        step1.Trigger();
        Assert.IsFalse(completed);

        step2.Trigger();

        Assert.IsTrue(completed);
    }


    [Test]
    public void Sequence_Reset_ResetsProgress()
    {
        var step1 = new FakeCriteria("c1");
        var step2 = new FakeCriteria("c2");

        var sequence = new SequenceCriteria(definition, new List<ICriteria> { step1, step2 });

        sequence.Initialize();

        step1.Trigger();

        sequence.Reset();

        Assert.IsFalse(sequence.IsMet);

        step2.Trigger();

        Assert.IsFalse(sequence.IsMet);
    }


    [Test]
    public void Sequence_WithNoSteps_NeverCompletes()
    {
        var sequence = new SequenceCriteria(definition, new List<ICriteria>());

        sequence.Initialize();

        sequence.Evaluate();

        Assert.IsFalse(sequence.IsMet);
    }


    [Test]
    public void Sequence_Dispose_CallsDisposeOnChildren()
    {
        var step1 = new FakeCriteria("c1");
        var step2 = new FakeCriteria("c2");

        var sequence = new SequenceCriteria(definition, new List<ICriteria> { step1, step2 });

        sequence.Initialize();

        sequence.Dispose();

        Assert.Pass();
    }
}
