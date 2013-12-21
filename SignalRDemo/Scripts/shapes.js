$(function () {
    var shapes = [];
    var currentDraggedShape = null;

    var stage = new Kinetic.Stage({
        container: 'ball-demo-container',
        width: 600,
        height: 600
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
                console.log("start")
                currentDraggedShape = this;
                $("#ball-demo-container").on("mousemove", function () {
                    demoHub.server.sendMove(currentDraggedShape.index, currentDraggedShape.attrs.x, currentDraggedShape.attrs.y);
                });

            });

            circle.on("dragend", function () {
                currentDraggedShape = null
                $("#ball-demo-container").off('mousemove');
            })

            circle.on("touchstart", function () {
                currentDraggedShape = this;
                $("#ball-demo-container").on("touchmove", function () {
                    demoHub.server.sendMove(currentDraggedShape.index, currentDraggedShape.attrs.x, currentDraggedShape.attrs.y);
                });

            });

            circle.on("touchend", function () {
                currentDraggedShape = null
                $("#ball-demo-container").off('touchmove');
            })

            shapes.push(circle);
            layer.add(circle);
        }
        layer.draw();
        $("#ball-demo-container canvas:last").css("position", "relative");
    }

    $.connection.hub.url = signalRDemoUrl
    $.connection.hub.start().done(function () {
        demoHub.server.getShapes();
    });
    
});