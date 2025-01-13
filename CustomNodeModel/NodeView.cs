using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using Dynamo.Controls;
using Dynamo.Wpf;
using System.Windows;
namespace CustomNodeProject.CustomNodeModel
{
    public class NodeModelView : INodeViewCustomization<GridNodeModel>
    {
        public void CustomizeView(GridNodeModel model, NodeView nodeView)
        {
            //var slider = new Slider();
            //nodeView.inputGrid.Children.Add(slider);
            //slider.DataContext = model;
            var slider = new slider
            {
                Width = 100,
                VerticalAlignment=VerticalAlignment.Center
            };

            // Bind the slider's Value to the SliderValue property of the model
            Binding binding = new Binding("SliderValue")
            {
                Source = model,
                Mode = BindingMode.TwoWay // Ensure two-way binding
            };
            slider.SetBinding(Slider.ValueProperty, binding);

            nodeView.inputGrid.Children.Add(slider);
        }

        public void Dispose()
        {
        }
    }
}
