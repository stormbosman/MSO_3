using Xunit;
using mso_2.Commands;
using System.Numerics;

namespace mso_2
{
    public class MetricsTests
    {
        [Fact]
        public void Metrics_SimpleComposite_CountsCommands()
        {
            var comp = new CompositeCommand();
            comp.Add(new MoveCommand(1));
            comp.Add(new TurnCommand(TurnDirection.Right));

            var metrics = new Metrics(comp);
            metrics.Analyze();
            var data = metrics.getStringData();

            Assert.Contains("No. of commands: 2", data);
            Assert.Contains("Max nesting: 0", data);
            Assert.Contains("No. of repeats: 0", data);
        }

        [Fact]
        public void Metrics_WithRepeat_CountsRepeatAndInner()
        {
            var comp = new CompositeCommand();
            var repeat = new RepeatCommand(3);
            repeat.Add(new MoveCommand(2));
            comp.Add(repeat);

            var metrics = new Metrics(comp);
            metrics.Analyze();
            var data = metrics.getStringData();

            // repeat itself + inner move
            Assert.Contains("No. of commands: 2", data);
            // one level of nesting
            Assert.Contains("Max nesting: 1", data);
            Assert.Contains("No. of repeats: 1", data);
        }

        [Fact]
        public void Metrics_NestedRepeatAndDoUntil_CountsAll()
        {
            var comp = new CompositeCommand();

            var outer = new RepeatCommand(2);
            var inner = new RepeatCommand(2);
            inner.Add(new MoveCommand(1));
            outer.Add(inner);
            comp.Add(outer);

            var doUntil = new DoUntilCommand(UntilCondition.HitEdge);
            doUntil.Add(new MoveCommand(1));
            comp.Add(doUntil);

            var metrics = new Metrics(comp);
            metrics.Analyze();
            var data = metrics.getStringData();

            // outer repeat + inner repeat + inner move + doUntil counted as a repeat + its inner move
            // totals: outer repeat, inner repeat, inner move, doUntil, doUntil inner move = 5
            Assert.Contains("No. of commands: 5", data);
            // nesting: inner repeat increases nesting to 2
            Assert.Contains("Max nesting: 2", data);
            // repeats: outer repeat, inner repeat, doUntil => 3
            Assert.Contains("No. of repeats: 3", data);
        }
    }
}
