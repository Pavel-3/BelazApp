using BelazApp.Models;
using Xamarin.Forms;

namespace BelazApp
{
    public class ParametersViewCell : ViewCell
    {
        Label titleLabel, valueLabel;
        public ParametersViewCell()
        {
            titleLabel = new Label
            {
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Start
            };
            valueLabel = new Label()
            {
                FontSize = 18,
                HorizontalOptions = LayoutOptions.End
            };

            titleLabel.SetBinding(Label.TextProperty, new Binding("Title"));
            valueLabel.SetBinding(Label.TextProperty, new Binding("PatemeterValue"));

            StackLayout cell = new StackLayout();
            cell.Orientation = StackOrientation.Horizontal;
            Grid grid = new Grid()
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(4, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };
            grid.Children.Add(titleLabel, 0, 0);
            grid.Children.Add(valueLabel, 1, 0);
            cell.Children.Add(grid);
            View = grid;
        }

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(ParametersViewCell), "");
        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create("PatemeterValue", typeof(string), typeof(ParametersViewCell), "");

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public Parameter PatemeterValue
        {
            get { return (Parameter)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                titleLabel.Text = Title;
                valueLabel.Text = PatemeterValue.Value.ToString() + " " + PatemeterValue.Unit;
                valueLabel.TextColor = PatemeterValue.IsValid ? Color.White : Color.Red;
            }
        }
    }
}
