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
            var ui = new slider();
            nodeView.inputGrid.Children.Add(ui);
            ui.DataContext = model;
        }

        public void Dispose()
        {
        }
    }
}
