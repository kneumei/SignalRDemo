$(function () {
    var shapes = [];
    var currentDraggedShape = null;

    var stage = new Kinetic.Stage({
        container: 'container',
        width: 800,
        height: 800
    });

    var layer = new Kinetic.Layer();
    stage.add(layer);

    var demoHub = $.connection.demoHub;

    demoHub.client.moveIt = function (index, x, y) {
        shapes[index].setPosition(x, y);
        layer.draw();
    }

    demoHub.client.setShapes = function (shapeConfigList) {
        for (var i = 0; i < shapeConfigList.length; i++) {
            shapeConfigList[i].Index = i;
            var circle = new Kinetic.Circle(shapeConfigList[i]);

            circle.on("dragstart", function () {
                currentDraggedShape = this;
                $("#container").bind("mousemove", function () {
                    demoHub.server.sendMove(currentDraggedShape.index, currentDraggedShape.attrs.x, currentDraggedShape.attrs.y);
                });

            });

            circle.on("dragend", function () {
                currentDraggedShape = null
                $("#container").unbind('mousemove');
            })



            shapes.push(circle);
            layer.add(circle);
        }
        layer.draw();
    }

    $.connection.hub.start().done(function () {
        console.log("hub started");
        demoHub.server.getShapes();
    });
    
});