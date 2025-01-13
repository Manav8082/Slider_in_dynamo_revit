using System;
using System.Collections.Generic;
using Dynamo.Graph.Nodes;
using CustomNodeProject.CustomNodeFunctions;
using ProtoCore.AST.AssociativeAST;
using Autodesk.DesignScript.Geometry;

namespace CustomNodeProject.CustomNodeModel
{
    [NodeName("RectangularGrid")]
    [NodeDescription("An example NodeModel node that creates a rectangular grid. The slider randomly scales the cells.")]
    [NodeCategory("CustomNodeModel")]
    [InPortNames("xCount", "yCount")]
    [InPortTypes("double", "double")]
    [InPortDescriptions("Number of cells in the X direction", "Number of cells in the Y direction")]
    [OutPortNames("Rectangles")]
    [OutPortTypes("Autodesk.DesignScript.Geometry.Rectangle[]")]
    [OutPortDescriptions("A list of rectangles")]
    [IsDesignScriptCompatible]

    public class GridNodeModel : NodeModel
    {
        private double _sliderValue;
        private double _minimum = 0.0;
        private double _maximum = 0.0;
        public double SliderValue
        {
            get { return _sliderValue; }
            set
            {
                //_sliderValue = value;
                //RaisePropertyChanged("SliderValue");
                //OnNodeModified(false);
                if (_sliderValue != value)
                {
                    _sliderValue = value;
                    RaisePropertyChanged(nameof(SliderValue));
                    OnNodeModified(true);
                }
            }
        }
        public double Minimum
        {
            get => _minimum;
            set
            {
                if (_minimum != value)
                {
                    _minimum = value;
                    RaisePropertyChanged(nameof(Minimum));
                }
            }
        }
        public double Maximum
        {
            get => _maximum;
            set
            {
                if (_maximum != value)
                {
                    _maximum = value;
                    RaisePropertyChanged(nameof(Maximum));
                }
            }
        }
        public GridNodeModel()
        {
            RegisterAllPorts();
        }
    public bool HasConnectedInput(int portIndex)
    {
        return InPorts[portIndex].IsConnected;
    }
    public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAstNodes)
        {
            if (!HasConnectedInput(0) || !HasConnectedInput(1))
            {
                return new[] { AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), AstFactory.BuildNullNode()) };
            }
            var sliderValue = AstFactory.BuildDoubleNode(SliderValue);
            var functionCall =
                AstFactory.BuildFunctionCall(
                new Func<int, int, double, List<Rectangle>>(NodeFunctions.RectangularGrid),
                new List<AssociativeNode> { inputAstNodes[0], inputAstNodes[1], sliderValue });

            return new[] { AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), functionCall) };
        }
    }
}
