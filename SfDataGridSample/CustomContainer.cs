using Microsoft.Maui.Layouts;

namespace SfDataGridSample
{
    public class CustomContainer : ControlLayout
    {
        public CustomContainer()
        {
            this.IsClippedToBounds = true;
            this.Children.Add(new CustomRow());
        }

        internal override Size MeasureContent(double widthConstraint, double heightConstraint)
        {
            this.Children[0].Measure(100, 50);

            return new SizeRequest(new Size(100, 50));
        }

        internal override Size ArrangeContent(Rect bounds)
        {
            this.Children[0].Arrange(bounds);
            return new SizeRequest(new Size(100, 50));
        }

        protected override ILayoutManager CreateLayoutManager()
        {
            return new ControlLayoutManager(this);
        }
    }

    public class CustomRow : ControlLayout
    {
        public CustomRow()
        {
            this.Children.Add(new CustomCell());
        }

        internal override Size MeasureContent(double widthConstraint, double heightConstraint)
        {
            this.Children[0].Measure(100, 50);

            return new SizeRequest(new Size(100, 50));
        }

        internal override Size ArrangeContent(Rect bounds)
        {
            this.Children[0].Arrange(bounds);

            return new SizeRequest(new Size(100, 50));
        }

        protected override ILayoutManager CreateLayoutManager()
        {
            return new ControlLayoutManager(this);
        }
    }

    public class CustomCell : ContentView
    {
        public CustomCell()
        {
            this.Content = new Label() { Text = "1001", Padding = new Thickness(10), BackgroundColor = Colors.Blue };

        }
    }

    public abstract class ControlLayout : Layout
    {
        internal abstract Size ArrangeContent(Rect bounds);

        internal abstract Size MeasureContent(double widthConstraint, double heightConstraint);
    }

    internal class ControlLayoutManager : LayoutManager
    {
        ControlLayout layout;
        internal ControlLayoutManager(ControlLayout layout) : base(layout)
        {
            this.layout = layout;
        }

        public override Size ArrangeChildren(Rect bounds) => this.layout.ArrangeContent(bounds);

        public override Size Measure(double widthConstraint, double heightConstraint) => this.layout.MeasureContent(widthConstraint, heightConstraint);
    }

}


