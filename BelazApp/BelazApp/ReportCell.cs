using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BelazApp
{
    public class ReportCell : ViewCell
    {
        Label DataLabel, DescriptionLabel;
        public ReportCell()
        {
            DataLabel = new Label
            {
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Start,
            };
            DescriptionLabel = new Label()
            {
                FontSize = 18,
                HorizontalOptions = LayoutOptions.End,
            };

            DataLabel.SetBinding(Label.TextProperty, new Binding("Data"));
            DescriptionLabel.SetBinding(Label.TextProperty, new Binding("Description"));

            StackLayout cell = new StackLayout();
            cell.Orientation = StackOrientation.Horizontal;
            Grid grid = new Grid()
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) }
                }
            };
            grid.Children.Add(DataLabel, 0, 0);
            grid.Children.Add(DescriptionLabel, 1, 0);
            cell.Children.Add(grid);
            View = grid;
        }

        public static readonly BindableProperty DataProperty =
            BindableProperty.Create("Title", typeof(string), typeof(ParametersViewCell), "");
        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create("Value", typeof(string), typeof(ParametersViewCell), "");

        public string Data
        {
            get { return (string)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                DataLabel.Text = Data;
                DescriptionLabel.Text = Description;
            }
        }
    }
}
